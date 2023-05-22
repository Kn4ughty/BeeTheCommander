using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    public Color highlightColour = Color.green;
    public float transitionTime = 1f;
    public float highlightBrightness = 1.5f; // Adjust this value to control the brightness

    public bool isHighlighted;
    private bool m_isHighlighted = false;

    private Color startColor;
    private Color targetColor;

    private Coroutine transitionCoroutine;
    private Renderer objectRenderer;


    public delegate void OnVariableChangeDelegate(bool newVal);
    public event OnVariableChangeDelegate OnVariableChange;

    private void Update()
    {
        /*
        if (isHighlighted)
        {
            transitionCoroutine = StartCoroutine(TransitionColor(highlightColour));
        }
        else 
        {
            transitionCoroutine = StartCoroutine(TransitionColor(startColor));
        }
        */
        if (isHighlighted != m_isHighlighted && OnVariableChange != null)
        {
            m_isHighlighted = isHighlighted;
            OnVariableChange(isHighlighted);
            if (isHighlighted)
            {
                transitionCoroutine = StartCoroutine(TransitionColor(highlightColour));
            }
            else 
            {
                transitionCoroutine = StartCoroutine(TransitionColor(startColor));
            }
        }
    }

    void HandleVariableChange(bool newVal)
    {
    // Handle the variable change here
    // You can access the new value through the newVal parameter
    // ...
    }


    // ChatGPT

    private void Start() {
        objectRenderer = GetComponent<Renderer>();
        startColor = objectRenderer.material.color;
        OnVariableChange += HandleVariableChange;
    }
    // hellooooo i love youuuuuuu pretty girlll

    private void OnMouseEnter()
    {

        if (transitionCoroutine != null)
            StopCoroutine(transitionCoroutine);

        isHighlighted = true;

    }

    private void OnMouseExit()
    {
        if (transitionCoroutine != null)
            StopCoroutine(transitionCoroutine);

        //transitionCoroutine = StartCoroutine(TransitionColor(startColor));
        isHighlighted = false;
    }
    /*
    private void OnMouseEnter()
    {

        if (transitionCoroutine != null)
            StopCoroutine(transitionCoroutine);

        transitionCoroutine = StartCoroutine(TransitionColor(highlightColour));
    }

    private void OnMouseExit()
    {
        if (transitionCoroutine != null)
            StopCoroutine(transitionCoroutine);

        transitionCoroutine = StartCoroutine(TransitionColor(startColor));
    }
    */

    private IEnumerator TransitionColor(Color targetColor)
    {
        float elapsedTime = 0f;
        Color currentColor = objectRenderer.material.color;

        while (elapsedTime < transitionTime)
        {
            
            objectRenderer.material.color = Color.Lerp(currentColor, targetColor, elapsedTime / transitionTime);
            elapsedTime += Time.deltaTime;
            yield return null;
            

            /*
            // Calculate the interpolated color
            Color lerpedColor = Color.Lerp(currentColor, targetColor * highlightBrightness, elapsedTime / transitionTime);
            
            // Apply brightness adjustment
            Color adjustedColor = lerpedColor; //* highlightBrightness;
            
            objectRenderer.material.color = adjustedColor;
            
            elapsedTime += Time.deltaTime;
            yield return null;
            */
        }

        objectRenderer.material.color = targetColor;
        if (targetColor == startColor)
            transitionCoroutine = null;
    }



/* My code

    void OnMouseEnter() {
        startcolor = GetComponent<Renderer>().material.color;
        
        Color desiredColor = HighlightColour;
        Color smoothedColor = Color.Lerp(GetComponent<Renderer>().material.color, HighlightColour, TransitionTime);

        GetComponent<Renderer>().material.color = smoothedColor;
    }

    void OnMouseExit() {
        GetComponent<Renderer>().material.color = startcolor;
    }
    */
}
