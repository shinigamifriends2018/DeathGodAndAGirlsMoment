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
        SoundManager.Instance.PlayBGM((int)Common.BGMList.Clear);
        int score = PlayerPrefs.GetInt("m_acquisitions[0]",0);
        m_scoreText.text = "recovery" + "   " + score * 20 + "%";
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Decision"))
        {
            SoundManager.Instance.PlaySE((int)Common.SEList.Decison);
            SoundManager.Instance.StopBGM();
            SceneManager.LoadScene("Title");
        }

        if(ProgressManager.m_nowStage == 1)
        {
            ProgressManager.m_clearStage1 = true;
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
