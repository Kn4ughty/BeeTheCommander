using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// For this code, i have decided to use highly descriptive,
// but long variable names to make the code easier to understand
// Update: i gave up on this lmao
// private bool schamble = false; private bool swhimble = true;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue Canvas Objects")]
    public GameObject dialoguePanelObject;
    public TextMeshProUGUI dialogueTextObject;
    public TextMeshProUGUI NPCNameObject;
    public GameObject NPCImageObject;

    [Header("Buttons")]
    public GameObject continueButtonObject;
    public GameObject buttonOptionsObject;

    [Header("Dialogue resources")]
    public GameObject playerBee;
    private PlayerMovement PlayerMovementComponent;

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
    [HideInInspector]
    public bool hasOptionButtons = false; // Set false in case forgorten


    private string[] resourceTypes = {"logs", "pollen", "stone", "water"};
    private string requestString;
    [HideInInspector]
    public string SelectedResource;
    [HideInInspector]
    public int SelectedResourceNum;
    [HideInInspector]
    public int SelectedResourceAmount;
    private bool schamble = false;
    private bool swhimble = true;

    public delegate void FinishedTalkingDelegate();
    public static event FinishedTalkingDelegate FinishedTalking;


    private int stringArrayIndex = 0;

    private float StartLineTime;
    private float endLineTime;

    private void Start() {
        NPCImageComponent = NPCImageObject.GetComponent<Image>();
        dialoguePanelObject.SetActive(false);
        PlayerMovementComponent = playerBee.GetComponent<PlayerMovement>();
    }

    private void Update() {

        if (StartLineTime != null && endLineTime != null && Time.time >= endLineTime) {
            continueButtonObject.SetActive(true);
        }

        // If the text on screen matches the stored text, turn on the continue button
        // And the index is not greater than the size of the array
        if (stringArrayIndex < dialogueStringArray.Length && dialogueTextObject.text == dialogueStringArray[stringArrayIndex])
            continueButtonObject.SetActive(true);

            // a
            if(stringArrayIndex == dialogueStringArray.Length -1 && hasOptionButtons) // last one before the end.
            {
                if (isQuestCompleted()) {
                    buttonOptionsObject.SetActive(true);
                    continueButtonObject.SetActive(false);
                    dialogueStringArray[stringArrayIndex] = requestString;
                if (schamble && swhimble) { // deal with the names
                    // the variable things are so that this only runs once and not every frame
                    // first one is is when text reset
                    // swimble is when thing. Idk this works cope

                    SelectedResourceNum = Random.Range(0, 3);
                    SelectedResource = resourceTypes[SelectedResourceNum];
                    SelectedResourceAmount = Random.Range(5, 20);
                    // result : Fetch me 15 water.
                    requestString = "Be quick! Fetch me " + SelectedResourceAmount + " " + SelectedResource;
                    // to do write this to playerprefs.
                    Debug.Log("Swambled");
                    dialogueTextObject.text = requestString;
                    swhimble = false;

                    Debug.Log(SelectedResource);
                    Debug.Log(SelectedResourceAmount);

                }
                }
                else {
                    // (quest is not completed)
                    buttonOptionsObject.SetActive(false);
                    continueButtonObject.SetActive(true);

                    dialogueTextObject.text = "You have not completed your quest! Come back to me later";
                }



                
            }
            //This is a check if you have resources for the quest, and then removes them.
    }
    
    // First code run.
    public IEnumerator InteractCoroutine() {
        Debug.Log("Started Coroutine");


        NPCImageComponent.sprite = NPCImage;
        NPCNameObject.text = NPCNameString;
        ResetText();


        dialoguePanelObject.SetActive(true);
        buttonOptionsObject.SetActive(false);
        StartLineTime = Time.time;
        endLineTime = StartLineTime + 5f;
        StartCoroutine(Typing());
        schamble = true;

        // Stop player movement
        PlayerMovementComponent._speed = 0;

        yield return null;
    }


    public void ResetText() {
        schamble = false;
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
        StartLineTime = Time.time;
        endLineTime = StartLineTime + 5f;
        Debug.Log("NextLine is running");
        continueButtonObject.SetActive(false);


        if(stringArrayIndex < dialogueStringArray.Length -1)
        {
            stringArrayIndex++;
            dialogueTextObject.text = "";
            StartCoroutine(Typing());
            
        }
        else // There are no more lines | end of talking
        {
            ResetText();
            dialoguePanelObject.SetActive(false);
            // movement speed hardcoded cope
            PlayerMovementComponent._speed = 10;

            // need to set source object isinteracterd false here
            FinishedTalking.Invoke();
        }
    }

    public void Option(bool isAccepted) {
        if (isAccepted) {
            int QuestNumber = PlayerPrefs.GetInt("QuestNumber");
            if (QuestNumber == 0) {
                PlayerPrefs.SetInt("QuestNumber", 1);
            }
            else {
                QuestNumber = QuestNumber + 1;
                PlayerPrefs.SetInt("QuestNumber", QuestNumber);
            }
            
            QuestNumber = PlayerPrefs.GetInt("QuestNumber");
            //dialogueTextObject.text += "quest numbre: " + QuestNumber.ToString();
            PlayerPrefs.SetInt("QuestResource", SelectedResourceNum);
            PlayerPrefs.SetInt("QuestResourceAmount", SelectedResourceAmount);
            Debug.Log(QuestNumber + "Weewoo!!!");
        }
        else {
            Debug.Log("Declined");
        }

        ResetText();
        PlayerMovementComponent._speed = 10;
        dialoguePanelObject.SetActive(false);
        FinishedTalking.Invoke();
    }

    public bool isQuestCompleted() {
        Debug.Log("is quest complted " + PlayerPrefs.GetInt("QuestResourceAmount"));
        Debug.Log("is quest complted " + PlayerPrefs.GetInt("QuestResource"));
        Debug.Log(PlayerPrefs.GetInt("WoodAmount"));
        Debug.Log(PlayerPrefs.GetInt("PollenAmount"));
        Debug.Log(PlayerPrefs.GetInt("StoneAmount"));
        Debug.Log(PlayerPrefs.GetInt("WaterAmount"));
        

        switch (PlayerPrefs.GetInt("QuestResource")) {
            case 0:
                // logs
                // greater than or equal to
                if (PlayerPrefs.GetInt("WoodAmount") >= PlayerPrefs.GetInt("QuestResourceAmount")) {
                    return true;
                }
                else {
                    return false;
                }
            case 1:
                //pollen
                if (PlayerPrefs.GetInt("PollenAmount") >= PlayerPrefs.GetInt("QuestResourceAmount")) {
                    return true;
                }
                else {
                    return false;
                }
            case 2:
                //stone
                if (PlayerPrefs.GetInt("StoneAmount") >= PlayerPrefs.GetInt("QuestResourceAmount")) {
                    return true;
                }
                else {
                    return false;
                }
            case 3:
                //water
                if (PlayerPrefs.GetInt("WaterAmount") >= PlayerPrefs.GetInt("QuestResourceAmount")) {
                    return true;
                }
                else {
                    return false;
                }

            default:
                Debug.LogError("How did we get here? You ran this when there was no quest resource and it went wahaha");
                return false;
        }
    }

}