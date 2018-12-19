using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionController : MonoBehaviour {

    SimpleAnimation m_simple;
    float m_difference;
    [SerializeField]
    GameObject m_syoujo;
    float m_actionTimer = 0f;
    // Use this for initialization
    void Start () {
        m_simple= GetComponent<SimpleAnimation>();
	}
	
	// Update is called once per frame
	void Update () {
        m_difference = gameObject.transform.position.x - m_syoujo.transform.position.x;
        m_actionTimer += Time.deltaTime; 
        if (m_difference< 2 && m_difference > -2){
            if (m_actionTimer > 1)
            {
                SoundManager.Instance.PlaySE((int)Common.SEList.NearEnemyAttack);
                m_actionTimer = 0;
            }
            m_simple.Play("Attack");
        }
        else
        {
            m_simple.Play("Default");
        }
    }
}
