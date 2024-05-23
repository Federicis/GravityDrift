using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GravityBody : MonoBehaviour
{

    public GameObject rocket;
    public RocketManager rocketManager;

    public float maxGravity;
    public float maxGravityDistance;

    private Rigidbody2D rocketRb;
    public Sprite circleSprite;     // The sprite to use for the circle

    private void Start()
    {
        rocketRb = rocket.GetComponent<Rigidbody2D>();
        rocketManager = rocket.GetComponent<RocketManager>();
        Color circleColor = new Color(1, 1, 1, 0.5f);
        Vector2 offset = Vector2.zero;

        // Create a new GameObject for the circle
        GameObject circleObject = new GameObject("SemiTransparentCircle");

        // Set the circle object as a child of the target object
        circleObject.transform.SetParent(transform);

        // Set the position of the circle object to be on top of the target object
        circleObject.transform.localPosition = new Vector3(offset.x, offset.y, 0);

        // Add a SpriteRenderer component to the circle object
        SpriteRenderer spriteRenderer = circleObject.AddComponent<SpriteRenderer>();

        // Set the sprite of the SpriteRenderer to the circle sprite
        spriteRenderer.sprite = circleSprite;

        // Set the color of the SpriteRenderer to the desired color with transparency
        spriteRenderer.color = circleColor;

        // Optionally, adjust the sorting layer to ensure the circle is rendered on top
        spriteRenderer.sortingOrder = 1; // Higher value means it will render on top
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
