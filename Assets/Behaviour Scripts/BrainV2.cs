using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BrainV2 : MonoBehaviour
{
    public IdleBehaviour idle = new IdleBehaviour();
    public AttackBehaviour attack = new AttackBehaviour();
    public FleeBehaviour flee = new FleeBehaviour();
    public TreasureHunter treasure = new TreasureHunter();

    BehaviourClass currentBehaviour; 

    public Vector3 targetPos;
    public float attackRadius;
    public GameObject targetObject;
    public Vector3 lerpPos;

    public float health = 100;

    public NavMeshAgent myAgent;
    public int treasureFound = 0;

    void Start()
    {
        currentBehaviour = treasure;
        myAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(Wait());
    }

    void Update()
    {
        currentBehaviour = currentBehaviour.RunBehaviour(this);
    }

    /// <summary>
    /// Finds the direction to its target treasure, then chooses a point between 0.1m and the treasure, then sets this point as destination
    /// </summary>
    void SeekTreasure()
    {       
        float range;
        range = Random.Range(0.1f, Vector3.Distance(transform.position, targetPos));      
        lerpPos = targetPos - transform.position;
        lerpPos.Normalize();
        lerpPos *= range;
        lerpPos += transform.position;
        myAgent.SetDestination(lerpPos);        
    }

    /// <summary>
    /// Just waits 1 second when stopped or at destination before recalculating
    /// </summary>
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        if (myAgent.remainingDistance <= 0.1f || myAgent.velocity.magnitude < 0.1f)
        {
            SeekTreasure();           
        }
        StartCoroutine(Wait());
    }

    /// <summary>
    /// Takes in a button from the door it has touched and sets it as the destination
    /// </summary>
    /// <param name="button">button which is child to the door that character has touched</param>
    public void FindButton(Transform button)
    {        
        Vector3 newDest = button.position;
        myAgent.SetDestination(newDest);
    }
}
