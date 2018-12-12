using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemyDisPlay : MonoBehaviour {

    [SerializeField]
    GameObject m_disPlayEnemy;
    [SerializeField]
    GameObject[] m_desEnemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (m_desEnemy[0] == null && m_desEnemy[1] == null)
        {
            m_disPlayEnemy.SetActive(true);
            Destroy(this);
        }
    }
}
