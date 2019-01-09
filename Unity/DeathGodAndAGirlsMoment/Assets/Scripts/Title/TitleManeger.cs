using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManeger : MonoBehaviour {

    [SerializeField]
    GameObject m_Button_Stage2;
    [SerializeField]
    GameObject m_Button_Stage3;
    [SerializeField]
    GameObject m_Button_Stage4;

    // Use this for initialization
    void Start () {       
        SetActiveButton();
        SoundManager.Instance.PlayBGM((int)Common.BGMList.Title);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerPrefs.DeleteAll();
        }
	}
    public void SetActiveButton()
    {
        if(ProgressManager.m_clearedStage1 == true)
        {
            m_Button_Stage2.SetActive(true);
        }
/*
        if (ProgressManager.m_clearedStage2 == true)
        {
            m_Button_Stage3.SetActive(true);
        }
        if (ProgressManager.m_clearedStage3 == true)
        {
            m_Button_Stage4.SetActive(true);
        }
 */      
    }
}
