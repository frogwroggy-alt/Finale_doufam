using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    public int damage;

    public float detectionRange = 12f;

    public GameObject bloodEffect;
    private Transform playerTransform;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null) {
            playerTransform = player.transform;

               }
    }



    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
           Destroy(gameObject);

        }
            if (playerTransform != null){
    
        float distance = Vector2.Distance(transform.position, playerTransform.position);

        if (distance <= 12f){
        
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }


    }


    public virtual void TakeDamage(int damage){
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("damage TAKEN !");
    }



    private void OnCollisionEnter2D(Collision2D collision){

    if (collision.gameObject.CompareTag("Player")){
    
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null){
        
            player.TakeDamage(damage);
        }
    }
}
}
