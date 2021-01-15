using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public static int currentHealth;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <=0)
        {
            // LOSE
            Debug.Log("Lose");
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        int layer = other.gameObject.layer;
        switch (layer)
        {
            case 8:
            TakeDamage(25);
            break;
            case 13:
            TakeDamage(20);
            break;
        }
        
    }
}
