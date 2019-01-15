using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CageSound()
    {

        SoundManager.Instance.PlaySE((int)Common.SEList.Cage);
    }
}
