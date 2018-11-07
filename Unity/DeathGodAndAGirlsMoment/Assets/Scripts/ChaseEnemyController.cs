using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemyController : GhostController{

    [SerializeField]
    GameObject m_tutorialToriger;

    // Use this for initialization
    void Start () {
        m_hitPoint = 2;
    }
	
	// Update is called once per frame
	void Update ()
    {
        base.m_moveSpeed = 3f;
        base.Chase();
        
        if (m_hitPoint == 0)
        {
            TutorialTrigger tutorialToriger = m_tutorialToriger.GetComponent<TutorialTrigger>();
            tutorialToriger.m_returnCheck = true;
            Destroy(this.gameObject, 0.3f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Sickle"))//鎌に当たるとダメージ
        {
            --m_hitPoint;
            Debug.Log("hit");
        }
    }
}
