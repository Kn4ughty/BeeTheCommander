using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarFill;
    public Sprite[] healthBarSprites;
    public int damageAmount;
    public int maxHealth = 10;
    public int currentHealth;

    // avoid index out of array bounds
    // Additionally could read the health from player prefs.
    public int spriteIndex = 0;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    // max health, then 1 damage goes to lowest health
    // then index OOB when it gets to end, (index = -1)
    public void UpdateHealthBar()
    {
        float healthPercentage = (float)currentHealth / maxHealth;
        spriteIndex = Mathf.Clamp(Mathf.CeilToInt(healthPercentage * (healthBarSprites.Length + 1)), 0, healthBarSprites.Length);
        healthBarFill.sprite = healthBarSprites[spriteIndex];
    }

    public void takeDamage(int damageAmount) {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Player died!!! 💀");
        }
        UpdateHealthBar();
    }

    // This doesnt make sense, the healthbar doesnt have a collider??
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            currentHealth -= damageAmount;
            if (currentHealth < 0)
            {
                currentHealth = 0;
            }

            UpdateHealthBar();
        }
    }
    */
}