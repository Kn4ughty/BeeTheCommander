using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour, IInteractable
{
    public string InteractionPrompt { get; set; } = "Interact"; //Prompt that comes up when before interacting with
    public bool isInInteractionRange {get; set; }

    public bool isInteracted = false;

    public GameObject dialoguePanel;
    // public Text dialogueText;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;
    public float wordSpeed;

    public GameObject contButton;


    private void Start() {
        dialoguePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }
    }

    public void ResetText()
    {
        Debug.Log("ResetText function Running");
        dialogueText.text = "";
        index = 0;
        //dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        Debug.Log("Next line is running");
        contButton.SetActive(false);

        if(index < dialogue.Length -1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            ResetText();
            dialoguePanel.SetActive(false);
            isInteracted = false;
        }
    }

    public bool Interact(Interactor interactor) //function runs when interacted with
    {
        if (isInteracted)
            return false;

        Debug.Log("Interacted with NPC");

        dialoguePanel.SetActive(true);
        StartCoroutine(InteractCoroutine());
        
        return true; //end function
    }

    private IEnumerator InteractCoroutine()
    {
        Debug.Log("Started Coroutine");

        isInteracted = true;
        

        // Is the reset text function nessecary?
        /*
        if (dialoguePanel.activeInHierarchy)
        {
            ResetText();
        }
        else
        {
            dialoguePanel.SetActive(true);
            StartCoroutine(Typing());
        }
        */
        
        /*
        ResetText();
        dialoguePanel.SetActive(true);
        */
        ResetText();
        dialoguePanel.SetActive(true);
        StartCoroutine(Typing());

        
        //Debug.Log("Setting Activing false at end of interaction");
        //dialoguePanel.SetActive(false);

        yield return null;
    }
}
