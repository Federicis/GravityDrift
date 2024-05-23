using UnityEngine;
using UnityEngine.UI;

public class GravityField : MonoBehaviour
{
    public GravityBody planet;
    private float scale_constant = 0.1690881f;

    private void Start()
    {
        planet = transform.parent.GetComponent<GravityBody>();

        if (planet == null)
        {
            Debug.LogError("Could not acces the planet parent");
            return;
        }
        float radius = planet.maxGravityDistance;
        transform.localScale = new Vector3 (radius * scale_constant, radius * scale_constant, 1.0f);
    }
}
