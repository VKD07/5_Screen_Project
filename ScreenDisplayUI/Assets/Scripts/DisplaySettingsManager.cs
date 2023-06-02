using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySettingsManager : MonoBehaviour
{
    [Header("GameObjects Activated/Deactived")]
    [SerializeField] GameObject m_homePage;
    [SerializeField] GameObject m_displayPage;
    [SerializeField] GameObject m_backBtn;

    [Header("ShowDisplay/SelectDisplay_Buttons -------------------")]
    [SerializeField] Button m_fullDisplayBtn;
    [SerializeField] Button m_selectDisplayBtn;

    [Header("Display Buttons -------------------")]
    [SerializeField] Button[] m_displaysAvailable;

    [Header("Screen Resolution buttons -------------------")]
    [SerializeField] Button[] m_btn4by3;
    [SerializeField] Button m_btn16by9;
    [SerializeField] Button[] m_fullScreenBtns;

    [Header("Screen Displays")]
    [SerializeField] GameObject[] m_screenDisplays;

    private void Start()
    {
        BtnListener();
    }

    private void BtnListener()
    {
        m_fullDisplayBtn.onClick.AddListener(FullDisplayBtn);
        m_selectDisplayBtn.onClick.AddListener(SelectDisplayBtn);

        m_displaysAvailable[0].onClick.AddListener(() => ShowSetting(0));
        m_displaysAvailable[1].onClick.AddListener(() => ShowSetting(1));
        m_displaysAvailable[2].onClick.AddListener(() => ShowSetting(2));

        m_btn4by3[0].onClick.AddListener(() => AdjustResolutionTo4By3(0));
        m_btn4by3[1].onClick.AddListener(() => AdjustResolutionTo4By3(1));

        m_fullScreenBtns[0].onClick.AddListener(() => SetFullScreenMode(0));
        m_fullScreenBtns[1].onClick.AddListener(() => SetFullScreenMode(1));
        m_fullScreenBtns[2].onClick.AddListener(() => SetFullScreenMode(2));
    }

    void ShowSetting(int btnIndex)
    {
        //getting the child object from the btn
        GameObject btnSettingObj = m_displaysAvailable[btnIndex].gameObject.transform.GetChild(0).gameObject;
        btnSettingObj.SetActive(!btnSettingObj.activeSelf);
    }

    void AdjustResolutionTo4By3(int btnIndex)
    {
        if(btnIndex == 0)
        {
            print("Screen Adjusted by 4:3, Right");
        }
        else
        {
            print("Screen Adjusted by 4:3, Left");
        }
    }

    void SetFullScreenMode(int btnIndex)
    {

    }

    #region FullDisplay/SelectDisplay_Option
    void FullDisplayBtn()
    {
        ChangeDisplayBtnColors(Color.white);
        //acivate all screen displays
    }

    void SelectDisplayBtn()
    {
        ChangeDisplayBtnColors(Color.grey);
    }

    #endregion
    void ChangeDisplayBtnColors(Color color)
    {
        for (int i = 0; i < m_displaysAvailable.Length; i++)
        {
            var colors = m_displaysAvailable[i].colors;
            colors.normalColor = color;
            m_displaysAvailable[i].GetComponent<Button>().colors = colors;
        }
    }
}
