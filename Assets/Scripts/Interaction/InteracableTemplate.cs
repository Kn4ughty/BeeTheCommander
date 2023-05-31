using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracableTemplate : MonoBehaviour
{
    public string InteractionPrompt { get; set; } = "Interact Text";
    public bool isInInteractionRange { get; set; }

    // for if coroutine
    private bool isInteracted = false;


    public bool Interact(Interactor interactor)
    {
        if (isInteracted)
            return false;
        // write what the thing does here

        StartCoroutine(InteractCoroutine());

        return true;
    }

    private IEnumerator InteractCoroutine()
    {
        isInteracted = true;
        
        // Do things
        
        isInteracted = false;
        // You need to return something, at some point.
        yield return true;
    }
}
