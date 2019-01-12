using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTransition : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SoundManager.Instance.PlayBGM((int)Common.BGMList.GameOver);
        Time.timeScale = 1f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Decision"))
        {
            SoundManager.Instance.PlaySE((int)Common.SEList.Decison);
            SoundManager.Instance.StopBGM();
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
