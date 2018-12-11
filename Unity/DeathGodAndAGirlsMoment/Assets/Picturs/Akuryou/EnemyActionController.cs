using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionController : MonoBehaviour {

    SimpleAnimation m_simple;
    float m_difference;
    [SerializeField]
    GameObject m_syoujo;
    // Use this for initialization
    void Start () {
        m_simple= GetComponent<SimpleAnimation>();
	}
	
	// Update is called once per frame
	void Update () {
        m_difference = gameObject.transform.position.x - m_syoujo.transform.position.x;

        if (m_difference< 2 && m_difference > -2){
            m_simple.Play("Attack");
        }
        else
        {
            m_simple.Play("Default");
        }
    }
}
