using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    Vector3 pos;
    [SerializeField]
    ShinigamiController shinigami;
    bool m_fixedTF = false;
    [SerializeField]
    float m_size;
    bool m_die = false;
    [SerializeField]
    Transform m_syoujo;
    bool m_canMove = true;

    // Use this for initialization
    void Start()
    {
        pos = transform.position;
        m_size = 5.5f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(m_die == true)
        {
            Die();
        }
        else if (m_fixedTF == true)
        {

            Fixed();

        }
        else
        {
            if (pos.x <= -5.6f)
            {
                pos.x = -5.6f;
            }else if(pos.x >= 126.6)
            {
                pos.x = 126.6f;
            }
            if (Camera.main.orthographicSize != m_size)
            {
                Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, m_size, 0.1f);
            }

            if (m_canMove == true)
            {
                if (shinigami.Scale > 0)
                {
                    pos = Vector3.Lerp(pos, new Vector3(shinigami.Posinvestigate.x + 2.4f, pos.y, pos.z), 0.05f);
                }
                else
                {
                    pos = Vector3.Lerp(pos, new Vector3(shinigami.Posinvestigate.x - 2.4f, pos.y, pos.z), 0.05f);
                }
            }

            if (pos.y > shinigami.Posinvestigate.y)
            {
                if (Mathf.Abs(pos.y - shinigami.Posinvestigate.y) > 2.145f)
                {
                    pos.y = shinigami.Posinvestigate.y + 2.145f;
                }
            }
            else
            {
                if (Mathf.Abs(pos.y - shinigami.Posinvestigate.y) > 0.5f)
                {
                    pos.y = shinigami.Posinvestigate.y - 0.5f;
                }
            }
        }
        transform.position = pos;
    }
    public bool FixedSet
    {
        set
        {
            m_fixedTF = value;
        }
    }
    void Fixed()
    {
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 5f, 0.1f);
        pos = Vector3.Lerp(pos, new Vector3(64.976f, 0.2f, pos.z), 0.05f);
    }
    void Die()
    {
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 1.2f, 0.1f);
        pos = Vector3.Lerp(pos, new Vector3(m_syoujo.localPosition.x + 1f, m_syoujo.position.y, pos.z), 0.05f);
    }
    public bool Set
    {
        set
        {
            m_die = value;
        }
    }
    public bool SetCanMove
    {
        set
        {
            m_canMove = value;
        }
    }
}