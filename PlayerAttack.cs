using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float  startTimeBtwAttack;   

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(timeBtwAttack <= 0) {

         if(Input.GetKey(KeyCode.Space)){
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies );
            for(int i=0; i<enemiesToDamage.Length; i++){
             enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
            }
         }

        timeBtwAttack =startTimeBtwAttack;
       }

       else{
        timeBtwAttack -= Time.deltaTime;
       }

    }
    void OnDrawGizmosSelected()
    {
      Gizmos.color = Color.red;
     UnityEngine.Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
