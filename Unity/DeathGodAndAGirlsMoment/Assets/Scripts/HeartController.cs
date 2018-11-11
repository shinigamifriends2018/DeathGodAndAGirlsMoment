using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("OnDestroy", 5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnDestroy()
    {
        Destroy(gameObject);
    }
}
