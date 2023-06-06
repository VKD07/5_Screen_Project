using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySettingsManager : MonoBehaviour
{
    [Header("ShowDisplay/SelectDisplay_Buttons -------------------")]
    [SerializeField] Button m_fullDisplayBtn;
    [SerializeField] Button m_selectDisplayBtn;

    [Header("SelectDisplay_Buttons -------------------")]
    [SerializeField] GameObject m_selectDisplayBtns;

    [Header("Display Buttons -------------------")]
    [SerializeField] Button[] m_displaysAvailable;
    private void Start()
    {
        BtnListener();
    }

    private void BtnListener()
    {
        m_fullDisplayBtn.onClick.AddListener(FullDisplayBtn);
        m_selectDisplayBtn.onClick.AddListener(SelectDisplayBtn);

        m_displaysAvailable[0].onClick.AddListener(() => ShowDisplaySetting(0));
        m_displaysAvailable[1].onClick.AddListener(() => ShowDisplaySetting(1));
        m_displaysAvailable[2].onClick.AddListener(() => ShowDisplaySetting(2));
    }

    void FullDisplayBtn()
    {
        print("All Displays Activated");
        UDPSend.GetInstance().SendUDPMsg("All Displays Activated");
    }

    void SelectDisplayBtn()
    {
        m_selectDisplayBtns.SetActive(!m_selectDisplayBtns.activeSelf);
    }

    void ShowDisplaySetting(int btnIndex)
    {
        //getting the child object from the btn
        GameObject btnSettingObj = m_displaysAvailable[btnIndex].gameObject.transform.GetChild(0).gameObject;
        btnSettingObj.SetActive(!btnSettingObj.activeSelf);
    }
}
