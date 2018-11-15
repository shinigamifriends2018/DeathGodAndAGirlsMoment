using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwichController : MonoBehaviour {
    
    SimpleAnimation m_simpleAnimation;
    
    // Use this for initialization
    void Start () {
        m_simpleAnimation = GetComponent<SimpleAnimation>();
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ("shinigami"))
        {
            m_simpleAnimation.Play("Change");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("shinigami"))
        {
            m_simpleAnimation.CrossFade("ReverseChange", 1f);
        }

    }

}
