using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    Vector3 pos;
    [SerializeField]
    ShinigamiController shinigami;
    bool m_fixedTF = false;

    // Use this for initialization
    void Start()
    {
        pos = transform.position;        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (m_fixedTF == true)
        {

            Fixed();

        }
        else
        {

            if(Camera.main.orthographicSize != 3f)
            {
                Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 3f, 0.1f);
            }
            if (shinigami.Scale > 0)
            {
                pos = Vector3.Lerp(pos, new Vector3(shinigami.Posinvestigate.x + 2.4f, pos.y, pos.z), 0.05f);
            }
            else
            {
                pos = Vector3.Lerp(pos, new Vector3(shinigami.Posinvestigate.x - 2.4f, pos.y, pos.z), 0.05f);
            }

            if (pos.y > shinigami.Posinvestigate.y)
            {
                if (Mathf.Abs(pos.y - shinigami.Posinvestigate.y) > 0.745f)
                {
                    pos.y = shinigami.Posinvestigate.y + 0.745f;
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
}