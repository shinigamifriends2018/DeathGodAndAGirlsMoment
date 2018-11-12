using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemyController : GhostController{

    [SerializeField]
    ShinigamiController shinigami;
    // Use this for initialization
    void Start () {
        m_hitPoint = 2;
    }
	
	// Update is called once per frame
	void Update ()
    {
        base.m_moveSpeed = 3f;
        base.Chase();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Sickle"))//鎌に当たるとダメージ
        {
            --m_hitPoint;

            if (m_hitPoint == 0)
            {
                TutorialTrigger tutorialToriger = m_tutorialToriger.GetComponent<TutorialTrigger>();
                tutorialToriger.m_returnCheck = true;
                int a = shinigami.GetFeelingBelieve;
                if (a < 5)
                {
                    a++;
                }
                shinigami.SetFeelingBelieve = a;
                Destroy(this.gameObject, 0.3f);
            }

        }
    }
}
