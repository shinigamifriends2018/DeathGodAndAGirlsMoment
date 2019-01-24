using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public int m_bossMoveCheck = 0;
    [SerializeField]
    float m_YmoveSpeed = 0f;
    bool m_verCheck = false;
    int m_bossPattern = 1;
    public bool[] m_enemyCheck;
    [SerializeField]
    SimpleAnimation simpleAnimation;
    GameObject obj;
    Rigidbody2D rb;
    GameObject obj2;
    Rigidbody2D rb2;
    GameObject obj3;
    Rigidbody2D rb3;
    [SerializeField]
    GameObject ui;
    [SerializeField]
    GameObject m_bossEnemys;
    // Use this for initialization
    void Start () {
        m_hitPoint = 3;
        m_moveSpeed = -3f;
        m_YmoveSpeed = -3f;
        m_RightKmaitachi.SetActive(true);
        m_LeftKmaitachi.SetActive(true);
        SoundManager.Instance.PlayBGM((int)Common.BGMList.Boss);
    }

    // Update is called once per frame
    void Update() {
        Vector2 syoujoPos = m_syoujo.transform.position;
        Vector2 scale = transform.localScale;
        Move();
        m_AttackTimer += Time.deltaTime;

        switch (m_bossPattern)
        { case 1:
                if (m_movePoint[0].position.x > gameObject.transform.position.x)
                {
                    m_moveSpeed = 3f;

                }
                if (m_movePoint[1].position.x < gameObject.transform.position.x)
                {
                    m_moveSpeed = -3f;
                }
                if (m_bossMoveCheck == 0)
                {
                    m_RightKmaitachi.SetActive(false);
                    if (m_AttackTimer > 3)
                    {
                        simpleAnimation.Play("Kamaitachi");
                    }
                }
                if (m_bossMoveCheck == 1)
                {
                    m_LeftKmaitachi.SetActive(false);
                    if (m_AttackTimer > 5)
                    {
                        simpleAnimation.Play("Kamaitachi");
                    }
                }
                if (m_bossMoveCheck == 2)
                {
          
                    if (m_AttackTimer > 7)
                    {
                        simpleAnimation.Play("Kamaitachi");
                    }
                }
                if (m_bossMoveCheck == 3)
                {
                    m_LeftKmaitachi.SetActive(false);
                    if (m_AttackTimer > 9)
                    {
                        simpleAnimation.Play("Kamaitachi");
                    }
                }
                if (m_bossMoveCheck == 4)
                {
           
                    m_RightKmaitachi.SetActive(false);
                    if (m_AttackTimer > 11)
                    {
                        simpleAnimation.Play("Kamaitachi");
                    }
                }
                if (m_bossMoveCheck == 5)
                {
                    if (m_AttackTimer > 13)
                    {;
                        simpleAnimation.Play("Kamaitachi");
                    }
                }
                else if (m_bossMoveCheck == 6)
                {
                    if (m_AttackTimer > 15)
                    {
                        SoundManager.Instance.PlaySE((int)Common.SEList.EnemySporn);
                        m_bossEnemys.SetActive(true);
                        EnemyDis1();
                        EnemyDis2();
                        m_bossEnemys.SetActive(false);
                        m_bossMoveCheck = 7;
                    }
                }
                if (m_bossMoveCheck == 7)
                {
                    if (m_enemyCheck[0] == true && m_enemyCheck[1] == true)
                    {
                        m_moveSpeed = 0f;
                        m_YmoveSpeed = -3f;
                        if (gameObject.transform.position.y > 2)
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
                if (m_bossMoveCheck == 8)
                {
                    if (gameObject.transform.position.x > syoujoPos.x)
                    {
                        if (gameObject.transform.position.x - syoujoPos.x > 3 )
                        {
                            simpleAnimation.Play("Default");
                            m_moveSpeed = -4f;
                            if (scale.x < 0)
                            {
                                scale.x *= -1f;
                            }
                        }
                        else if (gameObject.transform.position.x - syoujoPos.x < 3)
                        {
                            m_moveSpeed = 0f;
                            simpleAnimation.Play("Assault");
                        }
                    }
                    else if (gameObject.transform.position.x < syoujoPos.x)
  
                    {
                        if (gameObject.transform.position.x - syoujoPos.x < -3)
                        {
                            simpleAnimation.Play("Default");
                            m_moveSpeed = 4f;
                            if (scale.x > 0)
                            {
                                scale.x *= -1f;
                            }
                        }
                        else if (gameObject.transform.position.x - syoujoPos.x > -3 )
                        {

                            m_moveSpeed = 0f;
                            simpleAnimation.Play("Assault");
                        }
                    }
                }
                if (m_verCheck == true)
                {
                    m_moveSpeed = 0f;
                    simpleAnimation.Play("Default");
                    if(scale.x < 0)
                    {
                        scale.x *= -1f;
                    }
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

                if (m_movePoint[0].position.x > gameObject.transform.position.x)
                {
                    m_moveSpeed = 3.5f;
                     
                }
                if (m_movePoint[1].position.x < gameObject.transform.position.x)
                {
                    m_moveSpeed = -3.5f;
                      
                }
                
                if (m_bossMoveCheck == 0)
                {
                    m_RightKmaitachi.SetActive(false);
                    if (m_AttackTimer > 2)
                    {
                        simpleAnimation.Play("Kamaitachi");
                    }
                }
                else if (m_bossMoveCheck == 1)
                {
                    m_LeftKmaitachi.SetActive(false);
                    if (m_AttackTimer > 4)
                    {
                        simpleAnimation.Play("Kamaitachi");
                    }
                }
                else if (m_bossMoveCheck == 2)
                {
                    if (m_AttackTimer > 6)
                    {
                        simpleAnimation.Play("Kamaitachi");
                    }
                }
                else if (m_bossMoveCheck == 3)
                {
                    m_LeftKmaitachi.SetActive(false);
                    if (m_AttackTimer > 8)
                    {
                        simpleAnimation.Play("Kamaitachi");
                    }
                }
                else if (m_bossMoveCheck == 4)
                {
                    m_RightKmaitachi.SetActive(false);
                    if (m_AttackTimer > 10)
                    {
                        simpleAnimation.Play("Kamaitachi");
                    }
                }
                else if (m_bossMoveCheck == 5)
                {
                    if (m_AttackTimer > 12)
                    {
                        simpleAnimation.Play("Kamaitachi");
                    }
                }
                else if (m_bossMoveCheck == 6)
                {
                    if (m_AttackTimer > 14)
                    {
                        SoundManager.Instance.PlaySE((int)Common.SEList.EnemySporn);
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
                        if (gameObject.transform.position.y > 2)
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
                if (m_bossMoveCheck == 8)
                {
                    if (gameObject.transform.position.x > syoujoPos.x)
                    {
                        if (gameObject.transform.position.x - syoujoPos.x > 3)
                        {
                            simpleAnimation.Play("Default");
                            m_moveSpeed = -4f;
                            if (scale.x < 0)
                            {
                                scale.x *= -1f;
                            }
                        }
                        else if (gameObject.transform.position.x - syoujoPos.x < 3)
                        {
                            m_moveSpeed = 0f;
                            simpleAnimation.Play("Assault");
                        }
                    }
                    else if (gameObject.transform.position.x < syoujoPos.x)

                    {
                        if (gameObject.transform.position.x - syoujoPos.x < -3)
                        {
                            simpleAnimation.Play("Default");
                            m_moveSpeed = 4f;
                            if (scale.x > 0)
                            {
                                scale.x *= -1f;
                            }
                        }
                        else if (gameObject.transform.position.x - syoujoPos.x > -3)
                        {

                            m_moveSpeed = 0f;
                            simpleAnimation.Play("Assault");
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
                if (m_hitPoint != 0)
                {
                    if (m_movePoint[0].position.x > gameObject.transform.position.x)
                    {
                        m_moveSpeed = 4f;

                    }
                    if (m_movePoint[1].position.x < gameObject.transform.position.x)
                    {
                        m_moveSpeed = -4f;

                    }

                    if (m_bossMoveCheck == 0)
                    {
                        m_LeftKmaitachi.SetActive(true);
                        m_RightKmaitachi.SetActive(false);
                        if (m_AttackTimer > 2)
                        {
                            simpleAnimation.Play("Kamaitachi");
                            m_bossMoveCheck = 1;
                        }
                    }
                    else if (m_bossMoveCheck == 1)
                    {
                        m_LeftKmaitachi.SetActive(false);
                        if (m_AttackTimer > 4)
                        {
                            simpleAnimation.Play("Kamaitachi");
                        }
                    }
                    else if (m_bossMoveCheck == 2)
                    {
                        if (m_AttackTimer > 6)
                        {
                            simpleAnimation.Play("Kamaitachi");
                        }
                    }
                    else if (m_bossMoveCheck == 3)
                    {
                        m_LeftKmaitachi.SetActive(false);
                        if (m_AttackTimer > 8)
                        {
                            simpleAnimation.Play("Kamaitachi");
                        }
                    }
                    else if (m_bossMoveCheck == 4)
                    {
                        m_RightKmaitachi.SetActive(false);
                        if (m_AttackTimer > 10)
                        {
                            simpleAnimation.Play("Kamaitachi");
                        }
                    }
                    else if (m_bossMoveCheck == 5)
                    {
                        if (m_AttackTimer > 12)
                        {
                            simpleAnimation.Play("Kamaitachi");
                        }
                    }
                    else if (m_bossMoveCheck == 6)
                    {
                        if (m_AttackTimer > 14)
                        {
                            SoundManager.Instance.PlaySE((int)Common.SEList.EnemySporn);
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
                            if (gameObject.transform.position.y > 2)
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
                    if (m_bossMoveCheck == 8)
                    {
                        if (gameObject.transform.position.x > syoujoPos.x)
                        {
                            if (gameObject.transform.position.x - syoujoPos.x > 3)
                            {
                                simpleAnimation.Play("Default");
                                m_moveSpeed = -4f;
                                if (scale.x < 0)
                                {
                                    scale.x *= -1f;
                                }
                            }
                            else if (gameObject.transform.position.x - syoujoPos.x < 3)
                            {
                                m_moveSpeed = 0f;
                                simpleAnimation.Play("Assault");
                            }
                        }
                        else if (gameObject.transform.position.x < syoujoPos.x)

                        {
                            if (gameObject.transform.position.x - syoujoPos.x < -3)
                            {
                                simpleAnimation.Play("Default");
                                m_moveSpeed = 4f;
                                if (scale.x > 0)
                                {
                                    scale.x *= -1f;
                                }
                            }
                            else if (gameObject.transform.position.x - syoujoPos.x > -3)
                            {

                                m_moveSpeed = 0f;
                                simpleAnimation.Play("Assault");
                            }
                        }
                    }
                }
                break;

        } 
 
    
        transform.localScale = scale;
    }

    void KamaitachiAttack1()
    {
        obj = Instantiate(m_LeftKmaitachi, m_spawnPoint[0].position, m_LeftKmaitachi.transform.rotation);
        rb = obj.GetComponent<Rigidbody2D>();
        Invoke("KamitachiShot1",0.2f);
    }

    void KamaitachiAttack2()
    {
        obj2 = Instantiate(m_kamaitachi, m_spawnPoint[1].position, m_kamaitachi.transform.rotation);
        rb2 = obj2.GetComponent<Rigidbody2D>();
        Invoke("KamitachiShot2", 0.2f);
    }
    void KamaitachiAttack3()
    {
        obj3 = Instantiate(m_RightKmaitachi, m_spawnPoint[2].position, m_RightKmaitachi.transform.rotation);
        rb3 = obj3.GetComponent<Rigidbody2D>();
        Invoke("KamitachiShot3", 0.2f);
    }
    void KamitachiShot1()
    {

        rb.AddForce(obj.transform.right * -m_shutePower, ForceMode2D.Impulse);

        SoundManager.Instance.PlaySE((int)Common.SEList.BossKamaitachi);
    }
    void KamitachiShot2()
    {
   
        rb2.AddForce(obj2.transform.right * -m_shutePower, ForceMode2D.Impulse);

        SoundManager.Instance.PlaySE((int)Common.SEList.BossKamaitachi);
    }
    void KamitachiShot3()
    {
   
        rb3.AddForce(obj3.transform.right * -m_shutePower, ForceMode2D.Impulse);

        SoundManager.Instance.PlaySE((int)Common.SEList.BossKamaitachi);
    }
    void EnemyDis1()
    {
        GameObject obj = Instantiate(m_bossEnemy[0], m_spawnPoint[3].position,m_spawnPoint[3].rotation);

    }
    void EnemyDis2()
    {
        GameObject obj = Instantiate(m_bossEnemy[1], m_spawnPoint[4].position,m_spawnPoint[3].rotation);
    }
    void BossMove()
    {
        simpleAnimation.Play("Default");
        ++m_bossMoveCheck;
        m_RightKmaitachi.SetActive(true);
        m_LeftKmaitachi.SetActive(true);
    }
    void Ending()
    {
        SceneManager.LoadScene("Ending");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Sickle"))//鎌に当たるとダメージ
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
            SoundManager.Instance.PlaySE((int)Common.SEList.BossDamage);
            --m_hitPoint;
            m_moveSpeed = 0;
            m_verCheck = true;
            if (m_hitPoint == 0)
            {
                simpleAnimation.Play("Down");
                SoundManager.Instance.PlaySE((int)Common.SEList.BossDown);
                ui.SetActive(false);
            }
        }
    }
}
