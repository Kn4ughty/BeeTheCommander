using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidSpawner : MonoBehaviour
{
    public Boid prefab;
    public float spawnRadius = 10;
    public int spawnCount = 10;

    void Awake()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector2 randomPoint = Random.insideUnitCircle * spawnRadius;
            Vector3 pos = transform.position + new Vector3(randomPoint.x, randomPoint.y, 0);
            Boid boid = Instantiate(prefab);
            boid.transform.position = pos;
            boid.transform.forward = new Vector3(randomPoint.x, randomPoint.y, 0);

            // boid.SetColour (colour);
        }
    }
}
