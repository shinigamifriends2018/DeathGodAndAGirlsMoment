using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarEnemyContoller : GhostController {
    [SerializeField]
    GameObject m_heart;

    [SerializeField]
    float m_shutePower = 4.5f;

    public GameObject m_bulletPrefab;
    public Transform m_spawnPoint;
    float m_shuteCount = 3f;
    [SerializeField]
    SyoujoController syoujoController;

    float damageCounter = 0.3f;
    bool damageCheck = true;
    int m_feelingBelieve = 0;
    // Use this for initialization
    void Start () {
        m_hitPoint = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 syoujoPos   = m_syoujo.transform.position;
        Vector2 akuryouPos  = m_akuryou.transform.position;
        Vector2 scale = transform.localScale;
        
        base.m_moveSpeed = 2f;
        base.Chase();
        m_shuteCount -= Time.deltaTime;

        if (akuryouPos.x > syoujoPos.x)
        {
            if (scale.x < 0)
            {
                scale.x *= -1f;
            }
        }
        else
        {
            if (scale.x > 0)
            {
                scale.x *= -1f;
            }
        }
        if (m_shuteCount < 0)
        {
            m_shuteCount = 3f;
            GameObject obj = Instantiate(m_bulletPrefab, m_spawnPoint.position, m_spawnPoint.rotation);
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            rb.AddForce(obj.transform.right * -m_shutePower, ForceMode2D.Impulse);
        }
        transform.localScale = scale;
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
                TutorialTrigger tutorialToriger = m_tutorialToriger.GetComponent<TutorialTrigger>();
                tutorialToriger.m_returnCheck = true;
                if (damageCheck == false)
                {
                    syoujoController.AddFeelingOfBelieve = m_feelingBelieve;
                    damageCheck = true;
                }
                Destroy(this.gameObject,0.3f);
                Instantiate(m_heart, transform.position, transform.rotation);
            }
        }
    }

   

}
