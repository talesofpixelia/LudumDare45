﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    private void Update()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if ((transform.position.x < min.x) || (transform.position.x > max.x) ||
            (transform.position.y < min.y) || (transform.position.y > max.y))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go = gameObject.GetComponent<GameObject>();

        if (collision.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("PlayerBullet") && !CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("EnemyCac"))
        {
            collision.GetComponent<EnemyControlCac>().SetHealth(50);
            Destroy(gameObject);
        }

        if (collision.CompareTag("EnemyDistance"))
        {
            collision.GetComponent<EnemyControlDistance>().SetHealth(50);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Player") && gameObject.name == "Enemybullets(Clone)")
        {
            collision.GetComponent<PlayerMovement>().SetDamage();
            Destroy(gameObject);
        }
    }
}
