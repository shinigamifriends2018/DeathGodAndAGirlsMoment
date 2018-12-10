using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpot : MonoBehaviour {

    [SerializeField]
    GameObject[] m_EneDis;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "shinigami" || collision.gameObject.tag == "syoujo")
        {
            m_EneDis[0].SetActive(true);
            m_EneDis[1].SetActive(true);
        }
    }
}
