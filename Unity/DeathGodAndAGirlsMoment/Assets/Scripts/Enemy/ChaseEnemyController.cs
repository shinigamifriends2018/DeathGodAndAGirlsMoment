﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemyController : GhostController{


    [SerializeField]
    SyoujoController syoujoController;
  
    int m_feelingBelieve = 0;
    float damageCounter = 0.3f;
    bool  damageCheck  = true;
    int feelingofBellive = 0;
    // Use this for initialization
    void Start () {
        m_hitPoint = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        if(damageCheck == false)
        {
            damageCounter -= Time.deltaTime;
        }
        if(damageCounter < 0)
        {
            damageCounter = 1f;
            damageCheck = true;
        }
        base.m_moveSpeed = 3f;
        base.Chase();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Sickle"))//鎌に当たるとダメージ
        {
            if (damageCheck == true)
            {
                --m_hitPoint;
                damageCheck = false;
            }
            if (m_hitPoint == 0)
            {

                TutorialTrigger tutorialToriger = m_tutorialToriger.GetComponent<TutorialTrigger>();

                tutorialToriger.m_returnCheck = true;
                if (tutorialToriger != null)
                {
                    tutorialToriger.m_returnCheck = true;
                }
                if (damageCheck == false)
                {
                    syoujoController.AddFeelingOfBelieve = m_feelingBelieve;
                    damageCheck = true; 
                }
                SoundManager.Instance.PlaySE((int)Common.SEList.EnemyDestroy);
                Destroy(this.gameObject, 0.3f);
            }

        }
        
    }
}
