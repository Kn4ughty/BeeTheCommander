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
    public string[] dialogueStringArray;
    [HideInInspector]
    public string NPCNameText;
    [HideInInspector]
    public Image NPCImageComponent;

    private int stringArrayIndex;

    private void Start() {
        NPCImageComponent = NPCImageObject.GetComponent<Image>();
        dialoguePanelObject.SetActive(false);
    }

    private void Update() {
        // If the text on screen matches the stored text, turn on the continue button
        if (dialogueTextObject.text == dialogueStringArray[stringArrayIndex])
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

    private void NextLine() {
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
        }
    }

    private IEnumerator InteractCoroutine() {
        Debug.Log("Started Coroutine");


        ResetText();
        dialoguePanelObject.SetActive(true);
        StartCoroutine(Typing());


        yield return null;
    }

}
