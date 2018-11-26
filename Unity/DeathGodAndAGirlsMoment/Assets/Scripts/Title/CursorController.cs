using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorController : MonoBehaviour {

    [SerializeField]
    Image m_cursor;
    Vector3 cursorPos;

    [SerializeField]
    Button[] button;

    int length = 0;
    int index = 0;

	// Use this for initialization
	void Start () {
        cursorPos = m_cursor.GetComponent<RectTransform>().localPosition;
        cursorPos.y = 10f;
        m_cursor.GetComponent<RectTransform>().localPosition = cursorPos;   
        if(ProgressManager.m_clearedStage3 == true)
        {
            length = -100;
        }else if(ProgressManager.m_clearedStage2 == true)
        {
            length = -60;
        }else if(ProgressManager.m_clearedStage1 == true)
        {
            length = -20;
        }
        else
        {
            length = 20;
        }
        button[index].Select();
    }
	
	// Update is called once per frame
	void Update () {       
        if (Input.GetButtonDown("Up"))
        {
            if (cursorPos.y <= 0)
            {
                index--;
                button[index].Select();
                cursorPos = m_cursor.GetComponent<RectTransform>().localPosition;
                cursorPos.y += 40f;
                m_cursor.GetComponent<RectTransform>().localPosition = cursorPos;
            }
        }
        float w = Input.GetAxisRaw("Down");
        if (w > 0)
        {
            if (cursorPos.y <= 0)
            {
                index--;
                button[index].Select();
                cursorPos = m_cursor.GetComponent<RectTransform>().localPosition;
                cursorPos.y += 40f;
                m_cursor.GetComponent<RectTransform>().localPosition = cursorPos;
            }
        }

        if (Input.GetButtonDown("Down"))
        {
            if (cursorPos.y >= length)
            {
                index++;
                button[index].Select();
                cursorPos = m_cursor.GetComponent<RectTransform>().localPosition;
                cursorPos.y -= 40f;
                m_cursor.GetComponent<RectTransform>().localPosition = cursorPos;
            }
        }
        float s = Input.GetAxisRaw("Down");
        if (s < 0)
        {
            if (cursorPos.y >= length)
            {
                index++;
                button[index].Select();
                cursorPos = m_cursor.GetComponent<RectTransform>().localPosition;
                cursorPos.y -= 40f;
                m_cursor.GetComponent<RectTransform>().localPosition = cursorPos;
            }
        }
    }
}
