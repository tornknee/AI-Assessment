using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : BehaviourClass
{
    public BehaviourClass RunBehaviour(BrainV2 brain)
    {
        brain.targetPos = brain.targetObject.transform.position;
        brain.myAgent.SetDestination(brain.targetPos);
        brain.health += -5 * Time.deltaTime;
        if (brain.health < 10)
        {
            Debug.Log(brain.gameObject.name + "health low");
            return (brain.flee);
        }
        else
        {
            return (brain.attack);
        }
    }
}
