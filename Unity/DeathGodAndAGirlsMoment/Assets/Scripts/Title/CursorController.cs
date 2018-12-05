using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorController : MonoBehaviour {

    float beforeW = 0f;
    float beforeS = 0f;

    [SerializeField]
    Image m_cursor;
    Vector3 cursorPos;

    [SerializeField]
    Button[] button;

    int index;
    int Xindex;
    [SerializeField]
    bool[] m_canSelect;

    bool cancel;
    // Use this for initialization
    void Start () {
 
        index = 0;
        Xindex = 0;
        cursorPos = m_cursor.GetComponent<RectTransform>().localPosition;
        cursorPos.y = -10f;
        m_cursor.GetComponent<RectTransform>().localPosition = cursorPos;   
/*
        if(ProgressManager.m_clearedStage3 == true)
        {
            m_canSelect[1] = true;
            m_canSelect[2] = true;
            m_canSelect[3] = true;
        }else if(ProgressManager.m_clearedStage2 == true)
        {
            m_canSelect[1] = true;
            m_canSelect[2] = true;
            m_canSelect[3] = false;
        }
        else
*/
        if(ProgressManager.m_clearedStage1 == true)
        {
            m_canSelect[1] = true;
            m_canSelect[2] = false;
            m_canSelect[3] = false;
        }
        else
        {
            m_canSelect[1] = false;
            m_canSelect[2] = false;
            m_canSelect[3] = false;
        }
        m_canSelect[0] = true;       
        button[0].Select();       
    }
	
	// Update is called once per frame
	void Update () {         

        if (Input.GetButtonDown("Up"))
        {
            UpSetSelect();           
        }
        float w = Input.GetAxisRaw("Up");        
        if (w < 0 && beforeW == 0)
        {
            UpSetSelect();          
        }

        if (Input.GetButtonDown("Down"))
        {           
            DownSetSelect();
        }
        float s = Input.GetAxisRaw("Down");        
        if (s < 0 && beforeS == 0)
        {            
            DownSetSelect();
        }

        beforeW = w;
        beforeS = s;
    }

    void UpSetSelect()
    {       
        if (cursorPos.y <= -20)
        {
            index--;
            cursorPos = m_cursor.GetComponent<RectTransform>().localPosition;
            cursorPos.y += 220f;
            m_cursor.GetComponent<RectTransform>().localPosition = cursorPos;
        }     
        if (m_canSelect[index] == true)
        {
            Xindex = index;
            button[Xindex].Select();
        }
        else
        {           
            Xindex = 4;
            button[Xindex].Select();
        }
        cancel = true;
    }
    void DownSetSelect()
    {        
        if (cursorPos.y >= -180)
        {
            index++;
            cursorPos = m_cursor.GetComponent<RectTransform>().localPosition;
            cursorPos.y -= 220f;
            m_cursor.GetComponent<RectTransform>().localPosition = cursorPos;
        }

        if (m_canSelect[index] == true)
        {
            Xindex = index;
            button[Xindex].Select();
        }
        else
        {          
            Xindex = 4;
            button[Xindex].Select();
        }
        cancel = true;
    }
}
