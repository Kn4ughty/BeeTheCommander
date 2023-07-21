using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableDisplay : MonoBehaviour
{
    // Should read data for info, but we dont have data to read yet
    private int pollen = 0;
    private int wood = 0;
    private int water = 0;
    private int stone = 0;

    [SerializeField] private Text pollenText;
    [SerializeField] private Text woodText;
    [SerializeField] private Text waterText;
    [SerializeField] private Text stoneText;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // I hate this so much whyyyy
        if (collision.gameObject.CompareTag("Pollen"))
        {
            Destroy(collision.gameObject);
            pollen++;
            pollenText.text = "Pollen: " + pollen;
        }
       if (collision.gameObject.CompareTag("Wood"))
        {
            Destroy(collision.gameObject);
            wood++;
            woodText.text = "Wood: " + wood;
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            Destroy(collision.gameObject);
            water++;
            waterText.text = "Water: " + water;
        }
        if (collision.gameObject.CompareTag("Stone"))
        {
            Destroy(collision.gameObject);
            stone++;
            stoneText.text = "Stone: " + stone;
        }
    }
}