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
        m_middleScreen.onClick.AddListener(() => EnableScreen("M_ENABLE"));
        m_leftScreen.onClick.AddListener(() => EnableScreen("S1_ENABLE"));
        m_rightScreen.onClick.AddListener(() => EnableScreen("S2_ENABLE"));
        m_leftAndRightScreen.onClick.AddListener(() => EnableScreen("S1_S2_ENABLE"));
    }

    void EnableScreen(string p_screenName)
    {
        UDPSend.GetInstance().SendUDPMsg(p_screenName);
        print($"{p_screenName} activated ");
    }
}
