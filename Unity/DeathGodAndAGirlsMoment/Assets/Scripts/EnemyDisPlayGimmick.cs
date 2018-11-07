using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDisPlayGimmick :GhostController {

    bool m_enemyDisCheck = true;
    public GameObject[] m_ChaseEnemy;
    [SerializeField]
    GameObject cage;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 syoujoPos = m_syoujo.transform.position;
        Vector2 akuryouPos = m_akuryou.transform.position;
        if (cage == null)
        {
            if (akuryouPos.x > syoujoPos.x)
            {

                m_ChaseEnemy[0].SetActive(m_enemyDisCheck);
            }
            else
            {
                m_ChaseEnemy[1].SetActive(m_enemyDisCheck);
            }
        }
    }
}
