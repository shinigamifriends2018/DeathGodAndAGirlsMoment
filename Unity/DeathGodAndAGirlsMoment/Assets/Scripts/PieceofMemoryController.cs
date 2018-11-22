using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceofMemoryController : MonoBehaviour {

    [SerializeField]
    GameObject m_pieceofMemory;
    [SerializeField]
    GameObject []m_trigger ;
    [SerializeField]
    SyoujoController syoujo;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "syoujo")
        {
            m_pieceofMemory.SetActive(true);
            if (gameObject == m_trigger[0])
            {
                syoujo.PiecePercent= 0;
                syoujo.GetPieceCheck = 1;

            }
            if (gameObject == m_trigger[1])
            {
                syoujo.PiecePercent2 = 0;
                syoujo.GetPieceCheck2 = 1;
            }
            if (gameObject == m_trigger[2])
            {
                syoujo.PiecePercent3 = 0;
                syoujo.GetPieceCheck3 = 1;
            }
            if (gameObject == m_trigger[3])
            {
                syoujo.PiecePercent4 = 0;
                syoujo.GetPieceCheck4 = 1;
            }
            if (gameObject == m_trigger[4])
            {
                syoujo.PiecePercent5 = 0;
                syoujo.GetPieceCheck5 = 1;
            } 
        }
    }
}
