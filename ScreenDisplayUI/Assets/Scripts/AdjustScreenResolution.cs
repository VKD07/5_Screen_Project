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
        BtnListeners();
    }

    private void BtnListeners()
    {
        m_leftScreen4by3.onClick.AddListener(() => SendUDPMessage("S1_HALVED"));
        m_rightScreen4by3.onClick.AddListener(() => SendUDPMessage("S2_HALVED"));
        m_middleScreen16by9.onClick.AddListener(() => SendUDPMessage("M_HALVED"));
        m_leftScreenFullScreen.onClick.AddListener(() => SendUDPMessage("S1_FULL"));
        m_middleScreenFullScreen.onClick.AddListener(() => SendUDPMessage("M_FULL"));
        m_rightScreenFullScreen.onClick.AddListener(() => SendUDPMessage("S2_FULL"));
    }

    public void SendUDPMessage(string p_message)
    {
        UDPSend.GetInstance().SendUDPMsg(p_message);
        print(p_message);
    }

    #region OldCode
    //void AdjustResolution4by3(string p_message)
    //{
    //    UDPSend.GetInstance().SendUDPMsg(p_message);
    //    print(p_message);
    //}

    //void AdjustResolution16by9(string p_message)
    //{
    //    UDPSend.GetInstance().SendUDPMsg(p_message);
    //    print(p_message);
    //}

    //void SetToFullScreen(string p_message)
    //{
    //    UDPSend.GetInstance().SendUDPMsg(p_message);
    //    print(p_message);
    //}
    #endregion
}
