using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateForState : MonoBehaviour
{
    public enum State { normal, inconforme, satisfecho}
    State state = State.normal;
    
    public void ChangeState(State state)
    {
        this.state = state;
        GetComponent<Animator>().SetInteger("Estado", ((int)state));
    }
}
