using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    public PatrolState(AISystem aISystem) : base(aISystem)
    {        
    }

    public override IEnumerator DoAction()
    {   
        //walking animation
        Animate(_aISystem.enemy, "Walk", true);

        //waypoint movement function call
        WaypointMovement();

        yield break;
    }

    public void WaypointMovement()
    {
        if(_aISystem.waypointParent.transform.childCount > 0)
        {
           if(_aISystem.enemy.transform.position != _aISystem.waypointParent.transform.GetChild(_aISystem.i).transform.position)
            {
                if(Vector3.Distance(_aISystem.enemy.transform.position, _aISystem.waypointParent.transform.GetChild(_aISystem.i).transform.position) > _aISystem.distanceBeforeTeleport)
                {
                    FaceMovementDirection(_aISystem.waypointParent.transform.GetChild(_aISystem.i).gameObject, _aISystem.enemy);
                    _aISystem.enemy.transform.position = Vector3.Lerp(_aISystem.enemy.transform.position, _aISystem.waypointParent.transform.GetChild(_aISystem.i).transform.position, _aISystem.lerpSpeed * Time.deltaTime);
                }   
                else if(Vector3.Distance(_aISystem.enemy.transform.position, _aISystem.waypointParent.transform.GetChild(_aISystem.i).transform.position) <= _aISystem.distanceBeforeTeleport)
                {
                    _aISystem.enemy.transform.position = _aISystem.waypointParent.transform.GetChild(_aISystem.i).transform.position;
                }
            }
            else if(_aISystem.enemy.transform.position == _aISystem.waypointParent.transform.GetChild(_aISystem.i).transform.position)
            {
                if(_aISystem.i == (_aISystem.waypointParent.transform.childCount-1)) _aISystem.i = 0;
                else _aISystem.i++;
            }
        }    
    }

    public override IEnumerator End()
    {    
        //set walking to false
        Animate(_aISystem.enemy, "Walk", false);
        yield break;
    }
}
