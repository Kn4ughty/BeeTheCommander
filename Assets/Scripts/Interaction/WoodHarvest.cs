using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodHarvest : MonoBehaviour, IInteractable
{
    public string _prompt;

    public string InteractionPrompt => _prompt;
    public bool Interact (Interactor interactor)
    {
        Debug.Log("Loggey logs");
        return true;
    }
}
