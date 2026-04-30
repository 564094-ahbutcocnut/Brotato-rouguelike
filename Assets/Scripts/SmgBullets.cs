using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmgBullets : MonoBehaviour
{
    float speed = 24f;

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
            enemy.Hit(10);
        }
    }
}
