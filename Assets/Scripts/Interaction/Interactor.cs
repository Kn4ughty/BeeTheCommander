using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    // Update is called once per frame
    void Update()
    {
       //_numFound = Physics2D.OverlapCircle(_interactionPoint.position, _interactionRadius, _colliders, _interactableMask); 
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_interactionPoint.position, _interactionRadius, _interactableMask);
        _numFound = colliders.Length;
        //_colliders = colliders;

        if (_numFound > 0)
        {
            var interactable = colliders[0].GetComponent<IInteractable>();

            if (interactable != null && Input.GetKeyDown("e"))
            {
                interactable.Interact(this);
            }
        }
        
        
    }

    /// Callback to draw gizmos only if the object is selected.
    // Used to see radius of interaction
    private void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionRadius);
        /*
        Handles.color = Color.red;
        Handles.DrawWireDisc(_interactionPoint.position, new Vector3(0, 1, 0), _interactionRadius);
        */
    }

    /*

    bool InteractInput() {
        return Input.GetKeyDown(KeyCode.E);
    }
    */

}
