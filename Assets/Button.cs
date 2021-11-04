using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool realButton;
    /// <summary>
    ///Checks if character touched button and moves door
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BrainV2 brain = other.GetComponent<BrainV2>();
            NewDoor door = GetComponentInParent<NewDoor>();
            if (realButton)
            {
                door.movingDown = false;
                door.movingUp = true;
            }
        }
    }
}
