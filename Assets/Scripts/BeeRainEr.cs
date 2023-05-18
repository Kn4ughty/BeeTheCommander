using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeRainEr : MonoBehaviour
{   
    public GameObject objectPrefab;
    public int spawnCountX;
    public int spawnCountY;
    public float spacingX;
    public float spacingY;

    private void Start()
    {
        Vector3 spawnPosition = transform.position;

        for (int x = 0; x < spawnCountX; x++)
        {
            for (int y = 0; y < spawnCountY; y++)
            {
                Vector3 spawnOffset = new Vector3(spacingX * x, spacingY * y, 0);
                Vector3 spawnPoint = spawnPosition + spawnOffset;
                Instantiate(objectPrefab, spawnPoint, Quaternion.identity);
            }
        }
    }

    /*
    public GameObject SpawnObject;
    
    public int SpawnCountX;
    public int SpawnCountY;

    public float SpacingX;
    public float SpacingY;

    public Vector2 SpawnPosition;

    void Start()
    {
        Debug.Log("Start() method called.");
        Debug.Log("SpawnObject: " + SpawnObject);

        SpawnPosition = new Vector2(transform.position.x, transform.position.y);
        
        Debug.Log("Spawn Position= " + SpawnPosition);

        // Goes over the X position
        for (var SpawnX = 0; SpawnX < SpawnCountX; SpawnX += 1) {
            xPos = 
            // Goes over Y
            for (var y = SpawnPosition[1]; y < SpawnCountY; y += SpacingY) {
                Debug.Log("x = " + x);
                Debug.Log("y = " + y);
                Instantiate(SpawnObject, new Vector2(x, y), Quaternion.identity);
            } }
    }
    */
}