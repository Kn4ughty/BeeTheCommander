using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
This code sucks
I dont like it
It will do

How to improve it tho
- Make highlighting an optional component
- Make highlting have its smooth transition
- Buttom prompt ui?
    - When will image state change
    - When pressed
    - But the image only needs to be there before its pressed
    - Then what is the pressed down image for?
    - Having it stick around is dumb
    - How about it stays pressed down until liften off, then disapears?
    - That would leave an empty area where it used to be
    - Recenting text would be jaring
    - Im ditching the keyboard input button down. It will just show "E"
*/

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private InteractionPromptUI _interactionPromptUI;

    private readonly Collider[] _colliders = new Collider[3];
    private int _numFound;

    //private Highlight highlight; // Declare the 'highlight' variable here
    private Collider2D LastInteractable = null; // help

    private IInteractable _interactable;
    private ICollectable _collectable;

    private int bagel = 0;

    // Should read data for info, but we dont have data to read yet
    // private int pollen = 0;
    // private int wood = 0;
    // private int water = 0;
    // private int stone = 0;

    [Header("UI Text")]
    [SerializeField] private Text pollenText;
    [SerializeField] private Text woodText;
    [SerializeField] private Text waterText;
    [SerializeField] private Text stoneText;


    void Update()
    {
       // Gets an array of objects in the interaction radius
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_interactionPoint.position, _interactionRadius, _interactableMask);

        _numFound = colliders.Length; // Used for debugging

        if (_numFound > 0)
        {
            // Gets interactable thing
            _interactable = colliders[0].GetComponent<IInteractable>();

            _collectable = colliders[0].GetComponent<ICollectable>();
            if (_collectable != null) {
                //shwangle
            }
            // Sets and gets the highlting variable
            //highlight = colliders[0].GetComponent<Highlight>();
            //highlight.isHighlighted = true;
            _interactable.isInInteractionRange = true;



            if (_interactable != null)
            {
                if (!_interactionPromptUI.IsDisplayed) _interactionPromptUI.SetUp(_interactable.InteractionPrompt, colliders[0].transform.position);
                if (_interactionPromptUI.IsDisplayed) _interactionPromptUI.UpdatePrompt(_interactable.InteractionPrompt);

                if (Input.GetKeyDown("e")) {
                    _interactable.Interact(this);

                    if (_collectable != null) {

                    // bagel bagel
                    bagel = _collectable.pollenAmount + PlayerPrefs.GetInt("pollenAmount");
                    pollenText.text = "Pollen: " + bagel;
                    PlayerPrefs.SetInt("PollenAmount", bagel);

                    bagel = _collectable.woodAmount + PlayerPrefs.GetInt("WoodAmount");
                    woodText.text = "Wood: " + bagel;
                    PlayerPrefs.SetInt("WoodAmount", _collectable.woodAmount);

                    bagel = _collectable.waterAmount + PlayerPrefs.GetInt("WaterAmount");
                    waterText.text = "Water: " + bagel;
                    PlayerPrefs.SetInt("WaterAmount", bagel);

                    bagel = _collectable.stoneAmount + PlayerPrefs.GetInt("StoneAmount");
                    pollenText.text = "Stone: " + bagel;
                    PlayerPrefs.SetInt("StoneAmount", bagel);
                    // StoneAmount? I hardly know her! 
                    }
                }
            }
            /*
            if (_interactable != null && Input.GetKeyDown("e"))
            {
                // Runs the interact function
                _interactable.Interact(this);
            }
            */
            
            // this is used so that the highlighting can be turned off when no longer in range
            LastInteractable = colliders[0];
        }
        else if (LastInteractable != null) // avoids null reference exception
        {
            //highlight = LastInteractable.GetComponent<Highlight>();
            //highlight.isHighlighted = false;
            if (_interactionPromptUI.IsDisplayed) _interactionPromptUI.Close();
            
        }
        /*
        else
        {
            if (_interactable != null) _interactable = null;
            if (_interactionPromptUI.IsDisplayed) _interactionPromptUI.Close();
        }
        */
        
    }

    /// Callback to draw gizmos only if the object is selected.
    // Used to see radius of interaction
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionRadius);

    }

}
