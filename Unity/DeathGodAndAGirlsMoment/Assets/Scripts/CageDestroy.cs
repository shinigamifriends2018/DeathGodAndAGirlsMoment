using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageDestroy : MonoBehaviour {

    [SerializeField]
    bool m_shinigamiPush;
    [SerializeField]
    bool m_syoujoPush;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
       
		if(m_shinigamiPush == true && m_syoujoPush == true)
        {
            Destroy(this.gameObject);
        }
    }

    public bool syoujoPush
    {
        set
        {
            m_syoujoPush = value;
        }
    }
    public bool shinigamiPush
    {
        set
        {
            m_shinigamiPush = value;
        }
    }
}
