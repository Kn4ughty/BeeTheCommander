using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodHarvest : MonoBehaviour, IInteractable
{
    //public string InteractionPrompt => "Havest Wood";
    public string InteractionPrompt { get; set; } = "Harvest Wood";
    private string m_InteractionPrompt => "Havest Wood";
    public string WaitingPrompt => "Harvested, please wait for : ";


    private bool isInteracted = false;
    public float invisibilityDuration = 5f;
    private float interactionTime = 0f;

    public float promptUpdateSpeed = 0.1f;

    private Renderer objectRenderer;
    private Highlight Highlighter;

    public Color waitInteractColor;

    private void Awake()
    {
        objectRenderer = GetComponent<Renderer>();
        Highlighter = gameObject.GetComponent<Highlight>();
        Debug.Log("Helloo");
    }

    public bool Interact(Interactor interactor)
    {
        if (isInteracted)
            return false;

        Debug.Log("Interqactored!!!!!!!!!!!");
        
        StartCoroutine(InteractCoroutine());
        return true;
    }

    private IEnumerator InteractCoroutine()
    {
        isInteracted = true;
        Highlighter.highlightColour = waitInteractColor;
        // this is dumb, can be fixed by just running the function. but it works :/
        Highlighter.isHighlighted = false;
        Highlighter.isHighlighted = true;
        //objectRenderer.enabled = false; // old method

        // Wait for the specified duration
        var EndTime = Time.time + invisibilityDuration;
        while (EndTime >= Time.time)
        {
            yield return new WaitForSeconds(promptUpdateSpeed);
            var timeLeft = EndTime - Time.time;
            var timeLeftStr = timeLeft.ToString("0.##");
            InteractionPrompt = WaitingPrompt + timeLeftStr + "s";
        }
        //yield return new WaitForSeconds(invisibilityDuration);


        //Highlighter.highlightColour = Highlighter.m_highlightColour;
        Highlighter.highlightColour = Highlighter.m_highlightColour;
        Highlighter.isHighlighted = false;
        //objectRenderer.enabled = true; // old method
        isInteracted = false;

        InteractionPrompt = m_InteractionPrompt;
    }
}


    /* I have had enought of this shit omg aaa 
    // I jabe spent hors on trying to make it wait, grrggrgrfghrfrfr
    public string _prompt;
    public float disapearTime = 10f;

    float startTime;

    public bool Active;

    private bool result;

    // change to private
    public float endTime;
    public bool isCoroutineRunning;

    private void Start() {
        Active = true;
    }


    public string InteractionPrompt => _prompt;
    public bool Interact (Interactor interactor)
    {
        Debug.Log("started interaction");

        startTime = Time.time;
        
        StartCoroutine(ToggleActive(Active));

        while (isCoroutineRunning)
        {
            continue;
        }


        Debug.Log("Ended interaction");

        return true;

    }

    IEnumerator ToggleActive(bool Active)
    {        
    isCoroutineRunning = true;

    gameObject.SetActive(!Active); // Set the initial state

    yield return new WaitForSeconds(2.0f); // Wait for 2 seconds

    gameObject.SetActive(!Active); // Toggle the state

    isCoroutineRunning = false; // Set the flag to indicate that the coroutine has finished

    }
    
        if (Active)
        {
            Debug.Log("Started toggle off at timestamp : " + Time.time);
            gameObject.SetActive(false);
            Active = false;
            endTime = startTime + disapearTime;
            
            while (startTime < (disapearTime + startTime))
            {
                yield return new WaitForSeconds(1);
            }
            
            
            yield return new WaitForSeconds(disapearTime);
            gameObject.SetActive(true);
            Active = true;
            Debug.Log("Finished toggle off at timestamp : " + Time.time);
            yield return true;

        }

        isCoroutineRunning = false;
        yield break;
    
    
        else
        {
            
            //gameObject.SetActive(true);
            //Active = true;
        }
        */

    
