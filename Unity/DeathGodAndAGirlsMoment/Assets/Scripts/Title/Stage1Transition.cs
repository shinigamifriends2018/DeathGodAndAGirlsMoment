using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage1Transition : MonoBehaviour {

    [SerializeField]
    Text m_scoreText;
    // Use this for initialization
    void Start () {
        int score = PlayerPrefs.GetInt("m_acquisitions[0]", 0);
        m_scoreText.text = "recovery:" + score * 20+ "%";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void loadscene()
    {
        SoundManager.Instance.PlaySE((int)Common.SEList.Decison);
        ProgressManager.m_nowStage = 1;
        Invoke("transition", 2f);
    }
    void transition()
    {
        SoundManager.Instance.StopBGM();
        SceneManager.LoadScene("Scenario");
    }
}
