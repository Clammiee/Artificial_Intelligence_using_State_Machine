using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public ChaseState(AISystem aISystem) : base(aISystem)
    {        
    }

    public override IEnumerator DoAction()
    {   
        //sprinting animation
        Animate(_aISystem.enemy, "Sprint", true);

        //chase movement function call
        ChaseMovement();
        yield break;
    }

    public void ChaseMovement()
    {
        if(Vector3.Distance(_aISystem.enemy.transform.position, _aISystem.player.transform.position) > 1)
        {
            FaceMovementDirection(_aISystem.player.gameObject, _aISystem.enemy);
            _aISystem.enemy.transform.position = Vector3.Lerp( _aISystem.enemy.transform.position, _aISystem.player.transform.position, _aISystem.lerpSpeed * Time.deltaTime);
        }
    }

    public override IEnumerator End()
    {    
        //set sprinting to false
        Animate(_aISystem.enemy, "Sprint", false);
        yield break;
    }
}
