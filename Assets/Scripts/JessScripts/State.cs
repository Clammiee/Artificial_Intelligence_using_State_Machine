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
}
