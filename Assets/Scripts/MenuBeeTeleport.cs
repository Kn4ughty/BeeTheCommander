using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script upon start gets the current position of the object and stores it in the InitPos variable.
Then when the object enters a trigger, and the trigger is the ResetObject,
it resets its position to the InitPos
*/

public class MenuBeeTeleport : MonoBehaviour
{
    public GameObject ResetObject;

    private Vector3 InitPos;

    void Start() 
    {
        InitPos = transform.position;
    }

    public GameObject ResetFloor;


    private void OnTriggerEnter2D(Collider2D collision)//collider? i hardly know her!
    {

    if(collision.gameObject == ResetObject)
    {
        transform.position = InitPos;//(where you want to teleport)
    }
    }
}
