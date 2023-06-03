using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour, IInteractable //This shit mean it interact
{
    public string InteractionPrompt { get; set; } = "Interact"; //Prompt that comes up when before interacting with
    public bool isInInteractionRange {get; set; }

    private bool isInteracted = false;

    public GameObject dialoguePanel;
    // public Text dialogueText;
    [SerializeField] private TextMeshProUGUI dialogueText;
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
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
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
        }
    }

    public bool Interact(Interactor interactor) //function runs when interacted with
    {
        if (isInteracted)
            return false;

        Debug.Log("Interacted with NPC");

        StartCoroutine(InteractCoroutine());
        
        return true; //end function
    }

    private IEnumerator InteractCoroutine()
    {
        Debug.Log("Started Coroutine");
        isInteracted = true;
        
        /* this doesnt work :(
        Debug.Log("about to set active");
        dialoguePanel.SetActive(true);
        Debug.Log("Should be active now");
        */
        if (dialoguePanel.activeInHierarchy)
        {
            ResetText();
        }
        else
        {
            dialoguePanel.SetActive(true);
            StartCoroutine(Typing());
        }
        ResetText();
        
        isInteracted = false;

        yield return null;
    }
}
