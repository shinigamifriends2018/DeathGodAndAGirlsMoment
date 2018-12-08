using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour {

    [SerializeField]
    int m_hitPoint = 0;
    // Use this for initialization
    void Start () {
        m_hitPoint = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if(m_hitPoint == 0)
        {
            SceneManager.LoadScene("Clear");
        }
	}
}
