using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkBallDas : MonoBehaviour {

    float m_destroyCount = 5;
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
            m_destroyCount = 5;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject, 1f);
        if (collision.gameObject.tag == ("syoujo"))
        {
            Destroy(this.gameObject, 1f);
        }
    }
}
