using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public HealthBar healthBar;
    private float distance;
    private int currentHealth;
    public int damageAmount;
    public float distanceBetween;


    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        TakeDamage(damageAmount);
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("entered collision.");
        if (collision.gameObject.CompareTag("Player")) {
            healthBar.takeDamage(damageAmount);
        }
    }
    */

    private void OnCollisionEnter2D(Collision2D collision) {
        //Debug.Log("Collsion:" + collision);
        if (collision.gameObject.CompareTag("Player"))
        {
            healthBar.takeDamage(damageAmount);
        }

    }

}
