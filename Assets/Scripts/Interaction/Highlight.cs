using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    public Color highlightColour = Color.green;
    public float transitionTime = 1f;
    public float highlightBrightness = 1.5f; // not in use

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
        // This mess makes it so that the code below only runs when the var changes
        // This is done so that i dont remember but its important trust
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

    // works without using thjis
    // might be usefulk?
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
    // hellooooo


    private IEnumerator TransitionColor(Color targetColor)
    {
        float elapsedTime = 0f;
        Color currentColor = objectRenderer.material.color;

        while (elapsedTime < transitionTime)
        {
            
            objectRenderer.material.color = Color.Lerp(currentColor, targetColor, elapsedTime / transitionTime);
            elapsedTime += Time.deltaTime;
            yield return null;
            
        }

        objectRenderer.material.color = targetColor;
        if (targetColor == startColor)
            transitionCoroutine = null;
    }


}
