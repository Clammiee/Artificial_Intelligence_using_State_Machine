using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISystem : StateMachine
{
    public GameObject waypointParent;
    public GameObject player;
    public GameObject enemy;
    public enum states{Idle, Patrol, Chase};
   [HideInInspector] public states newState = states.Idle;

    void Start()
    {
        //call the setup AI function
    }

    public void IdleButton()
    {
        CommonTasks(states.Idle);
    }

    public void PatrolButton()
    {
        CommonTasks(states.Patrol);
    }

    public void ChaseButton()
    {
        CommonTasks(states.Chase);
    }

    public void CommonTasks(states currentState)
    {
        StartCoroutine(State.End());
        newState = currentState;
    }

    void Update()
    {
        switch(newState)
        {
            case states.Idle:
                //do the setting of the states in here instead of their classes
                break;
            case states.Patrol:
                //do the setting of the states in here instead of their classes
                break;
            case states.Chase:
                //do the setting of the states in here instead of their classes
                break;
            
        }
    }


}
