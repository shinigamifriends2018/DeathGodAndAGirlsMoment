﻿using System.Collections;
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
            if (m_enemyDisCheck == true)
            {
                if (akuryouPos.x > syoujoPos.x)
                {
                    m_enemyDisCheck = false;
                    m_ChaseEnemy[0].SetActive(true);

                }
                else
                {
                    m_enemyDisCheck = false;
                    m_ChaseEnemy[1].SetActive(true);
                }
            }
        }
    }
}