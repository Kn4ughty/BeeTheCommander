using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public static FlockManager FM;
    public GameObject Prefab;
    public int numBees = 20;
    public GameObject[] allBees;
    public Vector2 FlyLimit = new Vector2(10, 10); 
    public Vector2 goalPos = Vector2.zero;

    [Header ("Fish Settings")]
    [Range(0.0f, 10.0f)]
    public float minSpeed;
    [Range(0.0f, 10.0f)]
    public float maxSpeed;
    [Range(1.0f, 10.0f)]
    public float neighbourDistance;
    [Range(1.0f, 5.0f)]
    public float rotationSpeed;
    public bool targetPositionRandom = false;

    
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        allBees = new GameObject[numBees];
        for (int i = 0; i < numBees; i++)
        {
            Vector2 pos = new Vector2(transform.position.x, transform.position.y) + new Vector2(Random.Range(-FlyLimit.x, FlyLimit.x), 
                                                                Random.Range(-FlyLimit.y, FlyLimit.y));
            allBees[i] = Instantiate(Prefab, pos, Quaternion.identity);
        }
        FM = this;
        goalPos = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(targetPositionRandom) {
            // Set target position randomly
            if (Random.Range(0, 1000) < 10) {
                goalPos = new Vector2(transform.position.x, transform.position.y) + new Vector2(Random.Range(-FlyLimit.x, FlyLimit.x), 
                                                                                                Random.Range(-FlyLimit.y, FlyLimit.y));
            } 
        }
        else {
            goalPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector3(goalPos.x, goalPos.y, 0), new Vector3(1, 1, 1));
       // Gizmos.DrawWireCube(transform.position, new Vector3(FlyLimit.x, FlyLimit.y, 1) * 2);
    }
}
