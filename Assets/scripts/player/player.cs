using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    Vector2 move;
    Rigidbody2D rb;
    Animator ani;
    SpriteRenderer sp;
    
    [SerializeField] float speed, max_health, current_health;
    [SerializeField] int score;
    [SerializeField] Image health_bar;
    [SerializeField] TextMeshProUGUI score_text;
    [SerializeField] GameObject die_prefabs;
    [SerializeField] gamemanager gamemanager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        
        current_health = max_health;
        update_health();

        score_text.text = $"score: {score}";
    }

    // Update is called once per frame
    void Update()
    {
        if (move != Vector2.zero)
        {
            ani.SetBool("is_run", true);
        }
        else
        {
            ani.SetBool("is_run", false);
        }

        if (move.x > 0)
        {
            sp.flipX = false;
        }
        else if (move.x < 0)
        {
            sp.flipX = true;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = move.normalized * speed;
    }

    void OnMove(InputValue input)
    {
        move = input.Get<Vector2>();
    }

    public void take_damage(float damage)
    {
        current_health -= damage;
        update_health();

        if (current_health == 0)
        {
            die();
        }
    }

    void die()
    {
        Destroy(gameObject);
        
        var die_pre = Instantiate(die_prefabs, transform.position, Quaternion.identity);
        Destroy(die_pre, 0.5f);
        
        gamemanager.game_over();
    }

    void update_health()
    {
        health_bar.fillAmount = current_health / max_health;
    }

    public void add_score()
    {
        score ++;
        score_text.text = $"score: {score}";
    }

    public void heal(float heal)
    {
        if (current_health < max_health)
        {
            current_health += heal;

            if (current_health > max_health)
            {
                current_health = max_health;
            }
            update_health();
        }
    }
}
