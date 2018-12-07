using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject m_syoujo;
    public  GameObject m_akuryou;
    [SerializeField]
    float m_enemyMove = 3f;

    // Use this for initialization
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 syoujoPos  = m_syoujo.transform.position; 
        Vector2 akuryouPos = m_akuryou.transform.position;
        float moveDis = m_enemyMove * Time.deltaTime;


        if (akuryouPos.x > syoujoPos.x)
        {
            if (akuryouPos.x - syoujoPos.x > moveDis)
            {
                transform.Translate(new Vector2(-moveDis, 0f));
            }
        }
        else
        {   
            if (syoujoPos.x - akuryouPos.x > moveDis)
            {
                transform.Translate(new Vector2(moveDis, 0f));
            }
        }

    }


}
