using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2SwithController : MonoBehaviour
{

    SimpleAnimation m_simpleAnimation;

    bool m_pushed = false;

    [SerializeField]
    GameObject[] m_disPlayEnemy;
    bool m_onCollisionStay = false;
    // Use this for initialization
    void Start()
    {
        m_simpleAnimation = GetComponent<SimpleAnimation>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FinishAnimation()
    {
        m_pushed = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("shinigami") || collision.gameObject.tag == ("syoujo"))
        {
            m_onCollisionStay = true;
            if (m_pushed == false)
            {
                m_pushed = true;
                m_simpleAnimation.Play("Change");
            }
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("shinigami") || collision.gameObject.tag == ("syoujo"))
        {
           
            m_onCollisionStay = true;
            if (m_pushed == false)
            {
                m_pushed = true;
                m_simpleAnimation.Play("Change");
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("shinigami") || collision.gameObject.tag == ("syoujo"))
        {
           
            m_onCollisionStay = false;
        }
    }


    void EnemyDisPlay()
    {
        SoundManager.Instance.PlaySE((int)Common.SEList.EnemySporn);
        SoundManager.Instance.PlaySE((int)Common.SEList.Swich);
        m_disPlayEnemy[0].SetActive(true);
        m_disPlayEnemy[1].SetActive(true);
        m_disPlayEnemy[2].SetActive(true);
        m_disPlayEnemy[3].SetActive(true);
    }
}
