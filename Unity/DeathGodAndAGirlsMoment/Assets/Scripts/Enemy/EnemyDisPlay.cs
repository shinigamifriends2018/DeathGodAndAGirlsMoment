
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDisPlay : GhostController {

    bool m_enemyDisCheck = true;
    public GameObject[] m_ChaseEnemy;
    [SerializeField]
    int m_arrayCheck;
    bool m_switchCheck = true;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        Vector2 syoujoPos = m_syoujo.transform.position;
        Vector2 akuryouPos = gameObject.transform.position;
        if (akuryouPos.x - syoujoPos.x <= 5 && akuryouPos.x - syoujoPos.x >= -5)
        {
            if(m_switchCheck == true)
            switch (m_arrayCheck)
            {
                case 2:
                    m_ChaseEnemy[2].SetActive(m_enemyDisCheck);
                    m_arrayCheck--;
                    break;
                case 1:
                    m_ChaseEnemy[1].SetActive(m_enemyDisCheck);
                    m_arrayCheck--;
                    break;
                case 0:
                    m_ChaseEnemy[0].SetActive(m_enemyDisCheck);
                    m_switchCheck = false;
                    break;
            }



        }
    }
}
