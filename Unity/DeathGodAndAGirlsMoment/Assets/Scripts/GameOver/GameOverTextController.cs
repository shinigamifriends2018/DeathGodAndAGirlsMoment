using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTextController : MonoBehaviour {

    SimpleAnimation m_simpleAnimation;

	// Use this for initialization
	void Start () {
        m_simpleAnimation = GetComponent<SimpleAnimation>();
        m_simpleAnimation.Play("Default");
	}
	
	// Update is called once per frame
	void Update () {
		
	}  
}
