using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarFill;
    public Sprite[] healthBarSprites;
    public int damageAmount;
    public int maxHealth = 10;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float healthPercentage = (float)currentHealth / maxHealth;
        int spriteIndex = Mathf.Clamp(Mathf.CeilToInt(healthPercentage * (healthBarSprites.Length + 1)), 0, healthBarSprites.Length + 1);
        healthBarFill.sprite = healthBarSprites[spriteIndex];
    }
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
}