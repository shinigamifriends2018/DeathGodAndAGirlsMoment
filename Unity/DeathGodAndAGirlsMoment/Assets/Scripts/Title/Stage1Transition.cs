﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage1Transition : MonoBehaviour {

    [SerializeField]
    Text m_scoreText;
    // Use this for initialization
    void Start () {
        int score = PlayerPrefs.GetInt("m_acquisitions[1]", 0);
        PlayerPrefs.SetInt("score", score);
        m_scoreText.text = "recovery:" + score * 20+ "%";
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
