using UnityEngine;

public abstract class enemy: MonoBehaviour
{
    [SerializeField] protected float speed;
    protected player player;

    protected virtual void Start()
    {
        player = FindAnyObjectByType<player>();
    }

    protected virtual void Update()
    {
        move_player();
    }
    
    protected void move_player()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        flip();
    }

    protected void flip()
    {
        transform.localScale = new Vector3(player.transform.position.x < transform.position.x ? -1 : 1, 1, 1);
    }

    protected virtual void die()
    {
        Destroy(gameObject);
    }

    public virtual void take_damage()
    {
        die();
    }
}
