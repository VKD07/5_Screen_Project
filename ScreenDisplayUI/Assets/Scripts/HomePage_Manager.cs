using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class HomePage_Manager : MonoBehaviour
{
    [Header("GameObjects Activated/Deactived")]
    [SerializeField] GameObject m_homePage;
    [SerializeField] GameObject m_displayPage;
    [SerializeField] GameObject m_backBtn;

    [Header("Buttons")]
    [SerializeField] Button m_displaySettingsBtn;
    [SerializeField] Button m_fileExplorerBtn;

    [Header("Which folder?")]
    [SerializeField] string folderName;
    private void Start()
    {
        BtnListener();
    }

    private void BtnListener()
    {
        m_displaySettingsBtn.onClick.AddListener(DisplaySettingsBtn);
        m_fileExplorerBtn.onClick.AddListener(FileExplorerBtn);
    }

    public void DisplaySettingsBtn()
    {
        m_displayPage.SetActive(true);
        m_backBtn.SetActive(true);
        m_homePage.SetActive(false);
    }

    public void FileExplorerBtn()
    {
        string videoPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + $"/{folderName}";
        string filePath = EditorUtility.OpenFilePanel("Open File", videoPath, "");
        if (!string.IsNullOrEmpty(filePath))
        {
            // Handle the selected file path
            Debug.Log("Selected file: " + filePath);
            SendUDPMessage($"PLAY:{filePath}");
        }
    }

    public void SendUDPMessage(string p_message)
    {
        UDPSend.GetInstance().SendMessage(p_message);
        print(p_message);
    }
}
