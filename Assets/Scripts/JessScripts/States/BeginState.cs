using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginState : State
{
    public BeginState(AISystem aISystem) : base(aISystem)
    {      
    }

    public override IEnumerator Start()
    {    
        _aISystem.SetState(new IdleState(_aISystem));
        yield break;
    }
}
