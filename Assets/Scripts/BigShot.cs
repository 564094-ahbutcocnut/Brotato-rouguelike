using UnityEngine;

public class BigShot : MonoBehaviour
{
    float speed = 10f;

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
        var Bossenemy = collision.gameObject.GetComponent<BossEnemy>();
        if (Bossenemy != null)
        {
            Destroy(gameObject);
            Bossenemy.Hit(100);
        }
    }
}
