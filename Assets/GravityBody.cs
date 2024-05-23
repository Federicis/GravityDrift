using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GravityBody : MonoBehaviour
{

    public GameObject rocket;

    public static float density = 5515.0f; // kg/m3. all planets will have the density of Earth
    public static float base_radius = 6372; // km. the base radius (for scale x=1, y=1) is the radius of Earth
    public static float K = 6.67e-11f;  // gravitational constant

    private float radius;
    private float mass;

    public float maxGravity;
    public float maxGravityDistance;

    private Rigidbody2D rocketRb;
    private RocketManager rocketManager;
    private float rocketMass;
    public Sprite circleSprite;     // The sprite to use for the circle

    private void Start()
    {
        rocketRb = rocket.GetComponent<Rigidbody2D>();
        rocketManager = rocket.GetComponent<RocketManager>();
        rocketMass = rocketManager.mass;
        calculate_radius();
        calculate_mass();
    }

    // Update is called once per frame
    void Update()
    {
        if (!rocketManager.IsFlying())
            return;

        float dist = Vector2.Distance(transform.position, rocket.transform.position);

        Vector3 v = transform.position - rocket.transform.position;

        float relativeDistance = (1.0f - dist / maxGravityDistance);

        if (relativeDistance < 0.0f)
            relativeDistance = 0.0f;

        dist *=base_radius;

        Debug.Log("initial: " + (maxGravity*relativeDistance));
        Debug.Log("actual: " + (K*mass*rocketMass/(dist*dist)));

        rocketRb.AddForce(K*mass*rocketMass/(dist*dist)*v.normalized);
        /*        rocketRb.transform.LookAt(rocketRb.velocity, Vector3.forward);
        */
        RotateObject();
    }

    void RotateObject()
    {
        // Get the velocity vector
        Vector2 velocity = rocketRb.velocity;

        // Calculate the angle in radians and then convert to degrees
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;

        angle -= 90;

        // Set the rotation of the object (Quaternion.Euler uses degrees)
        rocket.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void calculate_radius()
    {
        radius = transform.localScale.x;
        Debug.Log("Radius: " + radius); 
    }

    float get_volume()
    {
        return math.PI * radius * radius;
    }

    void calculate_mass()
    {
        mass = density * get_volume();
    }
}
