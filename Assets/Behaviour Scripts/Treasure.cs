using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    BrainV2 playerBrain;
    /// <summary>
    /// Destroys the treasure object and adds 1 to the treasureFound of the character
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        playerBrain = other.GetComponent<BrainV2>();
        playerBrain.treasureFound++;
        Destroy(gameObject);
    }
}
