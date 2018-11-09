using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemyController : GhostController {

    // Use this for initialization
    void Start()
    {
        m_hitPoint = 3;
    }
    // Update is called once per frame
    void Update()
    {
        base.m_moveSpeed = 3f;
        base.Patrol();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Sickle"))//鎌に当たるとダメージ
        {
            --m_hitPoint;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Wall"))
        {
            Vector2 scale = gameObject.transform.localScale;
            scale.x *= -1f;
            gameObject.transform.localScale = scale;
        }
    }
}
