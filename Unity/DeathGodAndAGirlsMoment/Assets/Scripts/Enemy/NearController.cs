using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearController : MonoBehaviour{

    public int m_enemyHP = 2;
    public GameObject m_testmove;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update ()
    {

    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("sinigami"))
        {
         //   SoundManager.Instance.PlaySE((int)Common.SEList.EnemyDamage);
            --m_enemyHP;
            if (m_enemyHP == 0)
            {
                TutorialTrigger testMove = m_testmove.GetComponent<TutorialTrigger>();
                testMove.m_returnCheck = true;
                Destroy(this.gameObject, 0.3f);
            }
        }
    }
}
