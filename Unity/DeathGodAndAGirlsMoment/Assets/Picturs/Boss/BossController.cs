using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour {

    [SerializeField]
    int m_hitPoint = 0;
    // Use this for initialization
    void Start () {
        m_hitPoint = 3;
	}
	
	// Update is called once per frame
	void Update () {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Sickle"))//鎌に当たるとダメージ
        {
            --m_hitPoint;
            if (m_hitPoint == 0)
            {
                Destroy(gameObject, 0.3f);
                SceneManager.LoadScene("Clear");
            }

        }

    }
}
