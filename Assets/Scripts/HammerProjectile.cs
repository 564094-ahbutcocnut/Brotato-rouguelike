using UnityEngine;

public class HammerProjectile : MonoBehaviour
{

    float speed = 21f;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            Destroy(gameObject);
            enemy.Hit(100);
        }
        var player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            Destroy(gameObject);  
            player.Hit(25);
            
 

        }

    }
}
