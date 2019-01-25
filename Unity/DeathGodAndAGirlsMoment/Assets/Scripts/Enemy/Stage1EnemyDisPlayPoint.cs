using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1EnemyDisPlayPoint : MonoBehaviour {

    [SerializeField]
    GameObject[] m_disPlayEnemy;
    bool m_fastCheck = true;
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
            if (m_fastCheck == true)
            {
                SoundManager.Instance.PlaySE((int)Common.SEList.EnemySporn);
                m_disPlayEnemy[0].SetActive(true);
                m_disPlayEnemy[1].SetActive(true);
                m_disPlayEnemy[2].SetActive(true);
                m_fastCheck = false;

            }
        }
    }
}
