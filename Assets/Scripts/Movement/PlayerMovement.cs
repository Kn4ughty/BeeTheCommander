using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script controls all the movement of the player including collision.
It takes the variables
offsetAngle - offset to account for angle
_speed - dictates the speed of the player
CollisonForceMagnitude - used to calculate the amount of force of collisions
Each Update(), it calls the functions
LookAtMouse() and Move()

LookAtMouse gets the world position of the mouse, 
Then to get the angle it uses trig! 
Then adds the offset angle and sets pos

Move sets the input as a vector2 for input up and down
Then does some quaternion stuff to rotate around the cursor.
Then sets the velocity to the vector * the speed

*/

public class PlayerMovement : MonoBehaviour
{
    public float offsetAngle;
    public float _speed;

    private Rigidbody2D _rigidbody;
    [SerializeField] float CollisionForceMagnitude;
    [SerializeField]
    private float MinimumDistanceToMouse;
    private Camera mainCamera;

    private Vector2 mousePos;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    // Called once per frame, we have the look at mouse tghing here to avoid jitter
    void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        LookAtMouse();
    }
    void FixedUpdate()
    {
        Move();
    }

    private void LookAtMouse()
    {
        var dir = Input.mousePosition - mainCamera.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle += offsetAngle;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
/*
    private void Move()
    {
        // Takes the input
        var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        var distanceToMouse = Vector2.Distance(transform.position, mousePos);

        // gets the forward direction in local space
        // Why do we need to even do this?
        var forwardDirection = transform.up;

        // Rotate the input vector based on the object's rotation
        // coming back to this now i have no idea what it means
        // Courtesy of ChatGPT
        var rotatedInput = Quaternion.Euler(0f, 0f, transform.eulerAngles.z) * input;


        _rigidbody.velocity = rotatedInput.normalized * _speed;
    }*/
    private void Move()
    {
        var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        var forwardDirection = transform.up;
        var rotatedInput = Quaternion.Euler(0f, 0f, transform.eulerAngles.z) * input;

        // Calculate the distance between the player and the mouse cursor
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        float distanceToMouse = Vector2.Distance(transform.position, mousePos);

        // Set a minimum distance threshold to avoid spinning around the cursor
        if (distanceToMouse > MinimumDistanceToMouse)
        {
            _rigidbody.velocity = rotatedInput.normalized * _speed;
        }
        else
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collsion:" + collision);
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 forceDirection = collision.GetContact(0).normal;
                rb.AddForce(forceDirection * CollisionForceMagnitude, ForceMode2D.Impulse);
            }

        }
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        
        if (_rigidbody != null) Gizmos.DrawRay(_rigidbody.position, _rigidbody.velocity);
    }
}