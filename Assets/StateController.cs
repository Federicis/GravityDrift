using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public enum State {
        LAUNCHING,
        FLYING
    }

    public State state;

    // Start is called before the first frame update
    void Start()
    {
        state = State.LAUNCHING;
    }

    public bool IsLaunching()
    {
        return state == State.LAUNCHING;
    }

    public bool IsFlying()
    {
        return state == State.FLYING;
    }

    public void Launch()
    {
        state = State.FLYING;
    }
}
