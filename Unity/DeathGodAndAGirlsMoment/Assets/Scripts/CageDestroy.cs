using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageDestroy : MonoBehaviour {

    [SerializeField]
    bool[] m_swichCheck;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

		if(m_swichCheck[0] == true && m_swichCheck[1] == true)
        {
            Destroy(this.gameObject);
        }
    }

    public bool PushCheck
    {
        set
        {
            m_swichCheck[0] = value;
        }
    }
    public bool PushCheck2

    {
        set
        {
            m_swichCheck[1] = value;
        }
    }
}
