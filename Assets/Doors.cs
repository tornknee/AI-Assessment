using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    int timer;
    Vector3 up;
    Vector3 down;

    Rigidbody rigi;

    bool movingUp;
    bool movingDown;

    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        down = transform.position;
        up = down;
        StartCoroutine(DoorTimer());
    }

    // Update is called once per frame
    void Update()
    {
        up.y = transform.position.y + 1;
        down.y = transform.position.y - 1;
        if (movingUp)
        {
            MoveUp();
        }
        if(movingDown)
        {
            MoveDown();
        }
    }

    IEnumerator DoorTimer()
    {
        timer = Random.Range(1, 30);
        yield return new WaitForSeconds(timer);
        movingDown = false;
        movingUp = true;
        timer = Random.Range(1, 30);
        yield return new WaitForSeconds(timer);
        movingUp = false;
        movingDown = true;
        StartCoroutine(DoorTimer());
    }

    private void MoveUp()
    {
        if (transform.position.y < 15)
        {
            rigi.MovePosition(up);
        }
    }
    private void MoveDown()
    {
        if (transform.position.y > 5)
        {
            rigi.MovePosition(down);
        }
    }
}
