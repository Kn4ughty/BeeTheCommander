using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// For this code, i have decided to use highly descriptive,
// but long variable names to make the code easier to understand

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue Canvas Objects")]
    public GameObject dialoguePanelObject;
    public TextMeshProUGUI dialogueTextObject;
    public TextMeshProUGUI NPCNameObject;

    public GameObject NPCImageObject;

    public GameObject continueButtonObject;

    [Header("Display Settings")]
    public float wordSpeed = 0.3f;

    [HideInInspector]
    public string[] dialogueStringArray;
    [HideInInspector]
    public string NPCNameText;

    private int stringArrayIndex;

    private void Start() 
    {
        //NPCImageComponent = NPCImageObject.GetComponent<Image>();
        dialoguePanelObject.SetActive(false);
    }

    private void Update() {
        if (dialogueTextObject.text == dialogueStringArray[stringArrayIndex])
        continueButtonObject.SetActive(true);
    }
}
