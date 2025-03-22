using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class enemy: MonoBehaviour
{
    [SerializeField] protected float speed, damage, stay_damage, max_health, current_health;
    [SerializeField] protected GameObject die_prefabs, coin_prefabs;
    [SerializeField] protected Image health_bar;
    [SerializeField] protected GameObject[] coins;
    
    protected player player;
    protected Animator ani;
    protected bool is_damage = false;

    protected virtual void Start()
    {
        player = FindAnyObjectByType<player>();
        ani = GetComponent<Animator>();

        current_health = max_health;
    }

    protected virtual void Update()
    {
        move_player();
        kill_pl();
    }
    
    protected void move_player()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        flip();
    }

    protected void flip()
    {
        var scale_x = 1f;
        
        if (player.transform.position.x < transform.position.x)
        {
            scale_x = -1f;
        }
        
        transform.localScale = new Vector3(scale_x, 1f, 1f);
    }

    protected virtual void die()
    {
        Destroy(gameObject);
        var die_pre = Instantiate(die_prefabs, transform.position, Quaternion.identity);
        Destroy(die_pre, 0.5f);

        if (coins.Length > 0)
        {
            var rabdom_coin = coins[Random.Range(0, coins.Length)];
        
            var coin = Instantiate(rabdom_coin, transform.position, Quaternion.identity);
            Destroy(coin, 5f);
        }
        else
        {
            var coinz = Instantiate(coin_prefabs, transform.position, Quaternion.identity);
            Destroy(coinz, 5f);
        }
        
        StopAllCoroutines();
    }

    public virtual void take_damage(float damagez)
    {
        ani.SetTrigger("is_hit");
        current_health -= damagez;
        update_health();

        if (current_health == 0)
        {
            StartCoroutine(die_hit());
        }
    }

    protected IEnumerator die_hit()
    {
        yield return new WaitForSeconds(0.3f);
        die();
    }
    
    protected void update_health()
    {
        health_bar.fillAmount = current_health / max_health;
    }

    protected void kill_pl()
    {
        if (player == null)
        {
            print("player is null");
            StopAllCoroutines();
        }
    }
}
