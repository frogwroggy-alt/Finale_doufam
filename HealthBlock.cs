using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class HealthBlock : MonoBehaviour
{
   public int healAmount = 1;


    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
    
        if (other.CompareTag("Player")){
        
            Player player = other.GetComponent<Player>();

            if (player != null){
            
                player.Heal(healAmount);
            }

            Destroy(gameObject);
        }
    }
}
