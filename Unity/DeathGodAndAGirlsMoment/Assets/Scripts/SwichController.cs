using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwichController : MonoBehaviour {
    
    SimpleAnimation m_simpleAnimation;

    [SerializeField]
    CageDestroy m_cage;

    bool m_switchCheck = false;
    // Use this for initialization
    void Start () {
        m_simpleAnimation = GetComponent<SimpleAnimation>();
    }
	
	// Update is called once per frame
	void Update () {
       
	}

    void PushCheck()
    {
        m_cage.PushCheck = true;
    }
    void PushCheck2()
    {
        m_cage.PushCheck2 = true;
    }
    void ReversePushCheck()
    {
        m_cage.PushCheck = false;
    }
    void ReversePushCheck2()
    {
        m_cage.PushCheck2 = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ("shinigami") || collision.gameObject.tag == ("syoujo"))
        {
            m_simpleAnimation.Play("Change");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("shinigami") || collision.gameObject.tag == ("syoujo"))
        {
            m_simpleAnimation.CrossFade("Reverse", 1f);
        }
    }

}
