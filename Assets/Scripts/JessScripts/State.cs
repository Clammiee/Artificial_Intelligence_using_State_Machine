using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected AISystem _aISystem;

        public State(AISystem aISystem)
        {
            _aISystem = aISystem;
        }
        
        public virtual IEnumerator Start()
        {
            yield break;
        }

        public virtual IEnumerator DoAction()
        {
            yield break;
        }

        public virtual IEnumerator End()
        {
            yield break;
        }

        public void Animate(GameObject obj, string condition, bool boolean)
        {
            obj.GetComponent<Animator>().SetBool(condition, boolean);
        }

        public void FaceMovementDirection(GameObject goal, GameObject AI)
        {
            Vector3 dir = (goal.transform.position - AI.transform.position).normalized;
            AI.transform.forward = dir;
            AI.transform.Translate(Vector3.forward * _aISystem.lerpSpeed * Time.deltaTime);
        }
}
