using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTrigger : MonoBehaviour {
    [SerializeField]
    float m_walk = 2f;

    public int m_textCounter = 0;

    public GameObject[] m_ImageDis;

    public GameObject[] m_enemyDisPlay;

    private bool m_imageCheck = true;

    private bool m_pointCheck = true;

    private bool m_enemyTextCheck = false;

    public string[] m_text;

    public Text m_textUI;

    public bool m_returnCheck = false;

    bool m_enemyTextCounter = true;

    public NearController nearController;
    // Use this for initialization
    void Start () {
        m_textUI.text = m_text[m_textCounter];
    }

    // Update is called once per frame
     void Update () {

        Vector2 scale = transform.localScale;
        Vector2 pos = transform.position;

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector2(m_walk * Time.deltaTime, 0f));

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector2(-m_walk * Time.deltaTime, 0f));

        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (m_textCounter == 2)
            {
                TextDisPlay();
                m_ImageDis[0].SetActive(m_imageCheck);    
            }
            else if (m_textCounter == 3)
            {
                Time.timeScale = 1;
                TextDisPlay();
                m_imageCheck = false;
                m_ImageDis[0].SetActive(m_imageCheck);
                m_ImageDis[3].SetActive(m_imageCheck);

            }
            else if(m_textCounter == 5 || m_textCounter == 6 || m_textCounter == 9 )
            {
                TextDisPlay();
            }
            else if (m_textCounter == 7)
            {
                TextDisPlay();
                m_imageCheck = false;
                m_ImageDis[3].SetActive(m_imageCheck);
                Time.timeScale = 1;
                if(m_enemyTextCheck == true)
                {
                    m_ImageDis[2].SetActive(m_imageCheck);
                    Time.timeScale = 1;
                }
            }
            else if (m_textCounter == 10)
            {
                m_imageCheck = false;
                m_ImageDis[2].SetActive(m_imageCheck);
                Time.timeScale = 1;
            }
        }

        if (m_returnCheck == true)
        {
            if (m_enemyTextCounter == true)
            {
                if (m_textCounter == 4)
                {
                    m_imageCheck = true;
                    m_ImageDis[3].SetActive(m_imageCheck);
                    Invoke("TimeDestroy", 0.3f);
                    TextDisPlay();
                    m_enemyTextCounter = false;
                }
                else if (m_textCounter > 5)
                {
                    m_imageCheck = true;
                    m_ImageDis[2].SetActive(m_imageCheck);
                    m_ImageDis[3].SetActive(m_imageCheck);
                    Invoke("TimeDestroy", 0.3f);
                    m_textCounter = 4;
                    TextDisPlay();
                    m_enemyTextCheck = true;
                    m_enemyTextCounter = false;
                }
            }
            m_returnCheck = false;
        }

        transform.localScale = scale;
    }

    public void TextDisPlay()
    {
        ++m_textCounter;
        m_textUI.text = m_text[m_textCounter];
    }

    void TimeDestroy()
    {
        Time.timeScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tutorial1")
        {
            if (m_textCounter == 0)
            {
                TextDisPlay();
            }
        }
        if (collision.gameObject.tag == "Tutorial2")
        {
            if (m_textCounter == 1)
            {
                TextDisPlay();
                m_enemyDisPlay[0].SetActive(m_imageCheck);
                m_enemyDisPlay[1].SetActive(m_imageCheck);
                m_enemyDisPlay[2].SetActive(m_imageCheck);
                m_ImageDis[3].SetActive(m_imageCheck);
                Time.timeScale = 0;
            }
        }
        if (collision.gameObject.tag == "Tutorial3")
        {
            if (m_pointCheck == true)
            {
                if (m_textCounter == 8)
                {
                    TextDisPlay();
                    m_imageCheck = true;
                    m_enemyDisPlay[3].SetActive(m_imageCheck);
                    m_enemyDisPlay[4].SetActive(m_imageCheck);
                    m_ImageDis[3].SetActive(m_imageCheck);
                    Time.timeScale = 0;
                    m_pointCheck = false; 
                }
                else if (m_textCounter < 8)
                {
                    m_textCounter = 8;
                    TextDisPlay();
                    m_imageCheck = true;
                    m_enemyDisPlay[3].SetActive(m_imageCheck);
                    m_enemyDisPlay[4].SetActive(m_imageCheck);
                    m_ImageDis[3].SetActive(m_imageCheck);
                    Time.timeScale = 0;
                    m_pointCheck = false;
                }
            }
        }
    }
}
