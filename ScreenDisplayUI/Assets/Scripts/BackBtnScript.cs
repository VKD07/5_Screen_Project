using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackBtnScript : MonoBehaviour
{
    [SerializeField] GameObject m_displayPage;
    [SerializeField] GameObject m_homePage;
    [SerializeField] Button m_backBtn;
    void Start()
    {
        m_backBtn.onClick.AddListener(GoBackHome);
    }

    void GoBackHome()
    {
        m_homePage.SetActive(true);
        m_displayPage.SetActive(false);
        m_backBtn.gameObject.SetActive(false);
    }
}
