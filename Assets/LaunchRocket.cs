using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchRocket : MonoBehaviour
{
    private StateController state;
    private Rigidbody2D rocketRb;

    private Camera mainCam;
    private Vector3 mousePos;

    public float startingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;

        state = GetComponent<StateController>();
        rocketRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!state.IsLaunching())
            return;

        RotateToMouse();

        if (Input.GetMouseButton(0))
        {
            Launch();
        }

    }

    void RotateToMouse()
    {
        if (mainCam != null)
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        rotZ -= 90;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    void Launch()
    {
        state.Launch();

        Vector2 direction = transform.up;

        rocketRb.AddForce(direction * startingSpeed, ForceMode2D.Impulse);
    }
}
