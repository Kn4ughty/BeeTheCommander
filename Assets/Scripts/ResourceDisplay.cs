using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ResourceText;
    public int pollen = 50;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ResourceText.text = "Pollen: " + pollen;

        if (!Input.GetKeyDown(KeyCode.Space))
        {
            return;
        }
        pollen++;
    }
}
