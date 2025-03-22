using UnityEngine;

public class player_col : MonoBehaviour
{
    player playerz;
    
    [SerializeField] int count, max_count, min, max;
    [SerializeField] GameObject boss_prefab;
    [SerializeField] Transform boss_pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerz = GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("items"))
        {
            Destroy(other.gameObject);
            
            playerz.add_score();
        }
        
        if (other.CompareTag("items_boss"))
        {
            Destroy(other.gameObject);
            
            playerz.add_score();
            count++;
            if (count == max_count)
            {
                call_boss();
            }
        }
        
        if (other.CompareTag("boss_coin"))
        {
            Destroy(other.gameObject);
        }
        
        if (other.CompareTag("items_health"))
        {
            Destroy(other.gameObject);
            
            var heal = Random.Range(min, max);
            
            playerz.heal(heal);
        }
    }

    void call_boss()
    {
        Instantiate(boss_prefab, boss_pos.position, boss_pos.rotation);
    }
}
