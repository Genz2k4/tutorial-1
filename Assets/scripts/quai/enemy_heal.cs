using System;
using System.Collections;
using UnityEngine;
public class enemy_heal : enemy
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.take_damage(damage);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !is_damage)
        {
            StartCoroutine(stay_damagez());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
            is_damage = false;
        }
    }

    IEnumerator stay_damagez()
    {
        is_damage = true;

        while (true)
        {
            player.take_damage(stay_damage);
            yield return new WaitForSeconds(1f);
        }
    }
}
