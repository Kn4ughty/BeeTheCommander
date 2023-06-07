using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPC : MonoBehaviour, IInteractable
{
    // [Header("Interaction UI")]
    public string InteractionPrompt { get; set; } = "Interact"; //Prompt that comes up when before interacting with
    public bool isInInteractionRange {get; set; }

    [Header("Dialogue Information")]
    public string NPCNameText = "NPCName";
    public string[] dialogueStringArray = {"lorem", "ipsum"};
    public Sprite NPCImage;

    public DialogueManager DialogueManager;


    public bool isInteracted = false;

    private void Start() {

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

        DialogueManager.NPCNameText = NPCNameText;
        DialogueManager.dialogueStringArray = dialogueStringArray;
        DialogueManager.NPCImage = NPCImage;

        StartCoroutine(DialogueManager.InteractCoroutine());

        yield return null;
    }
}
