﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : GhostController {

    [SerializeField]
    Transform[] m_movePoint;
    [SerializeField]
    float m_shutePower = 4f;
    public GameObject m_kamaitachi;
    public GameObject m_LeftKmaitachi;
    public GameObject m_RightKmaitachi;
    public GameObject[] m_bossEnemy;
    public Transform[] m_spawnPoint;
    float m_AttackTimer = 0f;
    float m_kamaitachiTimer = 0f;
    GameObject m_kamaitachiBox;
    int m_bossMoveCheck = 0;
    [SerializeField]
    float m_YmoveSpeed = 0f;
    bool m_verCheck = false;
    int m_bossPattern = 1;
    public bool[] m_enemyCheck;
    // Use this for initialization
    void Start () {
        m_hitPoint = 3;
        m_moveSpeed = -3f;
        m_YmoveSpeed = -3f;
	}

    // Update is called once per frame
    void Update() {
        Vector2 syoujoPos = m_syoujo.transform.position;
        Vector2 scale = transform.localScale;
        Move();
        m_AttackTimer += Time.deltaTime;
        if (m_movePoint[0].position.x > gameObject.transform.position.x)
        {
            m_moveSpeed = 3f;

        }
        if (m_movePoint[1].position.x < gameObject.transform.position.x)
        {
            m_moveSpeed = -3f;
        }
        switch (m_bossPattern)
        { case 1:
                if (m_bossMoveCheck == 0)
                {
                    if (m_AttackTimer > 2)
                    {
                        KamaitachiAttack1();
                        KamaitachiAttack2();
                        m_bossMoveCheck = 1;
                    }
                }
                else if (m_bossMoveCheck == 1)
                {
                    if (m_AttackTimer > 4)
                    {
                        KamaitachiAttack2();
                        KamaitachiAttack3();
                        m_bossMoveCheck = 2;
                    }
                }
                else if (m_bossMoveCheck == 2)
                {
                    if (m_AttackTimer > 6)
                    {
                        KamaitachiAttack1();
                        KamaitachiAttack2();
                        KamaitachiAttack3();
                        m_bossMoveCheck = 3;
                    }
                }
                else if (m_bossMoveCheck == 3)
                {
                    if (m_AttackTimer > 8)
                    {
                        KamaitachiAttack2();
                        KamaitachiAttack3();
                        m_bossMoveCheck = 4;
                    }
                }
                else if (m_bossMoveCheck == 4)
                {
                    if (m_AttackTimer > 10)
                    {
                        KamaitachiAttack1();
                        KamaitachiAttack2();
                        m_bossMoveCheck = 5;
                    }
                }
                else if (m_bossMoveCheck == 5)
                {
                    if (m_AttackTimer > 12)
                    {
                        KamaitachiAttack1();
                        KamaitachiAttack2();
                        KamaitachiAttack3();
                        m_bossMoveCheck = 6;
                    }
                }
                else if (m_bossMoveCheck == 6)
                {
                    if (m_AttackTimer > 14)
                    {
                        EnemyDis1();
                        EnemyDis2();
                        m_bossMoveCheck = 7;
                    }
                }
                else if (m_bossMoveCheck == 7)
                {
                    if (m_enemyCheck[0] == true && m_enemyCheck[1] == true)
                    {
                        m_moveSpeed = 0f;
                        m_YmoveSpeed = -3f;
                        if (gameObject.transform.position.y > 3.5)
                        {
                            transform.Translate(new Vector2(0f, m_YmoveSpeed * Time.deltaTime));
                        }
                        else
                        {
                            m_bossMoveCheck = 8;
                            m_enemyCheck[0] = false;
                            m_enemyCheck[1] = false;
                            GetComponent<CapsuleCollider2D>().enabled = true;
                        }
                    }
                }
                else if (m_bossMoveCheck == 8)
                {
                    if (gameObject.transform.position.x > syoujoPos.x)
                    {
                        if (gameObject.transform.position.x - syoujoPos.x > 2)
                        {
                            m_moveSpeed = -4f;
                            if (scale.x < 0)
                            {
                                scale.x *= -1f;
                            }
                        }
                    }
                    else if (gameObject.transform.position.x < syoujoPos.x)
                    {
                        if (syoujoPos.x - gameObject.transform.position.x > 2)
                            m_moveSpeed = 4f;
                        if (scale.x > 0)
                        {
                            scale.x *= -1f;
                        }
                    }
                }
                if (m_verCheck == true)
                {
                    m_moveSpeed = 0f;

                    if (gameObject.transform.position.y < 7)
                    {
                        m_YmoveSpeed = 3f;
                        transform.Translate(new Vector2(0f, m_YmoveSpeed * Time.deltaTime));
                    }
                    else
                    {
                        m_bossMoveCheck = 0;
                        m_AttackTimer = 0f;
                        m_moveSpeed = 3.5f;
                        m_shutePower = 4.5f;
                        m_bossPattern = 2;
                        m_verCheck = false;
                    }
                }
                break;
            case 2:
                if (m_bossMoveCheck != 8)
                {
                    if (m_movePoint[0].position.x > gameObject.transform.position.x)
                    {
                        m_moveSpeed = 3.5f;
                     
                    }
                    if (m_movePoint[1].position.x < gameObject.transform.position.x)
                    {
                        m_moveSpeed = -3.5f;
                      
                    }
                }
                if (m_bossMoveCheck == 0)
                {
                    if (m_AttackTimer > 2)
                    {
                        KamaitachiAttack1();
                        KamaitachiAttack2();
                        m_bossMoveCheck = 1;
                    }
                }
                else if (m_bossMoveCheck == 1)
                {
                    if (m_AttackTimer > 4)
                    {
                        KamaitachiAttack2();
                        KamaitachiAttack3();
                        m_bossMoveCheck = 2;
                    }
                }
                else if (m_bossMoveCheck == 2)
                {
                    if (m_AttackTimer > 6)
                    {
                        KamaitachiAttack1();
                        KamaitachiAttack2();
                        KamaitachiAttack3();
                        m_bossMoveCheck = 3;
                    }
                }
                else if (m_bossMoveCheck == 3)
                {
                    if (m_AttackTimer > 8)
                    {
                        KamaitachiAttack2();
                        KamaitachiAttack3();
                        m_bossMoveCheck = 4;
                    }
                }
                else if (m_bossMoveCheck == 4)
                {
                    if (m_AttackTimer > 10)
                    {
                        KamaitachiAttack1();
                        KamaitachiAttack2();
                        m_bossMoveCheck = 5;
                    }
                }
                else if (m_bossMoveCheck == 5)
                {
                    if (m_AttackTimer > 12)
                    {
                        KamaitachiAttack1();
                        KamaitachiAttack2();
                        KamaitachiAttack3();
                        m_bossMoveCheck = 6;
                    }
                }
                else if (m_bossMoveCheck == 6)
                {
                    if (m_AttackTimer > 14)
                    {
                        EnemyDis1();
                        EnemyDis2();
                        m_bossMoveCheck = 7;
                    }
                }
                else if (m_bossMoveCheck == 7)
                {
                    if (m_enemyCheck[0] == true && m_enemyCheck[1] == true)
                    {
                        m_moveSpeed = 0f;
                        m_YmoveSpeed = -3f;
                        if (gameObject.transform.position.y > 3.5)
                        {
                            transform.Translate(new Vector2(0f, m_YmoveSpeed * Time.deltaTime));
                        }
                        else
                        {
                            m_bossMoveCheck = 8;
                            GetComponent<CapsuleCollider2D>().enabled = true;
                            m_enemyCheck[0] = false;
                            m_enemyCheck[1] = false;
                        }
                    }
                }
                else if (m_bossMoveCheck == 8)
                {
                    if (gameObject.transform.position.x > syoujoPos.x)
                    {
                        if (gameObject.transform.position.x - syoujoPos.x > 2)
                        {
                            m_moveSpeed = -4f;
                            if (scale.x < 0)
                            {
                                scale.x *= -1f;
                            }
                        }
                    }
                    else if (gameObject.transform.position.x < syoujoPos.x)
                    {
                        if (syoujoPos.x - gameObject.transform.position.x > 2)
                            m_moveSpeed = 4f;
                        if (scale.x > 0)
                        {
                            scale.x *= -1f;
                        }
                    }
                }
                if (m_verCheck == true)
                {
                    m_moveSpeed = 0f;

                    if (gameObject.transform.position.y < 7)
                    {
                        m_YmoveSpeed = 3f;
                        transform.Translate(new Vector2(0f, m_YmoveSpeed * Time.deltaTime));
                    }
                    else
                    {
                        m_bossMoveCheck = 0;
                        m_AttackTimer = 0f;
                        m_moveSpeed = 4f;
                        m_shutePower = 5f;
                        m_bossPattern = 3; 
                        m_verCheck = false;
                    }
                }
                break;
            case 3:
                if (m_bossMoveCheck != 8)
                {
                    if (m_movePoint[0].position.x > gameObject.transform.position.x)
                    {
                        m_moveSpeed = 4f;
                  


                    }
                    if (m_movePoint[1].position.x < gameObject.transform.position.x)
                    {
                        m_moveSpeed = -4f;
                     
                    }
                }
                if (m_bossMoveCheck == 0)
                {
                    if (m_AttackTimer > 2)
                    {
                        KamaitachiAttack1();
                        KamaitachiAttack2();
                        m_bossMoveCheck = 1;
                    }
                }
                else if (m_bossMoveCheck == 1)
                {
                    if (m_AttackTimer > 4)
                    {
                        KamaitachiAttack2();
                        KamaitachiAttack3();
                        m_bossMoveCheck = 2;
                    }
                }
                else if (m_bossMoveCheck == 2)
                {
                    if (m_AttackTimer > 6)
                    {
                        KamaitachiAttack1();
                        KamaitachiAttack2();
                        KamaitachiAttack3();
                        m_bossMoveCheck = 3;
                    }
                }
                else if (m_bossMoveCheck == 3)
                {
                    if (m_AttackTimer > 8)
                    {
                        KamaitachiAttack2();
                        KamaitachiAttack3();
                        m_bossMoveCheck = 4;
                    }
                }
                else if (m_bossMoveCheck == 4)
                {
                    if (m_AttackTimer > 10)
                    {
                        KamaitachiAttack1();
                        KamaitachiAttack2();
                        m_bossMoveCheck = 5;
                    }
                }
                else if (m_bossMoveCheck == 5)
                {
                    if (m_AttackTimer > 12)
                    {
                        KamaitachiAttack1();
                        KamaitachiAttack2();
                        KamaitachiAttack3();
                        m_bossMoveCheck = 6;
                    }
                }
                else if (m_bossMoveCheck == 6)
                {
                    if (m_AttackTimer > 14)
                    {
                        EnemyDis1();
                        EnemyDis2();
                        m_bossMoveCheck = 7;
                    }
                }
                else if (m_bossMoveCheck == 7)
                {
                    if (m_enemyCheck[0] == true && m_enemyCheck[1] == true)
                    {
                        m_moveSpeed = 0f;
                        m_YmoveSpeed = -3f;
                        if (gameObject.transform.position.y > 3.5)
                        {
                            transform.Translate(new Vector2(0f, m_YmoveSpeed * Time.deltaTime));
                        }
                        else
                        {
                            m_bossMoveCheck = 8;
                            GetComponent<CapsuleCollider2D>().enabled = true;
                            m_enemyCheck[0] = false;
                            m_enemyCheck[1] = false;
                        }
                    }
                }
                else if (m_bossMoveCheck == 8)
                {
                    if (gameObject.transform.position.x > syoujoPos.x)
                    {
                        if (gameObject.transform.position.x - syoujoPos.x > 2)
                        {
                            m_moveSpeed = -4f;
                            if (scale.x < 0)
                            {
                                scale.x *= -1f;
                            }
                        }
                    }
                    else if (gameObject.transform.position.x < syoujoPos.x)
                    {
                        if (syoujoPos.x - gameObject.transform.position.x > 2)
                            m_moveSpeed = 4f;
                        if (scale.x > 0)
                        {
                            scale.x *= -1f;
                        }
                    }
                }
                if (m_verCheck == true)
                {
                    m_moveSpeed = 0f;

                    if (gameObject.transform.position.y < 7)
                    {
                        m_YmoveSpeed = 3f;
                        transform.Translate(new Vector2(0f, m_YmoveSpeed * Time.deltaTime));
                    }
                    else
                    {
                        m_bossMoveCheck = 0;
                        m_AttackTimer = 0f;
                        m_moveSpeed = 4f;
                        m_shutePower = 5f;
                        m_bossPattern = 1;
                        m_verCheck = false;
                    }
                }
                break;

        } 
 
    
        transform.localScale = scale;
    }

    void KamaitachiAttack1()
    {
        GameObject obj = Instantiate(m_LeftKmaitachi, m_spawnPoint[0].position, m_LeftKmaitachi.transform.rotation);
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.AddForce(obj.transform.right * -m_shutePower, ForceMode2D.Impulse);
    }
    void KamaitachiAttack2()
    {
        GameObject obj = Instantiate(m_kamaitachi, m_spawnPoint[1].position, m_kamaitachi.transform.rotation);
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.AddForce(obj.transform.right * -m_shutePower, ForceMode2D.Impulse);
    }
    void KamaitachiAttack3()
    {
        GameObject obj = Instantiate(m_RightKmaitachi, m_spawnPoint[2].position, m_RightKmaitachi.transform.rotation);
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.AddForce(obj.transform.right * -m_shutePower, ForceMode2D.Impulse);
    }
    void EnemyDis1()
    {
        GameObject obj = Instantiate(m_bossEnemy[0], m_spawnPoint[3].position,m_spawnPoint[3].rotation);

    }
    void EnemyDis2()
    {
        GameObject obj = Instantiate(m_bossEnemy[1], m_spawnPoint[4].position,m_spawnPoint[3].rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Sickle"))//鎌に当たるとダメージ
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
            --m_hitPoint;
            m_verCheck = true;
            if (m_hitPoint == 0)
            {
                Destroy(gameObject, 0.3f);
                SceneManager.LoadScene("Ending");
            }
        }
    }
}
