using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TalkManager : MonoBehaviour {

    [SerializeField]
    [Multiline]string[] m_nameArray;

    [SerializeField]
    [Multiline] string[] m_talkArray;

    [SerializeField]
    Text m_name;

    [SerializeField]
    Text m_talk;

    [SerializeField]
    string m_LoadScene;

    int m_line = 0;

    // Use this for initialization
    void Start () {
        m_name.text = m_nameArray[m_line];
        m_talk.text = m_talkArray[m_line];
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return))
        {
            m_line++;
            if (m_line >= m_talkArray.Length)
            {
                SceneManager.LoadScene("Stage1");
            }
            else
            {
                m_name.text = m_nameArray[m_line];
                m_talk.text = m_talkArray[m_line];
            }
        }
	}
}
