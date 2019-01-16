using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkBallDas : MonoBehaviour {
    
    Vector2 m_farstPosition;
    [SerializeField]
    GameObject m_syoujo;
    Vector2 m_darkBollPos;
    Vector2 syoujoPos;
    // Use this for initialization
    void Start () {
       m_farstPosition = this.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        m_darkBollPos = this.transform.position;
        syoujoPos = m_syoujo.transform.position;
        float m_destroyPos = m_farstPosition.x - m_darkBollPos.x;

        if (m_destroyPos >= 12||m_destroyPos <= -12)
        {
            if (m_darkBollPos.x - syoujoPos.x < 10)
            {
                SoundManager.Instance.PlaySE((int)Common.SEList.DarkMassDestroy);
            }
            Destroy(gameObject, 0.1f);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "syoujo"|| collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Sickle")
        {
            SoundManager.Instance.PlaySE((int)Common.SEList.DarkMassDestroy);
            
            Destroy(gameObject, 0.1f);
        }
    }
    
}