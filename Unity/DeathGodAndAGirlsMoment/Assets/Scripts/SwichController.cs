using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwichController : MonoBehaviour {
    
    SimpleAnimation m_simpleAnimation;

    public bool m_syoujoPush;
    public bool m_shinigamiPush;

    [SerializeField]
    CageDestroy cage;

    bool pushCheck;
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
            m_shinigamiPush = true;
            cage.shinigamiPush = m_shinigamiPush;
        }
        else if (collision.gameObject.tag == ("syoujo"))
        {
            m_simpleAnimation.Play("Change");
            m_syoujoPush = true;
            cage.syoujoPush = m_syoujoPush;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("shinigami") || collision.gameObject.tag == ("syoujo"))
        {
            m_simpleAnimation.CrossFade("Reverse", 1f);
            m_shinigamiPush = false;
            cage.shinigamiPush = m_shinigamiPush;
            m_syoujoPush = false;
            cage.syoujoPush = m_syoujoPush;
        }

    }

}
