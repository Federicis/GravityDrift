using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour {

    [Header("File Storage Config")]
    [SerializeField] private string fileName = "gameData.json";
    private FileDataHandler fileDataHandler;

    private GameData gameData;
    public static DataPersistenceManager instance { get; private set; }
    private List<IDataPersistence> dataPersistenceObjects;

    private void Start() {
        dataPersistenceObjects = FindAllDataPersistenceObjects();
        fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        //Debug.Log(Application.persistentDataPath);
        int new_game = PlayerPrefs.GetInt("new_game");
        if (new_game == 1)
            NewGame();
        else LoadGame();
        PlayerPrefs.SetInt("new_game", 0);
    }

    private void Awake() {
        if(instance != null) {
            Debug.LogError("Found more than one DataPersistenceManager instance");
        }
        instance = this;
    }

    public void NewGame() {
        gameData = new GameData();
    }

    public void LoadGame() {
        gameData = fileDataHandler.Load();
        if(gameData == null) {
            Debug.Log("No game data found, creating new game");
            NewGame();
        }

        foreach(IDataPersistence dataPersistenceObject in dataPersistenceObjects) {
            dataPersistenceObject.LoadData(gameData);
        }
    }

    public void SaveGame() {
        foreach(IDataPersistence dataPersistenceObject in dataPersistenceObjects) {
            dataPersistenceObject.SaveData(ref gameData);
        }

        fileDataHandler.Save(gameData);
    }

    private void OnApplicationQuit() {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects() {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return dataPersistenceObjects.ToList();
    }
}
