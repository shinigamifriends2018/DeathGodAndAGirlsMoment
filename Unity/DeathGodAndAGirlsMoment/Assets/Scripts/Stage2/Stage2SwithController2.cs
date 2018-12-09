using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2SwithController2 : MonoBehaviour
{

    SimpleAnimation m_simpleAnimation;
    bool m_pushed = false;
    bool m_onCollisionStay = true;
    [SerializeField]
    bool m_check = true;
    // Use this for initialization
    void Start()
    {
        m_simpleAnimation = GetComponent<SimpleAnimation>();
        m_check = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if (m_check != true)
        {
            m_simpleAnimation.Play("Reverse");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("shinigami") || collision.gameObject.tag == ("syoujo"))
        {
            m_onCollisionStay = true;

            m_simpleAnimation.Play("Change");

        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
  
        if (collision.gameObject.tag == ("shinigami") || collision.gameObject.tag == ("syoujo"))
        {
            m_check = true;
            m_onCollisionStay = true;
            m_simpleAnimation.Play("Change");
        }
    }

    void FinishAnimation()
    {
        m_check = false;
    }
}
