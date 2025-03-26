using UnityEngine;

public class bullet_pl : MonoBehaviour
{
    Rigidbody2D rb;
    
    [SerializeField] float speed, damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("quai"))
        {
            var enemy = other.GetComponent<enemy>();

            enemy.take_damage(damage);
            
            Destroy(gameObject);
        }
    }
}