using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage1Transition : MonoBehaviour {

    [SerializeField]
    Text m_scoreText;
    int scores;
    // Use this for initialization
    void Start () {
        scores = PlayerPrefs.GetInt("score", 0);
        PlayerPrefs.SetInt("scores", scores);
        m_scoreText.text = "recovery:" + scores * 20+ "%";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void loadscene()
    {
        ProgressManager.m_nowStage = 1;
        Invoke("transition", 2f);
    }
    void transition()
    {
        SceneManager.LoadScene("Scenario");
    }
}
