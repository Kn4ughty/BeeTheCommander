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
    public float maxOffset;

    private void Start()
    {
        Vector3 spawnPosition = transform.position;

        for (int x = 0; x < spawnCountX; x++)
        {
            for (int y = 0; y < spawnCountY; y++)
            {
                Vector3 spawnOffset = new Vector3(spacingX * x, spacingY * y, 0);
                Vector3 randomizedOffset = new Vector3(Random.Range(-maxOffset, maxOffset), Random.Range(-maxOffset, maxOffset), 0);
                Vector3 spawnPoint = spawnPosition + spawnOffset + randomizedOffset;
                Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
                Instantiate(objectPrefab, spawnPoint, randomRotation);
            }
        }
    }
}
