using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuteRotation : MonoBehaviour{

    public GameObject m_syoujo;
    public GameObject m_akuryou;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update()
    {
        var vec = (m_syoujo.transform.position - m_akuryou.transform.position).normalized;
        m_akuryou.transform.rotation = Quaternion.FromToRotation(Vector3.left, vec);
    }

}
