using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TalkManager : MonoBehaviour {

    [SerializeField]
    string[] m_nameArray;

    [SerializeField]
    [Multiline] string[] m_talkArray;

    [SerializeField]
    int[] m_leftFaceNoArray;

    [SerializeField]
    int[] m_rightFaceNoArray;

    [SerializeField]
    Sprite[] m_deathGodSprites;

    [SerializeField]
    Sprite[] m_girlSprites;

    [SerializeField]
    Image m_deathGodImage;

    [SerializeField]
    Image m_girlImage;


    [SerializeField]
    Text m_name;

    [SerializeField]
    Text m_talk;

    [SerializeField]
    string m_LoadScene;

    [SerializeField]
    int m_Standingpicture;

    int m_line = 0;

    // Use this for initialization
    void Start () {
        m_name.text = m_nameArray[m_line];
        m_talk.text = m_talkArray[m_line];
        int leftFaceNo = m_leftFaceNoArray[m_line];
        if(leftFaceNo >= 0)
        {
            m_deathGodImage.enabled = true;
            m_deathGodImage.sprite = m_deathGodSprites[leftFaceNo];
        }
        else
        {
            m_deathGodImage.enabled = false;
        }

        int rightFaceNo = m_rightFaceNoArray[m_line];
        if (rightFaceNo >= 0)
        {
            m_girlImage.enabled = true;
            m_girlImage.sprite = m_girlSprites[rightFaceNo];
        }
        else
        {
            m_girlImage.enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Decision"))
        {
            m_line++;
            if (m_line >= m_talkArray.Length)
            {
                SceneManager.LoadScene(m_LoadScene);
            }
            else
            {
                m_name.text = m_nameArray[m_line];
                m_talk.text = m_talkArray[m_line];
                int leftFaceNo = m_leftFaceNoArray[m_line];
                if (leftFaceNo >= 0)
                {
                    m_deathGodImage.enabled = true;
                    m_deathGodImage.sprite = m_deathGodSprites[leftFaceNo];
                }
                else
                {
                    m_deathGodImage.enabled = false;
                }

                int rightFaceNo = m_rightFaceNoArray[m_line];
                if (rightFaceNo >= 0)
                {
                    m_girlImage.enabled = true;
                    m_girlImage.sprite = m_girlSprites[rightFaceNo];
                }
                else
                {
                    m_girlImage.enabled = false;
                }
            }
        }
	}
}
