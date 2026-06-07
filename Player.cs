using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro; 
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public int health=5;

    public TextMeshProUGUI healthText;
    
    void Start()
    {
        UpdateHealthUI();
    }
   
    
    void Update()
    {
        
    }

    public virtual void TakeDamage(int damage){
    
        health -= damage;

        Debug.Log("Player took DMG");

        UpdateHealthUI();

        if (health <= 0){
        
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health;
        }
    }

    public void Heal(int healAmount)
    {
        health += healAmount;

        
        if (health > 5)
        {
            health = 5;
        }

        
        UpdateHealthUI();
        Debug.Log("Player healed! Health is now: " + health);
    }

    
}
