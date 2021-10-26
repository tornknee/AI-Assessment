using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeBehaviour : BehaviourClass
{
    public BehaviourClass RunBehaviour(BrainV2 brain)
    {
        brain.targetPos = Vector3.MoveTowards(brain.transform.position, brain.targetObject.transform.position, -10f);
        brain.myAgent.SetDestination(brain.targetPos);
        brain.health += 5 * Time.deltaTime;
        if (brain.health > 50)
        {
            Debug.Log("idle");
            brain.targetObject = null;
            return (brain.idle);
        }
        else
        {
            return (brain.flee);
        }
    }
}
