using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISystem : StateMachine
{
    public GameObject waypointParent;
    public GameObject player;
    public GameObject enemy;
    public float lerpSpeed = 0.5f;
    public enum states{Idle, Patrol, Chase};
    [HideInInspector] public states newState = states.Idle;
    [HideInInspector] public int i = 0;

    void Start()
    {
        SetState(new BeginState(this));
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
                SetState(new IdleState(this));
                break;
            case states.Patrol:
                SetState(new PatrolState(this));
                break;
            case states.Chase:
                SetState(new ChaseState(this));
                break;
        }
        StartCoroutine(State.DoAction());
    }


}
