using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Boss : Enemy
{
   public int thornExplosionDamage = 2;
    public int thornBurstDamage = 1;

    private int turnCounter = 0;
    private int maxHealth;

    private Player player;

    void Awake()
    {
        maxHealth = health;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if(playerObj != null)
        {
            player = playerObj.GetComponent<Player>();
        }
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        
        if(player != null)
        {
            int reflectedDamage = Mathf.Max(1, damage / 3);
            player.TakeDamage(reflectedDamage);

            Debug.Log("Thornhost reflected " + reflectedDamage + " damage!");
        }
    }

    
    public void EndTurn()
    {
        turnCounter++;

        
        if(turnCounter % 2 == 0)
        {
            ThornBurst();
        }

        
        if(health <= maxHealth * 0.3f)
        {
            ThornExplosion();
        }
    }

    private void ThornBurst()
    {
        Debug.Log("THORN BURST!");

        if(player != null)
        {
            player.TakeDamage(thornBurstDamage);
        }
    }

    private void ThornExplosion()
    {
        Debug.Log("THORN EXPLOSION!");

        if(player != null)
        {
            player.TakeDamage(thornExplosionDamage);
        }

        health -= thornExplosionDamage;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
