using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceofMemoryController : MonoBehaviour {

    [SerializeField]
    GameObject m_pieceofMemory;
    [SerializeField]
    GameObject m_trigger = null;

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
            Destroy(m_trigger);
            m_pieceofMemory.SetActive(true);
        }
    }
}
