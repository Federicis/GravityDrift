using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketManager : MonoBehaviour
{
    StateController rocketState;
    public GameObject rocketBoost;
    public GameObject parachute;
    public Rigidbody2D rocketRb;


    bool leftClickPressedOnce = false;
    bool leftClickPressedLastFrame = false;

    bool rightClickPressedLastFrame = false;

    // Start is called before the first frame update
    void Start()
    {
        rocketState = GetComponent<StateController>();
        rocketRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!rocketState.IsFlying())
            return;


        if (Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            if (leftClickPressedOnce)
            {
                rocketBoost.SetActive(true);
                if (!leftClickPressedLastFrame)
                {
                    rocketRb.AddForce(transform.up * 2f, ForceMode2D.Impulse);
                    leftClickPressedLastFrame = true;
                }
            }

        } else
        {
            leftClickPressedOnce = true;
            rocketBoost.SetActive(false);
            if (leftClickPressedLastFrame)
            {
                leftClickPressedLastFrame = false;
                rocketRb.AddForce(transform.up * -2f, ForceMode2D.Impulse);
            }
        }

        if (Input.GetMouseButton(1) && !Input.GetMouseButton(0))
        {
            parachute.SetActive(true);
            if (!rightClickPressedLastFrame)
            {
                rocketRb.AddForce(transform.up * -2f, ForceMode2D.Impulse);
                rightClickPressedLastFrame = true;
            }
        }
        else
        {
            parachute.SetActive(false);
            if (rightClickPressedLastFrame)
            {
                rightClickPressedLastFrame = false;
                rocketRb.AddForce(transform.up * 2f, ForceMode2D.Impulse);
            }
        }
    }

    public bool IsFlying()
    {
        return rocketState.IsFlying();
    }
}
