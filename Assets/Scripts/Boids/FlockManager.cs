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

    [Header ("Fish Settings")]
    [Range(0.0f, 5.0f)]
    public float minSpeed;
    [Range(0.0f, 5.0f)]
    public float maxSpeed;
    [Range(1.0f, 10.0f)]
    public float neighbourDistance;
    [Range(1.0f, 5.0f)]
    public float rotationSpeed;


    // Start is called before the first frame update
    void Start()
    {
        allBees = new GameObject[numBees];
        for (int i = 0; i < numBees; i++)
        {
            Vector2 pos = new Vector2(transform.position.x, transform.position.y) + new Vector2(Random.Range(-FlyLimit.x, FlyLimit.x), 
                                                                Random.Range(-FlyLimit.y, FlyLimit.y));
            allBees[i] = Instantiate(Prefab, pos, Quaternion.identity);
        }
        FM = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
