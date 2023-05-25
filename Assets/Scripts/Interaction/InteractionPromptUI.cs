using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionPromptUI : MonoBehaviour
{
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private TextMeshProUGUI _promptText;

 
    private void Start()
    {
        _uiPanel.SetActive(false);

    }

    public bool IsDisplayed = false;

    public void SetUp(string promptText, Vector3 location)
    {
        _promptText.text = promptText;
        _uiPanel.SetActive(true);

        _uiPanel.transform.position = location;

        IsDisplayed = true;
    }

    public void UpdatePrompt(string promptText)
    {
        _promptText.text = promptText;
    }

    public void Close() 
    {
        _uiPanel.SetActive(false);
        IsDisplayed = false;
    }

    /*
    // This code was for 3d game
    private Camera _mainCam;



    private void Start()
    {
        _mainCam = Camera.main;
    }


    private void LateUpdate()
    {
        var rotation = _mainCam.transform.rotation;
        transform.LookAt(transform.position + rotation *
    }
    */
}
