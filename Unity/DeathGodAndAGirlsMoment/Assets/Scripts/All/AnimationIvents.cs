using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationIvents : MonoBehaviour {

    float m_interval = 0.1f;
    [SerializeField]
    ShinigamiController Shinigami;
    [SerializeField]
    GameObject[] m_attackEfect;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnAttack()
    {
        Shinigami.SickleT();
    }

    public void OnAnimationFinished()
    {
        {         
            Shinigami.StartCoroutine("SickleF");
        }
    }

    public void OnAttackFinished()
    {     
        Shinigami.SetAttack2 = true;
    }

    public void OnAttack2Start()
    {
        Shinigami.SetAttack2 = false;
    }

    public void Attack1Efect()
    {
        StartCoroutine("AttackEfect", new Vector2(0f, 0.3f));
    }
    public void Attack2Efect()
    {
        StartCoroutine("AttackEfect", new Vector2(1f, 0.4f));
    }
    public void JumpAttackEfect()
    {
        StartCoroutine("AttackEfect", new Vector2(2f, 0.3f));
    }
    IEnumerator AttackEfect(Vector2 num)
    {
        m_attackEfect[(int)num.x].SetActive(true);
        yield return new WaitForSeconds(num.y);
        m_attackEfect[(int)num.x].SetActive(false);
    }

}
