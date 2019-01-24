using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1EnemyDisPlayPoint : MonoBehaviour {

    [SerializeField]
    GameObject[] m_disPlayEnemy;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "syoujo")
        {
            SoundManager.Instance.PlaySE((int)Common.SEList.EnemySporn);
            m_disPlayEnemy[0].SetActive(true);
            m_disPlayEnemy[1].SetActive(true);
            m_disPlayEnemy[2].SetActive(true);
        }
    }
}
