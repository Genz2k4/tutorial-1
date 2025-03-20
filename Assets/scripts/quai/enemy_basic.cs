using System;
using UnityEngine;

public class enemy_basic : enemy
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.takeDamage();
        }
    }
}
