using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class SyoujoController : CharacterBase
{
    Vector2 scale;
    [SerializeField]
    int m_aFeelingOfBelieve = 0;
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
    bool m_canAI = false;
    [SerializeField]
    GameObject[] m_AFeelingOfBelieveUI;
    bool m_onFrightening = false;
    [SerializeField]
    GameObject[] m_hints;
    bool m_rightDirection;

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
        /*
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("EE?");
            m_canAI = true;
        }
        */
        if (m_canAI == true)
        {
            m_canAI = false;
            StartCoroutine("AI");
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
                Invoke("Returnlayer", 0.5f);
            }
        }
        float s = Input.GetAxisRaw("S");
        if (s < 0)
        {
            if (m_onConnectHands == true)
            {
                Fall();
                Invoke("Returnlayer", 0.35f);
            }
        }
        if (Input.GetButtonDown("S"))
        {
            if (m_onConnectHands == true)
            {
                Fall();
                Invoke("Returnlayer", 0.35f);
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

    void Direction()
    {
        Debug.Log("a");
        m_rayRot.x = 90f;
        m_ray.transform.eulerAngles = m_rayRot;
        for (int i = 0; i < 18; ++i)
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
        for (int i = 0; i < 18; ++i)
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
        Debug.Log(m_rightCount);
        Debug.Log(m_leftCount);
        if (m_rightCount > m_leftCount)
        {
            m_rightDirection = false;
        }
        else
        {
            m_rightDirection = true;
        }
        m_rightCount = 0;
        m_leftCount = 0;
    }

    IEnumerator AI()
    {
        Direction();
        if(m_rightDirection == true)
        {
            m_rayRot.x = 110f;
            m_ray.transform.eulerAngles = m_rayRot;
            if (scale.x < 0)
            {
                scale.x *= -1;
            }
        }
        else
        {
            m_rayRot.x = 110f;
            m_ray.transform.eulerAngles = m_rayRot;
            if (scale.x > 0)
            {
                scale.x *= -1;
            }
        }
        gameObject.transform.localScale = scale;
        for (; ; )
        {
            Vector2 pos = transform.position;            
            if (m_rightDirection == false)
            {
                pos.x -= m_moveSpeed * Time.deltaTime;               
            }
            else
            {
                pos.x += m_moveSpeed * Time.deltaTime;               
            }            
            transform.position = pos;

            Ray mray = new Ray(m_ray.position, m_ray.transform.forward);
            RaycastHit2D mhit = Physics2D.Raycast(mray.origin, mray.direction, 1.0f, m_layer);
            Debug.DrawRay(mray.origin, mray.direction, Color.red);
            if (mhit.collider == null)
            {
                break;
            }
                yield return null;
        }      
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
                    else
                    {
                        if(transform.position.y - shinigami.Posinvestigate.y > 1f)
                        {
                            Ray ray = new Ray(m_ray.position, m_ray.transform.forward);
                            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 1.0f, m_layer);
                            if (hit.collider)
                            {
                                m_canAI = true;
                                m_onAI = true;
                            }
                        }
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
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Switch")
        {
            m_jump = true;
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
        if(collision.gameObject.tag == "Piece of memory")
        {
            m_hitPoint = 6;
            for(int i = 0; i < 6; i++)
            {
                m_life[i].SetActive(true);
            }
            Destroy(collision.gameObject);          
        }       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (m_followSwitch == true)
        {
            if (m_aFeelingOfBelieve >= 3)
            {
                if (collision.gameObject.tag == "YJump")
                {
                    if (shinigami.Posinvestigate.y - transform.position.y > 0.5f)
                    {
                        Jump(rb);
                        Invoke("Returnlayer", 0.5f);
                    }
                }
                else if (collision.gameObject.tag == "XJump")
                {
                    if (Mathf.Abs(transform.position.x - shinigami.Posinvestigate.x) > 2.5f)
                    {
                        Jump(rb);
                        Invoke("Returnlayer", 0.5f);
                    }
                }
            }
        }
        if (collision.gameObject.tag == "akuryou")
        {
            if (m_onDamage == false)
            {
                m_onDamage = true;
                if(m_aFeelingOfBelieve <= 3)
                {
                    m_onFrightening = true;
                    if (m_onConnectHands == true)
                    {
                        m_onConnectHands = false;
                    }
                    Debug.Log("aaa");
                    m_simpleAnimation.Stop();
                    m_simpleAnimation.Play ("Frightening");                    
                }
                else
                {                  
                    m_simpleAnimation.Play("Damage");
                }
                Damage();
            }
        }
        if (collision.gameObject.tag == "Goal")
        {
            if (m_onConnectHands == true)
            {
                Invoke("Clear", 0.5f);
            }
        }
        if (m_onConnectHands == true)
        {
            if (m_aFeelingOfBelieve >= 5)
            {
                if (collision.gameObject.tag == "HintTrigger")
                {
                    Destroy(collision.gameObject);
                    StartCoroutine("SetActiveHint", 0);
                }
                else if (collision.gameObject.tag == "Hint2Trigger")
                {
                    Destroy(collision.gameObject);
                    StartCoroutine("SetActiveHint", 1);
                }
                else if (collision.gameObject.tag == "Hint4Trigger")
                {
                    Destroy(collision.gameObject);
                    StartCoroutine("SetActiveHint", 3);
                }
            }
        }
    }

    public IEnumerator SetActiveHint(int num)
    {
        m_hints[num].SetActive(true);
        yield return new WaitForSeconds(3f);
        m_hints[num].SetActive(false);     
    }

    void Returnlayer()
    {
        gameObject.layer = LayerName.Syoujo;
    }

    void Da()
    {
        Debug.Log("DaddaDASdsadfd");
    }

    void Damage()
    {
        m_life[m_hitPoint - 1].SetActive(false);
        m_hitPoint--;
        if (m_aFeelingOfBelieve > 0)
        {
            m_AFeelingOfBelieveUI[m_aFeelingOfBelieve - 1].SetActive(false);
            m_aFeelingOfBelieve--;
        }
    }

    void FinishDamage()
    {
        m_simpleAnimation.Play("Default");
        if (m_onFrightening == true)
        {
            m_onFrightening = false;
        }
        m_onDamage = false;
    }

    void FinishFlashing()
    {
        Debug.Log("HA?");
        m_onDamage = false;
    }

    void FinishFrightening()
    {      
        m_simpleAnimation.Play("Default");
        m_onFrightening = false;
    }
    
    public int GetAFeelingOfBelieve
    {
        get
        {
            return m_aFeelingOfBelieve;
        }
    }
    public int AddFeelingOfBelieve
    {
        set
        {
            if (m_aFeelingOfBelieve < 5)
            {
                m_aFeelingOfBelieve++;
                m_AFeelingOfBelieveUI[m_aFeelingOfBelieve - 1].SetActive(true);
            }
        }
    }

    void Clear()
    {
        SceneManager.LoadScene("Clear");
    }

    public bool GetOnFrightening
    {
        get
        {
            return m_onFrightening;
        }
    }
}