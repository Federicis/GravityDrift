using UnityEngine;
using UnityEngine.UI;

public class GravityField : MonoBehaviour
{
    public GravityBody planet;
    private float scale_constant = 94.0f/600.0f;

    private void Start()
    {
        planet = transform.parent.GetComponent<GravityBody>();

        if (planet == null)
        {
            Debug.LogError("Could not acces the planet parent");
            return;
        }
        float radius = planet.maxGravityDistance;
        transform.localScale = new Vector3 (radius * scale_constant + scale_constant , radius * scale_constant + scale_constant, 1.0f);
    }
}
