using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int speed;
    private Rigidbody2D rb;
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private bool isGround;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start running the script!");
        speed = 5;
        // Take the Rigidbody component
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Saving the horizontal movement
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {   // Verify if the space key was pressed
            jumpKeyWasPressed = true;
        }

    }

    // FixeUpdate is called once ever physics update
    private void FixedUpdate()
    {
        // Update horizontal movement
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        if (isGround == true)
        {   // If player is on the ground - it can jump
            if (jumpKeyWasPressed)
            {   // Update vertical movement - Jump
                //rb.velocity = new Vector2(rb.velocity.x, speed);}}
                // Other way to update the vertical movement - Add a vertical force
                rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
                jumpKeyWasPressed = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   // If the player enters a collision then is on the platform
        isGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {   // If the player exit the collision, then is on air - can't jump
        isGround = false;
    }
}