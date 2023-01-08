using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalEnemy : MonoBehaviour
{
    public float speed = 0.8f;
    public float range = 3;

    float startingY;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        startingY = transform.position.y;
    }

    // FixedUpdate to make the transitions smoother
    void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime * direction);
        if (transform.position.y < startingY || transform.position.y > startingY + range)
            direction *= -1; //invert the direction
    }
}
