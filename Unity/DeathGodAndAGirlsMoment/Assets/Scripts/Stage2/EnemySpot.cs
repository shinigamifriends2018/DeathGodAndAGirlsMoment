using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpot : MonoBehaviour {

    [SerializeField]
    GameObject[] m_EneDis;

    [SerializeField]
    int m_enemyPoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "syoujo")
        {
            switch (m_enemyPoint)
            {
                case 0:
                    SoundManager.Instance.PlaySE((int)Common.SEList.EnemySporn);
                    m_EneDis[0].SetActive(true);
                    m_EneDis[1].SetActive(true);
                    break;
                case 1:
                    SoundManager.Instance.PlaySE((int)Common.SEList.BossDisPlay);
                    m_EneDis[2].SetActive(true);
                    break;
            }
                

        }
    }
}
