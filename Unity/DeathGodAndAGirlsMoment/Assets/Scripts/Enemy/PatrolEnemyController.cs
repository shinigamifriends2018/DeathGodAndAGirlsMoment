using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemyController : GhostController {

    [SerializeField]
    SyoujoController syoujoController;
    int m_feelingBelieve = 0;
    float damageCounter = 0.3f;
    bool damageCheck = true;
    // Use this for initialization
    void Start()
    {
        m_hitPoint = 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (damageCheck == false)
        {
            damageCounter -= Time.deltaTime;
        }
        if (damageCounter < 0)
        {
            damageCounter = 1f;
            damageCheck = true;
        }
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
            if (damageCheck == true)
            {
                --m_hitPoint;
                damageCheck = false;
            }
            if (m_hitPoint == 0)
            {
                if (damageCheck == false)
                {
                    syoujoController.AddFeelingOfBelieve = m_feelingBelieve;
                    damageCheck = true;
                }
                Destroy(this.gameObject, 0.3f);
            }
            
        }
    }
}
