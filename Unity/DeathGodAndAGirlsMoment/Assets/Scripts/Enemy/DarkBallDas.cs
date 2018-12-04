﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkBallDas : MonoBehaviour {
    
    Vector2 m_farstPosition;
    // Use this for initialization
    void Start () {
       m_farstPosition = this.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 m_darkBollPos = this.transform.position;
        float m_destroyPos = m_farstPosition.x - m_darkBollPos.x;

        if (m_destroyPos >= 12||m_destroyPos <= -12)
        {
            Destroy(this.gameObject, 0.1f);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "syoujo"|| collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Sickle")
        {
            Destroy( gameObject, 0.1f);
        }
    }
    
}