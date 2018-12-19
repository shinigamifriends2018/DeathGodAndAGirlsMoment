using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationIvents : MonoBehaviour {

    float m_interval = 0.1f;
    [SerializeField]
    ShinigamiController Shinigami;

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
}
