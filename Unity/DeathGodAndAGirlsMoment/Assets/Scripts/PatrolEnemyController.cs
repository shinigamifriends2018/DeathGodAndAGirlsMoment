using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemyController : GhostController {

    [SerializeField]
    ShinigamiController shinigami;
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
        if (collision.gameObject.tag == ("Wall"))
        {
            Vector2 scale = gameObject.transform.localScale;
            scale.x *= -1f;
            gameObject.transform.localScale = scale;
        }
        if (collision.gameObject.tag == ("Sickle"))//鎌に当たるとダメージ
        {
            --m_hitPoint;
            if (m_hitPoint == 0)
            {
                int a = shinigami.GetFeelingBelieve;
                if (a < 5)
                {
                    a++;
                }
                shinigami.SetFeelingBelieve = a;
                Destroy(this.gameObject, 0.3f);
            }
            
        }
    }
}
