using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Vector3 pos;
    [SerializeField]
    ShinigamiController shinigami;

	// Use this for initialization
	void Start () {
        pos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		if(shinigami.Scale > 0)
        {
          //  pos = Vector3.Lerp(new Vector3(pos.y, pos.x, pos.z), new Vector3(pos.y, shinigami.Posinvestigate.x + 2.4f, pos.z), 1f);
            pos.x = shinigami.Posinvestigate.x + 2.4f;
        }
        else
        {
            pos.x = shinigami.Posinvestigate.x - 2.4f;
        }

        if (pos.y > shinigami.Posinvestigate.y)
        {
            if(Mathf.Abs(pos.y - shinigami.Posinvestigate.y) > 0.745f)
            {
                pos.y = shinigami.Posinvestigate.y + 0.745f;
            }
        }
        else
        {
            if(Mathf.Abs(pos.y - shinigami.Posinvestigate.y) > 0.5f)
            {
                pos.y = shinigami.Posinvestigate.y - 0.5f;
            }
        }
        transform.position = pos;
	}
}
