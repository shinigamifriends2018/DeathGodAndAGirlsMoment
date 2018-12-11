using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAkuryouDisPlay : MonoBehaviour {

    [SerializeField]
    GameObject[] m_gimmickAkuryou;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (m_gimmickAkuryou[0] == null && m_gimmickAkuryou[1] == null && m_gimmickAkuryou[2] == null)
        {
            Destroy(gameObject);
            m_gimmickAkuryou[3].SetActive(true);
            m_gimmickAkuryou[4].SetActive(true);
            m_gimmickAkuryou[5].SetActive(true);
            Destroy(this);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "shinigami")
        {
            m_gimmickAkuryou[0].SetActive(true);
            m_gimmickAkuryou[1].SetActive(true);
            m_gimmickAkuryou[2].SetActive(true);
        }
    }
}
