using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage2Transition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void loadscene()
    {
        ProgressManager.m_nowStage = 2;
        Invoke("transition", 2f);
    }
    void transition()
    {
        SceneManager.LoadScene("Scenario2");
    }
}
