using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using Spine.Unity;


public class SyoujoController : CharacterBase
{
    Vector3 scale;
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
    LayerMask[] m_layer;
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
    [SerializeField]
    int[] m_acquisitions;
    [SerializeField]
    int[] m_acquisitionsBox;

    [SerializeField]
    GameObject[] m_pieceofMemory;
    [SerializeField]
    GameObject[] m_pieceofMemoryUI;
    [SerializeField]
    GameObject m_getPieceOfMemory;
    [SerializeField]
    CameraController camera;   
    [SerializeField]
    bool[] getCheck;
    [SerializeField]
    SkeletonAnimation m_skeletonAnimation;
    bool m_onAnimation;
    float m_beforePos;
    bool m_canWalk = false;
    bool m_nouWalk = false;

    // Use this for initialization
    private void Awake()
    {
        m_acquisitionsBox[0] = PlayerPrefs.GetInt("m_acquisitionsBox[0]", 0);
        m_acquisitionsBox[1] = PlayerPrefs.GetInt("m_acquisitionsBox[1]", 0);
        m_acquisitionsBox[2] = PlayerPrefs.GetInt("m_acquisitionsBox[2]", 0);
        m_acquisitionsBox[3] = PlayerPrefs.GetInt("m_acquisitionsBox[3]", 0);
        m_acquisitionsBox[4] = PlayerPrefs.GetInt("m_acquisitionsBox[4]", 0);
        m_acquisitionsBox[5] = PlayerPrefs.GetInt("m_acquisitionsBox[5]", 0);
        m_acquisitionsBox[6] = PlayerPrefs.GetInt("m_acquisitionsBox[6]", 0);
        m_acquisitionsBox[7] = PlayerPrefs.GetInt("m_acquisitionsBox[7]", 0);
        m_acquisitionsBox[8] = PlayerPrefs.GetInt("m_acquisitionsBox[8]", 0);
        m_acquisitionsBox[9] = PlayerPrefs.GetInt("m_acquisitionsBox[9]", 0);
        if (ProgressManager.m_nowStage == 1)
        {
            m_acquisitions[0] = 0;
            m_acquisitions[0] += m_acquisitionsBox[0];
            m_acquisitions[0] += m_acquisitionsBox[1];
            m_acquisitions[0] += m_acquisitionsBox[2];
            m_acquisitions[0] += m_acquisitionsBox[3];
            m_acquisitions[0] += m_acquisitionsBox[4];
        }
        if (ProgressManager.m_nowStage == 2)
        {
            m_acquisitions[1] = 0;
            m_acquisitions[1] += m_acquisitionsBox[5];
            m_acquisitions[1] += m_acquisitionsBox[6];
            m_acquisitions[1] += m_acquisitionsBox[7];
            m_acquisitions[1] += m_acquisitionsBox[8];
            m_acquisitions[1] += m_acquisitionsBox[9];
        }

    }

    void Start()
    {
        if(ProgressManager.m_nowStage == 1)
        {
            SoundManager.Instance.PlayBGM((int)Common.BGMList.Stage1);
        }
        if(ProgressManager.m_nowStage == 2)
        {
            SoundManager.Instance.PlayBGM((int)Common.BGMList.Stage2);
        }
        if (m_acquisitionsBox[0] == 1)
        {
            getCheck[0] = true;
        }
        if (m_acquisitionsBox[1] == 1)
        {
            getCheck[1] = true;
        }
        if (m_acquisitionsBox[2] == 1)
        {
            getCheck[2] = true;
        }
        if (m_acquisitionsBox[3] == 1)
        {
            getCheck[3] = true;
        }
        if (m_acquisitionsBox[4] == 1)
        {
            getCheck[4] = true;
        }
        if (m_acquisitionsBox[5] == 1)
        {
            getCheck[5] = true;
        }
        if (m_acquisitionsBox[6] == 1)
        {
            getCheck[6] = true;
        }
        if (m_acquisitionsBox[7] == 1)
        {
            getCheck[7] = true;
        }
        if (m_acquisitionsBox[8] == 1)
        {
            getCheck[8] = true;
        }
        if (m_acquisitionsBox[9] == 1)
        {
            getCheck[9] = true;
        }
        m_hitPoint = 6;
        scale = gameObject.transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        m_jumpPower = 10.5f;
        m_simpleAnimation = GetComponent<SimpleAnimation>();
        m_rayRot = m_ray.transform.rotation.eulerAngles;

        m_aFeelingOfBelieve = PlayerPrefs.GetInt("aFeelingOfBelieve", 0);
        if (m_aFeelingOfBelieve != 0)
        {
            for (int i = m_aFeelingOfBelieve; i >= 0; i--)
            {              
                m_AFeelingOfBelieveUI[i - 1].SetActive(true);
            }
        }
        m_beforePos = gameObject.transform.position.x;
      
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(m_nouWalk);
        if (m_beforePos != gameObject.transform.position.x)
        {
            m_canWalk = true;
        }
        else
        {
            m_canWalk = false;
            m_nouWalk = false;
        }
        if ((m_jump == true) && (m_canWalk == false))
        {
            m_skeletonAnimation.state.SetAnimation(0, "01. Idle", true);
            Debug.Log("II");
        }
        if (m_canWalk == true)
        {
            if (m_nouWalk == false)
            {
                m_skeletonAnimation.state.SetAnimation(0, "03. Run", true);
            }
            m_nouWalk = true;
            Debug.Log("RR");
        }
        m_beforePos = transform.position.x;
        Ray ray = new Ray(m_ray.position, m_ray.transform.forward);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 0.8f, m_layer[0]);
        if (hit.collider)
        {
            m_jump = true;
        }
        else
        {
            m_jump = false;
        }       
        if (m_canAI == true)
        {
            m_canAI = false;
            StartCoroutine("AI");
        }

