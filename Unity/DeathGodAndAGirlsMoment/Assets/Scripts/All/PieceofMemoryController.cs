using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceofMemoryController : MonoBehaviour {

    [SerializeField]
    GameObject[] m_pieceofMemory;
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
            if (gameObject == m_trigger[0])
            {
                syoujo.PiecePercent = 1;
                m_pieceofMemory[0].SetActive(true);
            }
            if (gameObject == m_trigger[1])
            {
                syoujo.PiecePercent2 = 1;
                m_pieceofMemory[1].SetActive(true);

            }
            if (gameObject == m_trigger[2])
            {
                syoujo.PiecePercent3 = 1;
                m_pieceofMemory[2].SetActive(true); 
            }
            if (gameObject == m_trigger[3])
            {
                syoujo.PiecePercent4 = 1;
                m_pieceofMemory[3].SetActive(true);
            }
            if (gameObject == m_trigger[4])
            {
                syoujo.PiecePercent5 = 1;
                m_pieceofMemory[4].SetActive(true);
            } 
        }
    }
}
