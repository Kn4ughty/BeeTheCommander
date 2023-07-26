using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Highlight))]
public class HarvestInteractable : MonoBehaviour, IInteractable, ICollectable
{
    // For some reason in order to make the values accesable 
    // to the inspector it needs to have that jargon out front

    //[Header("Resource amounts")] // unity cries
    [field: SerializeField] public int pollenAmount { get; set; } = 0;
    [field: SerializeField] public int woodAmount { get; set; } = 0;
    [field: SerializeField] public int waterAmount { get; set; } = 0;
    [field: SerializeField] public int stoneAmount { get; set; } = 0;

    //[Header("Ui prompts")]
    [field: SerializeField] public string InteractionPrompt { get; set; } = "Harvest Wood";
    public string m_InteractionPrompt;
    public string WaitingPrompt => "Harvested, please wait for : ";

    //[Header("Other data")]
    public bool isInInteractionRange {get; set; }


    private bool isInteracted = false;
    public float invisibilityDuration = 5f;
    //private float interactionTime = 0f;

    public float promptUpdateSpeed = 1f;

    private Renderer objectRenderer;
    // Highlighting is good.
    private Highlight Highlighter;
    //private Coroutine transitionCoroutine;


    public Color waitInteractColor = Color.green;

    private void Awake()
    {
        isInInteractionRange = false;
        objectRenderer = GetComponent<Renderer>();
        Highlighter = gameObject.GetComponent<Highlight>();
        Debug.Log("Components Ready To Be Modified");
        m_InteractionPrompt = InteractionPrompt;
    }

    public bool Interact(Interactor interactor)
    {
        if (isInteracted)
            return false;
        
        StartCoroutine(InteractCoroutine());
        return true;
    }

    private IEnumerator InteractCoroutine()
    {
        isInteracted = true;
        
        //Highlighter.highlightColour = waitInteractColor;
        // this is dumb, can be fixed by just running the function. but it works :/
        //Highlighter.isHighlighted = false;
        //Highlighter.isHighlighted = true;
        objectRenderer.enabled = false; // old method, but works
        

        // Wait for the specified duration
        var EndTime = Time.time + invisibilityDuration;
        while (EndTime >= Time.time)
        {
            yield return new WaitForSeconds(promptUpdateSpeed);
            var timeLeft = EndTime - Time.time;
            var timeLeftStr = timeLeft.ToString("0.#");
            InteractionPrompt = WaitingPrompt + timeLeftStr + "s";
        }
        //yield return new WaitForSeconds(invisibilityDuration);

        
        //Highlighter.highlightColour = Highlighter.startColor;
        //Highlighter.isHighlighted = false;
        //Highlighter.highlightColour = Highlighter.m_highlightColour;
        //Highlighter.isHighlighted = false;
        
        objectRenderer.enabled = true; // old method
        isInteracted = false;

        InteractionPrompt = m_InteractionPrompt;
    }
}

