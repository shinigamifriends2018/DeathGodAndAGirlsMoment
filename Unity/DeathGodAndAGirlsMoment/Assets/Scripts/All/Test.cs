using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Test : MonoBehaviour {

    SkeletonAnimation m_skeletonAnimation;

	// Use this for initialization
	void Start () {
        m_skeletonAnimation = GetComponent<SkeletonAnimation>();

    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.M))
        {
            m_skeletonAnimation.state.SetAnimation(0, "02. Walk", true);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            m_skeletonAnimation.state.SetAnimation(0, "04. Jump", false);
        }

    }
}
