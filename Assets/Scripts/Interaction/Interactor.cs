using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private InteractionPromptUI _interactionPromptUI;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    private Highlight highlight; // Declare the 'highlight' variable here
    private Collider2D LastInteractable = null; // help

    private IInteractable _interactable;


    void Update()
    {
       // Gets an array of objects in the interaction radius
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_interactionPoint.position, _interactionRadius, _interactableMask);

        _numFound = colliders.Length; // Used for debugging

        if (_numFound > 0)
        {
            // Gets interactable thing
            _interactable = colliders[0].GetComponent<IInteractable>();

            // Sets and gets the highlting variable
            highlight = colliders[0].GetComponent<Highlight>();
            highlight.isHighlighted = true;



            if (_interactable != null)
            {
                if (!_interactionPromptUI.IsDisplayed) _interactionPromptUI.SetUp(_interactable.InteractionPrompt);

                if (Input.GetKeyDown("e")) _interactable.Interact(this);
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
            highlight = LastInteractable.GetComponent<Highlight>();
            highlight.isHighlighted = false;
            // if (_interactable != null) _interactable = null;
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
