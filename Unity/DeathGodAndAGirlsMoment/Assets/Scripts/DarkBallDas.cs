using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkBallDas : MonoBehaviour {

    float m_destroyCount = 2;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        m_destroyCount -= Time.deltaTime;
        Debug.Log((int)m_destroyCount);
        if (m_destroyCount < 0)
        {
            Destroy(this.gameObject, 1f);
            m_destroyCount = 2;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("syoujo")|| collision.gameObject.tag == ("Ground"))
        {
            Destroy( gameObject, 0.1f);
        }
    }
    
}