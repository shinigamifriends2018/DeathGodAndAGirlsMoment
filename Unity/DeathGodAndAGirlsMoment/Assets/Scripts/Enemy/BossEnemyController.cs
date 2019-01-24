using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyController :  GhostController{

    [SerializeField]
    BossController bossController;
    [SerializeField]
    GameObject[] m_bossEnemy;
    float damageCounter = 0.3f;
    bool damageCheck = true;
    // Use this for initialization
    void Start () {
        m_hitPoint = 2;
    }
	
	// Update is called once per frame
	void Update () {
        if (damageCheck == false)
        {
            damageCounter -= Time.deltaTime;
        }
        if (damageCounter < 0)
        {
            damageCounter = 1f;
            damageCheck = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Sickle"))
        {
            if (damageCheck == true)
            {
                --m_hitPoint;
                damageCheck = false;
            }
            if (m_hitPoint == 0)
            {
                if (this.gameObject == m_bossEnemy[0])
                {
                    bossController.m_enemyCheck[0] = true;
                }
            }
            if (m_hitPoint == 0)
            {
                if (this.gameObject == m_bossEnemy[1])
                {
                    bossController.m_enemyCheck[1] = true;
                }
            }
        }
    }
}
