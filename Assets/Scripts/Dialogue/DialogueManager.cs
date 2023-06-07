using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


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
    public string[] dialogueStringArray = {"Balls"};
    [HideInInspector]
    public string NPCNameString;
    [HideInInspector]
    public Sprite NPCImage;
    [HideInInspector]
    public Image NPCImageComponent;


    public delegate void FinishedTalkingDelegate();
    public static event FinishedTalkingDelegate FinishedTalking;


    private int stringArrayIndex = 0;

    private void Start() {
        NPCImageComponent = NPCImageObject.GetComponent<Image>();
        dialoguePanelObject.SetActive(false);
    }

    private void Update() {
        // If the text on screen matches the stored text, turn on the continue button
        // And the index is not greater than the size of the array
        if (stringArrayIndex < dialogueStringArray.Length && dialogueTextObject.text == dialogueStringArray[stringArrayIndex])
            continueButtonObject.SetActive(true);
        
    }

    public void ResetText() {
        Debug.Log("Reseting dialogue text");
        dialogueTextObject.text = "";
        stringArrayIndex = 0;
        //dialoguePanel.SetActive(false);
    }

    IEnumerator Typing() {
        foreach(char letter in dialogueStringArray[stringArrayIndex].ToCharArray())
        {
            dialogueTextObject.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine() {
        Debug.Log("NextLine is running");
        continueButtonObject.SetActive(false);

        if(stringArrayIndex < dialogueStringArray.Length -1)
        {
            stringArrayIndex++;
            dialogueTextObject.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            ResetText();
            dialoguePanelObject.SetActive(false);
            // need to set source object isinteracterd false here
            FinishedTalking.Invoke();
        }
    }

    public IEnumerator InteractCoroutine() {
        Debug.Log("Started Coroutine");


        NPCImageComponent.sprite = NPCImage;
        NPCNameObject.text = NPCNameString;
        ResetText();


        dialoguePanelObject.SetActive(true);
        StartCoroutine(Typing());


        yield return null;
    }
}
