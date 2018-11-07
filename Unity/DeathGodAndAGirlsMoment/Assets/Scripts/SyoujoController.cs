using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SyoujoController : CharacterBase
{
    Vector2 scale;
    int m_aFeelingOfBelieve = 3;
    bool m_followMode;
    bool m_followSwitch = true;
    [SerializeField]
    ShinigamiController shinigami;
    bool m_onConnectHands = false;
    Rigidbody2D rb;

    // Use this for initialization

    void Start()
    {
        scale = gameObject.transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        m_jumpPower = 10.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_onConnectHands == false)
        {
            m_moveSpeed = 3.0f;
        }
        else
        {
            m_moveSpeed = 4.5f;
        }
        if (Input.GetButtonDown("FollowSwitch"))
        {
            if(m_followSwitch == true)
            {
                m_followSwitch = false;
            }
            else
            {
                m_followSwitch = true;
            }
        }
        if (Input.GetButtonDown("Jump"))
        {
            if(m_onConnectHands == true)
            {
                Jump(rb);
            }
        }
        if (Input.GetButtonDown("S"))
        {
            if (m_onConnectHands == true)
            {
                Fall();
            }
        }
        if (m_onConnectHands == true)
        {
            ConnectHands();
        }
        else
        {
            Follow();
        }
    }

    void Follow()
    {
        if (m_aFeelingOfBelieve >= 3)
        {
            m_followMode = true;
        }
        else
        {
            m_followMode = false;
        }
        if (m_followMode == true)
        {
            if (m_followSwitch == true)
            {
                if (Mathf.Abs(transform.position.x - shinigami.Posinvestigate.x) > 2f)
                {
                    if (shinigami.Posinvestigate.x > transform.position.x)
                    {
                        Move();
                        if (scale.x < 0)
                        {
                            scale.x *= -1;
                        }
                    }
                    else if (shinigami.Posinvestigate.x < transform.position.x)
                    {
                        transform.Translate(new Vector2(-m_moveSpeed * Time.deltaTime, 0f));
                        if (scale.x > 0)
                        {
                            scale.x *= -1;
                        }
                    }
                    gameObject.transform.localScale = scale;
                }
            }
        }
    }

    void ConnectHands()
    {
        if (Mathf.Abs(transform.position.x - shinigami.Posinvestigate.x) > 1f)
        {
            if (shinigami.Posinvestigate.x > transform.position.x)
            {
                Move();
                if (scale.x < 0)
                {
                    scale.x *= -1;
                }
            }
            else if (shinigami.Posinvestigate.x < transform.position.x)
            {
                transform.Translate(new Vector2(-m_moveSpeed * Time.deltaTime, 0f));
                if (scale.x > 0)
                {
                    scale.x *= -1;
                }
            }
            gameObject.transform.localScale = scale;
        }
    }

    public bool OnConnectHands
    {
        set
        {
            m_onConnectHands = value;
        }
    }
    public bool ConnectHandsTF
    {
        get
        {
            return m_onConnectHands;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            m_jump = true;
        }
    }
    /* private void OnTriggerEnter2D(Collider2D collision)
     {
         if(m_followMode == true)
         {

         }
     }
     */
}
