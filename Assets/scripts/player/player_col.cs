using System.Collections;
using UnityEngine;

public class player_col : MonoBehaviour
{
    [SerializeField] int count, max_count, min, max;
    [SerializeField] GameObject boss_prefab;
    [SerializeField] Transform boss_pos;
    [SerializeField] game_manager game_manager;
    [SerializeField] player player;
    [SerializeField] audio_manager audio_manager;
    boss boss;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            
            game_manager.add_score();
            
            audio_manager.play_select();
        }
        
        if (other.CompareTag("items_boss"))
        {
            Destroy(other.gameObject);
            
            game_manager.add_energy();
            count++;
            if (count == max_count)
            {
                call_boss();
                game_manager.boss_coming();
            }
            
            audio_manager.play_energy();
        }
        
        if (other.CompareTag("boss_coin"))
        {
            Destroy(other.gameObject);
            game_manager.WinGame();
            audio_manager.play_select();
        }
        
        if (other.CompareTag("items_health"))
        {
            Destroy(other.gameObject);
            
            var heal = Random.Range(min, max);
            
            player.heal(heal);
            
            audio_manager.play_select();
        }
    }

    void call_boss()
    {
        var call_bosss = Instantiate(boss_prefab, boss_pos.position, boss_pos.rotation);
        boss = call_bosss.GetComponent<boss>();
    }
}
