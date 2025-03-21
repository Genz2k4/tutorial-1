using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    Vector2 move;
    Rigidbody2D rb;
    Animator ani;
    SpriteRenderer sp;
    
    [SerializeField] float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        /*ani = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();*/
    }

    // Update is called once per frame
    void Update()
    {
        /*if (move != Vector2.zero)
        {
            ani.SetBool("is_run", true);
        }
        else
        {
            ani.SetBool("is_run", false);
        }*/

        /*if (move.x > 0)
        {
            sp.flipX = false;
        }
        else if (move.x < 0)
        {
            sp.flipX = true;
        }*/
    }

    void FixedUpdate()
    {
        rb.linearVelocity = move.normalized * speed;
    }

    void OnMove(InputValue input)
    {
        move = input.Get<Vector2>();
    }

    public void takeDamage()
    {
        die();
    }

    void die()
    {
        Destroy(gameObject);
    }
}
