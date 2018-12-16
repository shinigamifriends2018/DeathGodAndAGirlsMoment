using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossFade : MonoBehaviour {

    [SerializeField]
    SimpleAnimation m_simpleAnimation;

    public bool m_desCheck = false;

    // Use this for initialization
    void Start () {
        m_simpleAnimation = GetComponent<SimpleAnimation>();
	}
	
	// Update is called once per frame
	void Update () {
        if (m_desCheck == true)
        {
            m_simpleAnimation.Play("Fade");
        }
	}
    void Ending()
    {
        SceneManager.LoadScene("Ending");
    }
}
