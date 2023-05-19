using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBeeTeleport : MonoBehaviour
{
    Vector3 InitPos;
    public GameObject ResetObject;

    void Start() 
    {
        InitPos = transform.position;
    }

    public GameObject ResetFloor;


    private void OnTriggerEnter2D(Collider2D collision)
    {
    //Debug.Log("Target was Hit!" + collision);

    if(collision.gameObject == ResetObject)
    {
        transform.position = InitPos;//(where you want to teleport)
    }
    }
}
