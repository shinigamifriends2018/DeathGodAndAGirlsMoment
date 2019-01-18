using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    [SerializeField]
    GameObject[] m_gimmickAkuryou;
    [SerializeField]
    GameObject m_door;
    bool m_seCheck = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (m_gimmickAkuryou[0] == null && m_gimmickAkuryou[1] == null && m_gimmickAkuryou[2] == null)
        {
            if (m_seCheck == true)
            {
                SoundManager.Instance.PlaySE((int)Common.SEList.Door);
                m_seCheck = false;
            }
            Destroy(m_door);
        }
	}
}
