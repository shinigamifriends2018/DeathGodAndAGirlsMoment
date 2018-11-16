using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleTransition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void loadscene()
    {
        Invoke("transition", 2f);
    }
    void transition()
    {
        SceneManager.LoadScene("Scenario");
    }
}
