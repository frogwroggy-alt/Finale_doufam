using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public float speed;
   private float Move;
   private Rigidbody2D rb;

    private Vector2 movemnet;
    
    void Start()
    {
     rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(Move * speed, rb.linearVelocity.y);
       
    }

    
    




        

    }
