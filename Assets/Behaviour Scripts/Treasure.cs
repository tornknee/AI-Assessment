using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    //GameObject player;
    BrainV2 playerBrain;

    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
       // playerBrain = player.GetComponent<BrainV2>();
    }
    private void OnTriggerEnter(Collider other)
    {
        playerBrain = other.GetComponent<BrainV2>();
        playerBrain.treasureFound++;
        Destroy(gameObject);
    }
}
