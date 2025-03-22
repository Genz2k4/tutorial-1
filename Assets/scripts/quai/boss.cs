using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class boss : enemy
{
    [SerializeField] float time;
    [SerializeField] int bullet_count, min, max;
    [SerializeField] GameObject bullet_prefab;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(skill());
    }
    
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
            StopCoroutine(stay_damagez());
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

    void dich_chuyen()
    {
        if (current_health > 0)
        {
            transform.position = player.transform.position;
        }
    }

    void dan_toa()
    {
        if (current_health > 0)
        {
            var angleStep = 360f / bullet_count;
            var angle = 0f;

            for (int i = 0; i < bullet_count; i++)
            {
                var bulletDirX = Mathf.Sin(angle * Mathf.Deg2Rad);
                var bulletDirY = Mathf.Cos(angle * Mathf.Deg2Rad);
                var bulletDir = new Vector2(bulletDirX, bulletDirY).normalized;
                
                var bullet = Instantiate(bullet_prefab, transform.position, Quaternion.identity);
                bullet.GetComponent<bullet_quai>().Setdir(bulletDir);

                angle += angleStep;
            }
        }
    }

    void healing()
    {
        if (current_health > 0 && current_health < max_health)
        {
            var hp = Random.Range(min, max);
            current_health += hp;
            if (current_health > max_health)
            {
                current_health = max_health;
            }
            update_health();
        }
    }
    
    IEnumerator skill()
    {
        while (true)
        {
            yield return new WaitForSeconds(time);

            if (current_health > 0)
            {
                var random = Random.Range(0, 3);

                switch (random)
                {
                    case 0:
                        dich_chuyen();
                        break;
                    case 1:
                        dan_toa();
                        break;
                    case 2:
                        healing();
                        break;
                }
            }
        }
    }
}
