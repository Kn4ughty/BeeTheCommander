using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public HealthBar healthBar;
    private float distance;
    private int currentHealth;
    public int damageAmount; 


    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
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
