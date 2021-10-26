using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeanBrain : MonoBehaviour
{
   
    enum AIstate
    {
        attacking,
        idle,
        fleeing,
        searching,
        dead,
        scared,
        friendly
    }
    AIstate currentState = AIstate.idle;

    [SerializeField]
    float health = 100;

    [SerializeField]
    float attackRadius;

    NavMeshAgent myAgent;
    Vector3 targetPos;

    GameObject targetObject = null;

    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        
        switch (currentState)
        {
            case AIstate.attacking:
                Attack();               
                break;
            case AIstate.idle:
                Idle();               
                break;
            case AIstate.fleeing:
                Flee();                
                break;
            case AIstate.searching:
                Search();                
                break;
        }

        myAgent.SetDestination(targetPos);
        
    }

    void Attack()
    {
        targetPos = targetObject.transform.position;
        health += -5 * Time.deltaTime;
        if(health < 10)
        {
            Debug.Log(gameObject.name + "health low");
            currentState = AIstate.fleeing;
        }
    }
    void Idle()
    {
        
        if(Random.Range(0f,5000f) > 4999f)
        {
            targetPos = transform.position + new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));           
        }

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRadius);        
        float distance = attackRadius;
        foreach (var hitCollider in hitColliders)
        {            
            if(hitCollider.tag == "Enemy" && hitCollider.gameObject != gameObject)
            {
                float hitDistance = Vector3.Distance(hitCollider.transform.position, transform.position);
                if (hitDistance < distance)
                {
                    targetObject = hitCollider.gameObject;
                    distance = hitDistance;
                }
            }
        }
        if(targetObject != null)
        {
            Debug.Log(gameObject.name + " Now Attacking " + targetObject.name);
            currentState = AIstate.attacking;
        }
    }
    void Flee()
    {
        targetPos = Vector3.MoveTowards(transform.position,targetObject.transform.position, -10f);
        health += 5 * Time.deltaTime;
        if(health > 50)
        {
            Debug.Log("idle");
            targetObject = null;
            currentState = AIstate.idle;
        }
    }
    void Search()
    {
        //if a timer expires - currentState = AIstate.idle
        //if we find the enemy - currentState = AIstate.attacking
    }
}
