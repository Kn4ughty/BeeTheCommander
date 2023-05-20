using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    public Color HighlightColour = Color.green;

    private Color startcolor;

    void OnMouseEnter() {
        startcolor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = HighlightColour;
    }

    void OnMouseExit() {
        GetComponent<Renderer>().material.color = startcolor;
    }
        
}
