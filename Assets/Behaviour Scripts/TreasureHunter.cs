using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureHunter : BehaviourClass 
{
    public BehaviourClass RunBehaviour(BrainV2 brain)
    {
        GameObject[] treasures = GameObject.FindGameObjectsWithTag("Treasure");
        if (brain.treasureFound < 3 && treasures.Length != 0)
        {
            if (brain.targetObject == null)
            {
                brain.targetObject = treasures[Random.Range(0, treasures.Length)];
            }            
            brain.targetPos = brain.targetObject.transform.position;           
        }
        else
        {
            brain.targetObject = GameObject.FindGameObjectWithTag("Finish");
            brain.targetPos = brain.targetObject.transform.position;
        }
        
        return (brain.treasure);
    }


}
