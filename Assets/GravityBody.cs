using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GravityBody : MonoBehaviour
{

    public GameObject rocket;

    public float maxGravity;
    public float maxGravityDistance;

    private Rigidbody2D rocketRb;

    private void Start()
    {
        rocketRb = rocket.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(transform.position, rocket.transform.position);

        Vector3 v = transform.position - rocket.transform.position;

        float relativeDistance = (1.0f - dist / maxGravityDistance);

        if (relativeDistance < 0.0f)
            relativeDistance = 0.0f;

        rocketRb.AddForce(v.normalized * relativeDistance * maxGravity);
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
}
