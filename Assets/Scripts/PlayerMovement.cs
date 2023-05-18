using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float offsetAngle;
    public float _speed;

    private Rigidbody2D _rigidbody;
    [SerializeField] float CollisionForceMagnitude;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAtMouse();
        Move();
    }

    private void LookAtMouse()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle += offsetAngle;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Move()
    {
        // Takes the input
        var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // gets the forward direction in local space
        var forwardDirection = transform.up;

        // Rotate the input vector based on the object's rotation
        // Courtesy of ChatGPT
        var rotatedInput = Quaternion.Euler(0f, 0f, transform.eulerAngles.z) * input;

        _rigidbody.velocity = rotatedInput.normalized * _speed;
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
}