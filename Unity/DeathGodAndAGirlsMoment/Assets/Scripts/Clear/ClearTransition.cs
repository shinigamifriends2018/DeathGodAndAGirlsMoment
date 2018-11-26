using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearTransition : MonoBehaviour {

    [SerializeField]
    Text m_scoreText;

    // Use this for initialization
    void Start () {
        int score = PlayerPrefs.GetInt("m_acquisitions",0);
        m_scoreText.text = "recovery" + "   " + score + "%";
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Decision"))
        {
                SceneManager.LoadScene("Title");
        }
    }
//    public void loadscene()
//    {
//        Invoke("transition", 2f);
//    }
//    void transition()
//    {
//        SceneManager.LoadScene("Title");
//    }
}