        if (m_hitPoint <= 0)
        {
            StartCoroutine("DieS");
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
                StartCoroutine("Animation", 1.2f);
                m_skeletonAnimation.state.SetAnimation(0, "04. Jump", false);
                Invoke("Returnlayer", 0.5f);
            }
        }    
        float s = Input.GetAxis("S");
        if (s < -0.9f)
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


    IEnumerator Animation(float m_time)
    {
        m_onAnimation = true;
        yield return new WaitForSeconds(m_time);
        m_onAnimation = false;
    }

    void Direction()
    {      
        m_rayRot.x = 90f;
        m_ray.transform.eulerAngles = m_rayRot;
        for (int i = 0; i < 18; ++i)
        {
            Ray ray = new Ray(m_ray.position, m_ray.transform.forward);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 5.0f, m_layer[1]);           
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
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 5.0f, m_layer[1]);           

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
        if (m_rightDirection == true)
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
            RaycastHit2D mhit = Physics2D.Raycast(mray.origin, mray.direction, 1.0f, m_layer[1]);          
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
                            m_simpleAnimation.CrossFade("Walk", 0.2f);
                            if (scale.x > 0)
                            {
                                scale.x *= -1;
                            }
                        }
                        gameObject.transform.localScale = scale;
                    }
                    else
                    {
                        if (transform.position.y - shinigami.Posinvestigate.y > 1f)
                        {
                            Ray ray = new Ray(m_ray.position, m_ray.transform.forward);
                            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 1.0f, m_layer[1]);
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Heart")
        {
            SoundManager.Instance.PlaySE((int)Common.SEList.GetHeart);
            if (m_hitPoint < 6)
            {
                m_life[m_hitPoint].SetActive(true);
                m_hitPoint++;
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Piece of memory")
        {
            StartCoroutine("SetActiveEfect");            
            Destroy(collision.gameObject);
            StartCoroutine("LifeRecovery");
            SoundManager.Instance.PlaySE((int)Common.SEList.GetPiceofMemori);
        }
    }

    public int PiecePercent
    {
        get
        {
            return m_acquisitionsBox[0];
        }
        set
        {
            if (ProgressManager.m_nowStage == 1)
            {
                m_acquisitionsBox[0] = 1;
                if (getCheck[0] == false)
                {
                    m_acquisitions[0] += m_acquisitionsBox[0];
                }
            }
            if (ProgressManager.m_nowStage == 2)
            {
                m_acquisitionsBox[5] = 1;
                if (getCheck[5] == false)
                {
                    m_acquisitions[1] += m_acquisitionsBox[0];
                }
            }
        }
    }
    public int PiecePercent2
    {
        get
        {
            return m_acquisitionsBox[1];
        }
        set
        {
            if (ProgressManager.m_nowStage == 1)
            {
                m_acquisitionsBox[1] = 1;
                if (getCheck[1] == false)
                {
                    m_acquisitions[0] += m_acquisitionsBox[1];
                }
            }
            if (ProgressManager.m_nowStage == 2)
            {
                m_acquisitionsBox[6] = 1;
                if (getCheck[6] == false)
                {
                    m_acquisitions[1] += m_acquisitionsBox[6];
                }
            }
        }
    }
    public int PiecePercent3
    {
        get
        {
            return m_acquisitionsBox[2];
        }
        set
        {
            if (ProgressManager.m_nowStage == 1)
            {
                m_acquisitionsBox[2] = 1;
                if (getCheck[2] == false)
                {
                    m_acquisitions[0] += m_acquisitionsBox[2];
                }
            }
            if (ProgressManager.m_nowStage == 2)
            {
                m_acquisitionsBox[7] = 1;
                if (getCheck[7] == false)
                {
                    m_acquisitions[1] += m_acquisitionsBox[7];
                }
            }
        }
    }
    public int PiecePercent4
    {
        get
        {
            return m_acquisitionsBox[3];
        }
        set
        {
            if (ProgressManager.m_nowStage == 1)
            {
                m_acquisitionsBox[3] = 1;
                if (getCheck[3] == false)
                {
                    m_acquisitions[0] += m_acquisitionsBox[3];
                }
            }
            if (ProgressManager.m_nowStage == 2)
            {
                m_acquisitionsBox[8] = 1;
                if (getCheck[8] == false)
                {
                    m_acquisitions[1] += m_acquisitionsBox[8];
                }
            }
        }
    }
    public int PiecePercent5
    {
        get
        {
            return m_acquisitionsBox[4];
        }
        set
        {
            if (ProgressManager.m_nowStage == 1)
            {
                m_acquisitionsBox[4] = 1;
                if (getCheck[4] == false)
                {
                    m_acquisitions[0] += m_acquisitionsBox[4];
                }
            }
            if (ProgressManager.m_nowStage == 2)
            {
                m_acquisitionsBox[9] = 1;
                if (getCheck[9] == false)
                {
                    m_acquisitions[1] += m_acquisitionsBox[9];
                }
            }
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

    IEnumerator SetActiveEfect()
    {
        m_getPieceOfMemory.SetActive(true);
        yield return new WaitForSeconds(2f);
        m_getPieceOfMemory.SetActive(false);
    }

    IEnumerator LifeRecovery()
    {
        m_hitPoint = 6;
        for (int i = 0; i < 6; i++)
        {
            m_life[i].SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator DieS()
    {
        Time.timeScale = 0;
        camera.Set = true;       
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("GameOver");
    }

    void Returnlayer()
    {
        gameObject.layer = LayerName.Syoujo;
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
        PlayerPrefs.SetInt("m_acquisitions[0]", m_acquisitions[0]);
        PlayerPrefs.SetInt("m_acquisitions[1]", m_acquisitions[1]);
        PlayerPrefs.SetInt("m_acquisitionsBox[0]", m_acquisitionsBox[0]);
        PlayerPrefs.SetInt("m_acquisitionsBox[1]", m_acquisitionsBox[1]);
        PlayerPrefs.SetInt("m_acquisitionsBox[2]", m_acquisitionsBox[2]);
        PlayerPrefs.SetInt("m_acquisitionsBox[3]", m_acquisitionsBox[3]);
        PlayerPrefs.SetInt("m_acquisitionsBox[4]", m_acquisitionsBox[4]);
        PlayerPrefs.SetInt("m_acquisitionsBox[5]", m_acquisitionsBox[5]);
        PlayerPrefs.SetInt("m_acquisitionsBox[6]", m_acquisitionsBox[6]);
        PlayerPrefs.SetInt("m_acquisitionsBox[7]", m_acquisitionsBox[7]);
        PlayerPrefs.SetInt("m_acquisitionsBox[8]", m_acquisitionsBox[8]);
        PlayerPrefs.SetInt("m_acquisitionsBox[9]", m_acquisitionsBox[9]);
        PlayerPrefs.SetInt("aFeelingOfBelieve", m_aFeelingOfBelieve);
        PlayerPrefs.Save();
        if (ProgressManager.m_nowStage == 3)
        {
            ProgressManager.m_clearedStage3 = true;
        }
        else if (ProgressManager.m_nowStage == 2)
        {
            ProgressManager.m_clearedStage2 = true;
        }
        else if (ProgressManager.m_nowStage == 1)
        {
            ProgressManager.m_clearedStage1 = true;
        }
        SoundManager.Instance.PlaySE((int)Common.SEList.Goal);
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