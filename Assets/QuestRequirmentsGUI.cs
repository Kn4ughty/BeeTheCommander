using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestRequirmentsGUI : MonoBehaviour
{
    private string[] resourceTypes = {"Logs", "Pollen", "Stone", "Water"};

    
    private int QuestResourceInt;
    private int QuestResourceAmount;

    private string displayString;

    public TextMeshProUGUI TextObject;

    // Start is called before the first frame update
    void Start()
    {
        QuestResourceInt = PlayerPrefs.GetInt("QuestResource");
        QuestResourceAmount = PlayerPrefs.GetInt("QuestResourceAmount"); 

        displayString = QuestResourceAmount + " " + resourceTypes[QuestResourceInt];

        TextObject.text = displayString;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
