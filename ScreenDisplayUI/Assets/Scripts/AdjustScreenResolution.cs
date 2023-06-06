using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustScreenResolution : MonoBehaviour
{
    [Header("Left Screen Buttons")]
    [SerializeField] Button m_leftScreen4by3;
    [SerializeField] Button m_leftScreenFullScreen;
    [Header("Right Screen Buttons")]
    [SerializeField] Button m_rightScreen4by3;
    [SerializeField] Button m_rightScreenFullScreen;
    [Header("MiddleScreen Buttons")]
    [SerializeField] Button m_middleScreen16by9;
    [SerializeField] Button m_middleScreenFullScreen;
    void Start()
    {
        m_leftScreen4by3.onClick.AddListener(() => AdjustResolution4by3("S1_HALVED"));
        m_rightScreen4by3.onClick.AddListener(() => AdjustResolution4by3("S2_HALVED"));
        m_middleScreen16by9.onClick.AddListener(() =>AdjustResolution16by9(" M_HALVED"));

        m_leftScreenFullScreen.onClick.AddListener(() => SetToFullScreen("S1_FULL"));
        m_middleScreenFullScreen.onClick.AddListener(() => SetToFullScreen("M_FULL"));
        m_rightScreenFullScreen.onClick.AddListener(() => SetToFullScreen("S2_FULL"));
    }

    void AdjustResolution4by3(string p_screenName)
    {
        UDPSend.GetInstance().SendUDPMsg(p_screenName);
        print(p_screenName);
    }

    void AdjustResolution16by9(string p_screenName)
    {
        UDPSend.GetInstance().SendUDPMsg(p_screenName);
        print(p_screenName);
    }

    void SetToFullScreen(string p_screenName)
    {
        UDPSend.GetInstance().SendUDPMsg(p_screenName);
        print(p_screenName);
    }
}
