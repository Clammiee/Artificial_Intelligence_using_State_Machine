using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public IdleState(AISystem aISystem) : base(aISystem)
    {        
    }

    public override IEnumerator DoAction()
    {    
        //idle animation
        Animate(_aISystem.enemy, "Idle", true);
        yield break;
    }

    public override IEnumerator End()
    {    
        //set idle to false
        Animate(_aISystem.enemy, "Idle", false);
        yield break;
    }
}
