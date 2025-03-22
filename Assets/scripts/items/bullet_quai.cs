using UnityEngine;

public class bullet_quai : MonoBehaviour
{
    [SerializeField] float speed; 
    [SerializeField] float damage;
    
    Vector2 dir;

    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime, Space.World);
        
        Destroy(gameObject, 2f);
    }

    public void Setdir(Vector2 dirz)
    {
        dir = dirz.normalized;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<player>();
            
            player.take_damage(damage);
            
            Destroy(gameObject);
        }
    }
}