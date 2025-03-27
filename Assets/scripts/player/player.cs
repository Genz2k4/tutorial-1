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
    [SerializeField] Image health_bar;
    [SerializeField] GameObject die_prefabs;
    [SerializeField] game_manager game_manager;
    [SerializeField] audio_manager audio_manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        
        current_health = max_health;
        update_health();
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
        
        audio_manager.play_hit();

        if (current_health == 0)
        {
            die();
            game_manager.GameOver();
        }
    }

    void die()
    {
        Destroy(gameObject);
        
        var die_pre = Instantiate(die_prefabs, transform.position, Quaternion.identity);
        Destroy(die_pre, 0.5f);
        
        audio_manager.play_die();
    }

    void update_health()
    {
        current_health = Mathf.Max(0, current_health);
        health_bar.fillAmount = current_health / max_health;
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
