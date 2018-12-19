using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyController : MonoBehaviour {

    int m_desCheck = 0;
    [SerializeField]
    BossController bossController;
    [SerializeField]
    GameObject[] m_bossEnemy;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Sickle"))
        {
            ++m_desCheck;
            if(m_desCheck == 2)
            {
                if (m_bossEnemy[0] == gameObject) {
                    bossController.m_enemyCheck[0] = true;
                }
                else if (m_bossEnemy[1] == gameObject) {
                    bossController.m_enemyCheck[1] = true;
                }
            }
        }
    }
}
