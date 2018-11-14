using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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
    [SerializeField]
    GameObject[] m_efect;
    [SerializeField]
    GameObject[] m_life;
    bool m_onDamage = false;
    [SerializeField]
    LayerMask m_layer;
    [SerializeField]
    Transform m_ray;
    Vector3 m_rayRot;
    int m_rightCount = 0;
    int m_leftCount = 0;
    bool m_onAI = false;

    // Use this for initialization

    void Start()
    {
        m_hitPoint = 6;
        scale = gameObject.transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        m_jumpPower = 10.5f;
        m_simpleAnimation = GetComponent<SimpleAnimation>();
        m_rayRot = m_ray.transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            m_onAI = true;
        }
        if (m_onAI == true)
        {
            AI();
        }
        if(m_onDamage == true)
        {
            Debug.Log("a");
        }

        if (m_hitPoint <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        if (m_aFeelingOfBelieve >= 3)
        {
            m_efect[1].SetActive(true);
        }
        else
        {
            m_efect[1].SetActive(false);
        }

        if (m_onConnectHands == false)
        {
            m_efect[0].SetActive(false);
            m_moveSpeed = 3.0f;
        }
        else
        {
            if (Mathf.Abs(transform.position.y - shinigami.Posinvestigate.y) > 1.35f)
            {
                m_onConnectHands = false;
            }
            m_efect[0].SetActive(true);
            m_moveSpeed = 4.5f;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (m_onConnectHands == true)
            {
                Jump(rb);
            }
        }
        float s = Input.GetAxisRaw("S");
        if (s < 0)
        {
            if (m_onConnectHands == true)
            {
                Fall();
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

    void AI()
    {
        for(; ; )
        {
            Ray ray = new Ray(m_ray.position, m_ray.transform.forward);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 5.0f, m_layer);
            Debug.DrawRay(ray.origin, ray.direction, Color.red);       
            if (hit.collider)
            {                    
                m_rightCount++;               
            }
            else
            {
                break;
            }
            m_rayRot.x -= 5f;
            m_ray.transform.eulerAngles = m_rayRot;
        }
        m_rayRot.x = 90f;
        m_ray.transform.eulerAngles = m_rayRot;
        for (; ; )
        {
            Ray ray = new Ray(m_ray.position, m_ray.transform.forward);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 5.0f, m_layer);
            Debug.DrawRay(ray.origin, ray.direction, Color.red);

            if (hit.collider)
            {               
                m_leftCount++;                
            }
            else
            {
                break;
            }
            m_rayRot.x += 5f;
            m_ray.transform.eulerAngles = m_rayRot;
        }
        m_rayRot.x = 90f;
        m_ray.transform.eulerAngles = m_rayRot;
        Ray mray = new Ray(m_ray.position, m_ray.transform.forward);
        RaycastHit2D mhit = Physics2D.Raycast(mray.origin, mray.direction, 1.0f, m_layer);
        Debug.DrawRay(mray.origin, mray.direction, Color.red);
    //    while (mhit.collider != null) { 
            if (m_rightCount > m_leftCount)
            {
                transform.Translate(new Vector2(-m_moveSpeed * Time.deltaTime, 0f));
                if (scale.x > 0)
                {
                    scale.x *= -1;
                }
            }
            else
            {
                Move();
                if (scale.x < 0)
                {
                    scale.x *= -1;
                }
            }
      //  }
        Debug.Log(m_rightCount);
        Debug.Log(m_leftCount);
        m_rightCount = 0;
        m_leftCount = 0;  
        m_onAI = false;       
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
                if (m_onAI == false)
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

    public void FollowSwitch()
    {
        if (m_followSwitch == true)
        {
            m_followSwitch = false;
        }
        else
        {
            m_followSwitch = true;
        }
    }
    public bool FollowSwitchTF
    {
        get
        {
            return m_followSwitch;
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

        if (collision.gameObject.tag == "akuryou")
        {           
            if (m_onDamage == false)
            {
                Damage();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Heart")
        {
            if(m_hitPoint < 6)
            {
                m_life[m_hitPoint].SetActive(true);
                m_hitPoint++;
            }
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (m_followSwitch == true)
        {
            if (collision.gameObject.tag == "YJump")
            {
                if (shinigami.Posinvestigate.y - transform.position.y > 0.5f)
                {
                    Jump(rb);
                }
            }
            else if (collision.gameObject.tag == "XJump")
            {
                if (Mathf.Abs(transform.position.x - shinigami.Posinvestigate.x) > 2.5f)
                {
                    Jump(rb);
                }
            }
        }
/*
        if (collision.gameObject.tag == "akuryou")
        {
            Damage();
        }
        */
    }

    void Damage()
    {
        Debug.Log(m_onDamage);
        m_life[m_hitPoint - 1].SetActive(false);
        m_hitPoint--;
        m_aFeelingOfBelieve--;
        if(m_aFeelingOfBelieve < 3)
        {
            m_simpleAnimation.CrossFade("Frightening", 0.02f);
        }
        m_simpleAnimation.Play("Damage");
    }

    public int AddFeelingOfBelieve
    {
        set
        {
            m_aFeelingOfBelieve++;
        }
    }
    void OnDamage()
    {
        Debug.Log("oooo");
        m_onDamage = true;
    }
    void FinishDamage()
    {        
        m_simpleAnimation.Play("Default");       
        m_onDamage = false;
        Debug.Log(m_onDamage);
    }
}