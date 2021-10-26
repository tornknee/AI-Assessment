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
    // Start is called before the first frame update
    void Start()
    {
        currentBehaviour = treasure;
        myAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        currentBehaviour = currentBehaviour.RunBehaviour(this);

    }
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
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        if (myAgent.remainingDistance <= 0.1f || myAgent.velocity.magnitude < 0.1f)
        {
            SeekTreasure();
        }
        StartCoroutine(Wait());
    }
}
