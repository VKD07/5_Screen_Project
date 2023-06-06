using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectDisplayManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] Button m_middleScreen;
    [SerializeField] Button m_leftScreen;
    [SerializeField] Button m_rightScreen;
    [SerializeField] Button m_leftAndRightScreen;
    void Start()
    {
        m_middleScreen.onClick.AddListener(() => SendUDPMessage("M_ENABLE"));
        m_leftScreen.onClick.AddListener(() => SendUDPMessage("S1_ENABLE"));
        m_rightScreen.onClick.AddListener(() => SendUDPMessage("S2_ENABLE"));
        m_leftAndRightScreen.onClick.AddListener(() => SendUDPMessage("S1_S2_ENABLE"));
    }

    void SendUDPMessage(string p_message)
    {
        UDPSend.GetInstance().SendUDPMsg(p_message);
        //udp.SendUDPMsg(p_screenName);
        print($"{p_message} activated ");
    }
}
