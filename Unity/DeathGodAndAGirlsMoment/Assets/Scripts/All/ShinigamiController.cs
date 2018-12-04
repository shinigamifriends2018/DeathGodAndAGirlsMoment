﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShinigamiController : CharacterBase {

    Vector2 scale;
    Rigidbody2D rb;
    bool m_toConnectHands;
    bool m_onAttack = false;
    [SerializeField]
    GameObject m_sickle;
    [SerializeField]
    SyoujoController syoujo;
    float m_interval = 0.2f;
    [SerializeField]
    GameObject[] m_efect;
    bool m_onSetAvtive = false;
    float m_setActiveTime = 0f;
    [SerializeField]
    CameraController camera;
    bool m_canHint = true;
    float m_beforePos;

    Vector3 m_shinigamisPos;

    // Use this for initialization
    void Start () {
        m_simpleAnimation = GetComponent<SimpleAnimation>();
        scale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        m_jumpPower = 10.5f;
        m_shinigamisPos = gameObject.transform.position;
    }

	// Update is called once per frame
	void Update () {       
        if(Mathf.Abs(gameObject.transform.position.x - m_beforePos) > 0.5f)
        {
            camera.SetCanMove = true;
        }
        else
        {
            camera.SetCanMove = false;
        }

        if(m_setActiveTime >= 0)
        {
            m_setActiveTime -= Time.deltaTime;
            m_onSetAvtive = true;
        }
        else
        {
            m_onSetAvtive = false;
        }

        if(syoujo.ConnectHandsTF == false)
        {
            m_moveSpeed = 4.0f;
            m_efect[0].SetActive(false);
        }
        else
        {
            m_efect[0].SetActive(true);
            m_moveSpeed = 4.5f;
        }

        m_shinigamisPos = gameObject.transform.position;
        float h = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector2(m_moveSpeed * h * Time.deltaTime, 0f));
        if(h > 0)
        {
            if (scale.x < 0)
            {
                scale.x *= -1f;
                m_beforePos = gameObject.transform.position.x;
            }
        } else if(h < 0)
        {
            if (scale.x > 0)
            {
                scale.x *= -1f;
                m_beforePos = gameObject.transform.position.x;
            }
        }
        float s = Input.GetAxisRaw("S");
        if(s < 0)
        {
            Fall();
            Invoke("Returnlayer", 0.35f);
        }
        if (Input.GetButtonDown("S"))
        {
            Fall();
            Invoke("Returnlayer", 0.35f);
        }
        if (Input.GetButtonDown("FollowSwitch"))
        {
            if (m_onSetAvtive == false)
            {
                m_setActiveTime = 0.3f;
                syoujo.FollowSwitch();
                Setactive();
                Invoke("Setactive", 0.3f);
            }
        }
        if (Input.GetButtonDown("Jump"))
        {
            Jump(rb);
            Invoke("Returnlayer", 0.5f);
        }
        if (Input.GetButtonDown("Attack"))
        {           
            Attack();  
        }
		else if (m_onAttack == false)
		{
			m_simpleAnimation.CrossFade("Idle", m_interval);
		}
        if (Input.GetButtonDown("ConnectHands"))
        {
            if (syoujo.ConnectHandsTF == false)
            {
                if (m_toConnectHands == true)
                {
                    if (syoujo.GetOnFrightening == false)
                    {
                        syoujo.OnConnectHands = true;
                    }
                }
            }
            else
            {
                syoujo.OnConnectHands = false;
            }
        }       
        transform.localScale = scale;      
	}

    void Attack()
    {
        if (m_onAttack == false)
        {
            if(syoujo.ConnectHandsTF == true)
            {
                syoujo.OnConnectHands = false;
            }

            m_sickle.SetActive(true);
            if (m_jump == false)
            {
                m_onAttack = true;
				m_simpleAnimation.CrossFade("JumpAttack", 0.05f);
            }
            else
            {
                m_onAttack = true;
                m_simpleAnimation.CrossFade("Attack", 0.05f);
            }
        }
    }

    void AttackActive()
    {
        m_sickle.GetComponent<PolygonCollider2D>().enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.gameObject.tag == "Switch")
        {
            if (m_canHint == true)
            {
                if(syoujo.GetAFeelingOfBelieve >= 5)
                {
                    if(syoujo.ConnectHandsTF == true)
                    {
                        syoujo.StartCoroutine("SetActiveHint", 2);
                    }
                }
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Switch")
        {
            m_jump = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Switch")
        {
            m_jump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "syoujo")
        {
            m_toConnectHands = true;
        }
        if (collision.gameObject.tag == "Hint2Trigger")
        {
            Destroy(collision.gameObject);
            camera.FixedSet = true;
        }
        if(collision.gameObject.tag == "FixedRelease")
        {
            camera.FixedSet = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "syoujo")
        {
            m_toConnectHands = false;
        }
    }

    public void OnAnimationFinished()
    {
        {
            m_sickle.SetActive(false);
            m_sickle.GetComponent<PolygonCollider2D>().enabled = false;
            Invoke("Interval", m_interval+0.1f);
			m_simpleAnimation.CrossFade("Idle", m_interval);
        }
    }

    void Interval()
    {
        m_onAttack = false;
    }

    void Setactive()
    {
        if (syoujo.FollowSwitchTF == true)
        {
            if (m_efect[2].activeInHierarchy == true)
            {
                m_efect[2].SetActive(false);
            }
            else
            {
                m_efect[2].SetActive(true);
            }
        }
        else
        {
            if (m_efect[1].activeInHierarchy == true)
            {
                m_efect[1].SetActive(false);
            }
            else
            {
                m_efect[1].SetActive(true);
            }
        }
    }

    void Returnlayer()
    {
        gameObject.layer = LayerName.Shinigami;
    }

    public Vector3 Posinvestigate
    {
        get
        {
            return m_shinigamisPos;
        }
    }
    public float Scale
    {
        get
        {
            return scale.x;
        }
    }   
}