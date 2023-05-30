using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySettingsManager : MonoBehaviour
{
    [Header("GameObjects Activated/Deactived")]
    [SerializeField] GameObject m_homePage;
    [SerializeField] GameObject m_displayPage;
    [SerializeField] GameObject m_backBtn;

    [Header("ShowDisplay/SelectDisplay_Buttons")]
    [SerializeField] Button m_fullDisplayBtn;
    [SerializeField] Button m_selectDisplayBtn;

    [Header("Display Buttons")]
    [SerializeField] Button[] m_displaysAvailable;

    private void Start()
    {
        BtnListener();
    }

    private void BtnListener()
    {
        m_fullDisplayBtn.onClick.AddListener(FullDisplayBtn);
        m_selectDisplayBtn.onClick.AddListener(SelectDisplayBtn);
    }

    #region FullDisplay/SelectDisplay
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
