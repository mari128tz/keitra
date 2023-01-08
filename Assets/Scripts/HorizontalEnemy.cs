using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalEnemy : MonoBehaviour
{
    public float speed = 0.8f;
    public float range = 3;

    Collider2D col;

    float startingX;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        startingX = transform.position.x;
        col = GetComponent<Collider2D>();
    }

    // FixedUpdate to make the transitions smoother
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime * direction);
        //invert the direction
        if (transform.position.x < startingX || transform.position.x > startingX + range)
            direction *= -1; //invert the direction
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RightWall"))
            transform.localScale = new Vector2(-1f, transform.localScale.y);
        if (collision.gameObject.CompareTag("LeftWall"))
            transform.localScale = new Vector2(1f, transform.localScale.y);
    }
}
