using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public int respawn;
    public int health = 3;
    private int speed;
    private Rigidbody2D rb;
    public bool canJump = false;
    private float horizontalInput;
    public Animator animator;
    private int delay = 4;
    private float timer = 0.0f;
    private float timeToGameOver = 2.0f;
    
    bool facingRight = true;

    public float jump = 10;

    [SerializeField] private GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (health == 0)
        {
            // Chama a fun��o Dead.
            Dead();
        }
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            Debug.Log("jumped");
            animator.SetBool("IsJumping", true);
            canJump = false;
        }
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
            characterScale.x = -1;
        if (Input.GetAxis("Horizontal") > 0)
            characterScale.x = 1;
        transform.localScale = characterScale;
        
        
    }

    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            canJump = true;
            animator.SetBool("IsJumping", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 1;
            Debug.Log(health);
        }
    }


    //Activate the canvas
    void Dead()
    {
        Debug.Log("You died !");
        canvas.SetActive(true);
    }

    //Button restart
    public void PlayerDied()
    {
        animator.SetBool("IsDead", false);
        SceneManager.LoadScene("SampleScene");
    }
}
