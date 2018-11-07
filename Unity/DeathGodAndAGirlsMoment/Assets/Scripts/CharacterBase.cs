using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour {
    [SerializeField]
    protected float m_moveSpeed;
    protected float m_jumpPower;
    [SerializeField]
    protected int m_hitPoint;
    protected SimpleAnimation m_simpleAnimation;
    protected bool m_jump = true;
    protected float m_layerReturnTime = 0.35f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected void Move()
    {
        transform.Translate(new Vector2(m_moveSpeed * Time.deltaTime, 0f));
    }
    protected void Fall()
    {
        gameObject.layer = LayerName.S;
        Invoke("Returnlayer", m_layerReturnTime);
    }
    protected void Jump(Rigidbody2D rb)
    {
        if (m_jump == true)
        {
            rb.AddForce(Vector2.up * m_jumpPower, ForceMode2D.Impulse);
            m_jump = false;
        }
    }
    protected void Damage()
    {
        m_hitPoint--;
    }
    void Returnlayer()
    {
        gameObject.layer = LayerName.Shinigami;
    }
}
