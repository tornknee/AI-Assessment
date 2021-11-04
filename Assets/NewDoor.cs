using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDoor : MonoBehaviour
{
    Vector3 up;
    Vector3 down;

    Rigidbody rigi;

    public bool movingUp;
    public bool movingDown;

    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        down = transform.position;
        up = down;
    }

    void Update()
    {
        up.y = transform.position.y + 1;
        down.y = transform.position.y - 1;
        if (movingUp)
        {
            MoveUp();
        }
        if (movingDown)
        {
            MoveDown();
        }
    }

    public void MoveUp()
    {
        if (transform.position.y < 15)
        {
            rigi.MovePosition(up);
        }
        else
        {
            StartCoroutine(DoorClose());
        }
    }
    private void MoveDown()
    {
        if (transform.position.y > 5)
        {
            rigi.MovePosition(down);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {

            BrainV2 brain = other.GetComponent<BrainV2>();
            Transform[] buttons = GetComponentsInChildren<Transform>();
            Transform chosenButton = buttons[Random.Range(1, buttons.Length)];
            brain.FindButton(chosenButton);
        }    
             
    }

    IEnumerator DoorClose()
    {
        yield return new WaitForSeconds(10);
        movingUp = false;
        movingDown = true;
    }
}
