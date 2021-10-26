using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : BehaviourClass
{
    public BehaviourClass RunBehaviour(BrainV2 brain)
    {
        if (Random.Range(0f, 500f) > 499f)
        {
            //brain.targetPos = brain.transform.position + new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
            brain.targetPos = brain.targetObject.transform.position;
            brain.myAgent.SetDestination(brain.targetPos);
        }
        return (brain.idle);
        /*/Collider[] hitColliders = Physics.OverlapSphere(brain.transform.position, brain.attackRadius);
        float distance = brain.attackRadius;
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.tag == "Enemy" && hitCollider.gameObject != brain.gameObject)
            {
                float hitDistance = Vector3.Distance(hitCollider.transform.position, brain.transform.position);
                if (hitDistance < distance)
                {
                    brain.targetObject = hitCollider.gameObject;
                    distance = hitDistance;
                }
            }
        }
        if (brain.targetObject != null)
        {
            Debug.Log(brain.gameObject.name + " Now Attacking " + brain.targetObject.name);
            return (brain.attack);
        }
        else
        {
            return (brain.idle);
        }/*/
    }
}
