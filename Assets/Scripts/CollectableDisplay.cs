using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableDisplay : MonoBehaviour
{
    // Should read data for info, but we dont have data to read yet
    private static int flower = 0;
    private static int wood = 0;
    private static int water = 0;
    private static int stone = 0;

    [SerializeField] private Text pollenText;
    [SerializeField] private Text woodText;
    [SerializeField] private Text waterText;
    [SerializeField] private Text stoneText;

    private int bagel = 0;


    private void Awake() {
        pollenText.text = "Pollen: " + PlayerPrefs.GetInt("PollenAmount");
        woodText.text = "Wood: " + PlayerPrefs.GetInt("WoodAmount");
        stoneText.text = "Stone: " + PlayerPrefs.GetInt("StoneAmount");
        waterText.text = "Water: " + PlayerPrefs.GetInt("WaterAmount");
    }


    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // I hate this so much whyyyy
        // sorry ;-; -Oscar
        if (collision.gameObject.CompareTag("Pollen"))
        {
            Destroy(collision.gameObject);

            bagel = PlayerPrefs.GetInt("PollenAmount") + 1;
            pollenText.text = "Pollen: " + bagel;
            PlayerPrefs.SetInt("PollenAmount", bagel);
        }
       if (collision.gameObject.CompareTag("Wood"))
        {
            Destroy(collision.gameObject);
            bagel = PlayerPrefs.GetInt("WoodAmount") + 1;
            woodText.text = "Wood: " + bagel;
            PlayerPrefs.SetInt("WoodAmount", bagel);
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            Destroy(collision.gameObject);
            bagel = PlayerPrefs.GetInt("WaterAmount") + 1;
            waterText.text = "Water: " + bagel;
            PlayerPrefs.SetInt("WaterAmount", bagel);
        }
        if (collision.gameObject.CompareTag("Stone"))
        {
            Destroy(collision.gameObject);
            bagel = PlayerPrefs.GetInt("StoneAmount") + 1;
            stoneText.text = "Stone: " + bagel;
            PlayerPrefs.SetInt("StoneAmount", bagel);
        }
    }
}