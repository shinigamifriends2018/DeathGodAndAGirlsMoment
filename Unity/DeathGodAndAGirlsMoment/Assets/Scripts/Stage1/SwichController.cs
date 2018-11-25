using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwichController : MonoBehaviour {
    
    SimpleAnimation m_simpleAnimation;

    [SerializeField]
    CageDestroy m_cage;

    bool m_pushed = false;

    bool m_onCollisionStay = false;

    [SerializeField]
    GameObject []m_this;

    // Use this for initialization
    void Start () {
        m_simpleAnimation = GetComponent<SimpleAnimation>();
    }
	
	// Update is called once per frame
	void Update () {

        if (gameObject == m_this[0])
        {
            if (m_cage.PushCheck && !m_onCollisionStay)
            {
                m_pushed = true;
                m_simpleAnimation.Play("Reverse");
            }
        }
        if (gameObject == m_this[1])
        {
            if (m_cage.PushCheck2 && !m_onCollisionStay)
            {
                m_pushed = true;
                m_simpleAnimation.Play("Reverse");
            }
        }
    }

    void PushCheck()
    {
        m_cage.PushCheck = true;

    }
    void PushCheck2()
    {
        m_cage.PushCheck2 = true;
    }
    void ReversePushCheck()
    {
        m_cage.PushCheck = false;
    }
    void ReversePushCheck2()
    {
        m_cage.PushCheck2 = false;
    }

    void FinishAnimation()
    {
        m_pushed = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ("shinigami") || collision.gameObject.tag == ("syoujo"))
        {
            if (gameObject == m_this[0])
            {
                m_onCollisionStay = true;
                if (m_pushed == false)
                {
                    m_pushed = true;
                    m_simpleAnimation.Play("Change");
                }
            }
            if (gameObject == m_this[1])
            {
                m_onCollisionStay = true;
                if (m_pushed == false)
                {
                    m_pushed = true;
                    m_simpleAnimation.Play("Change");
                }
            }
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("shinigami") || collision.gameObject.tag == ("syoujo"))
        {
            if (gameObject == m_this[0])
            {
                m_onCollisionStay = true;
                if (m_pushed == false)
                {
                    m_pushed = true;
                    m_simpleAnimation.Play("Change");
                }
            }
            if (gameObject == m_this[1])
            {
                m_onCollisionStay = true;
                if (m_pushed == false)
                {
                    m_pushed = true;
                    m_simpleAnimation.Play("Change");
                }
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

}
