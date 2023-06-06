using UnityEngine;
using System.IO;
using System;

public class ConfigManager : MonoBehaviour
{
    private static ConfigManager _instance;

    [Header("File")]
    [SerializeField] string m_configPath = "config.txt";

    [Header("Excel Settings")]
    [SerializeField] bool m_generateLogFolder = false;

    public static ConfigManager GetInstance()
    {
        return _instance;
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (_instance == null) { _instance = this; } else { Destroy(gameObject); }
    }

    #region Getters
    public int GetValue(string p_id)
    {
        string path = Application.streamingAssetsPath + m_configPath;
        //Debug.Log($"path: found {path}");
        StreamReader reader = new StreamReader(path);

        int m_count = File.ReadAllLines(path).Length;

        string[] linesRead = File.ReadAllLines(path);

        foreach (var line in linesRead)
        {
            line.Trim(' ');
            var lineSplit = line.Split('=');

            if (lineSplit[0].Equals(p_id) || lineSplit[0].Contains(p_id))
            {
                return int.Parse(lineSplit[1]);
            }
        }
        reader.Close();
        Debug.LogAssertion("No Data Found");
        return -1;
    }

    public bool GetBool(string p_id)
    {
        string path = Application.streamingAssetsPath + m_configPath;
        StreamReader reader = new StreamReader(path);

        int m_count = File.ReadAllLines(path).Length;
        string[] linesRead = File.ReadAllLines(path);

        foreach (var line in linesRead)
        {
            line.Trim(' ');
            var lineSplit = line.Split('=');

            if (lineSplit[0].Equals(p_id) || lineSplit[0].Contains(p_id))
            {
                return lineSplit[1].Equals("true");
            }
        }
        reader.Close();
        Debug.LogAssertion("No Data Found");
        return false;
    }

    public string GetStringValue(string p_id)
    {
        string path = Application.streamingAssetsPath + m_configPath;
        //Debug.Log($"path: found {path}");
        StreamReader reader = new StreamReader(path);

        int m_count = File.ReadAllLines(path).Length;

        string[] linesRead = File.ReadAllLines(path);

        foreach (var line in linesRead)
        {
            line.Trim(' ');
            var lineSplit = line.Split('=');

            if (lineSplit[0].Equals(p_id) || lineSplit[0].Contains(p_id))
            {
                return lineSplit[1];
            }
        }

        reader.Close();
        Debug.LogAssertion($"No Data Found for ID:{p_id}");
        return "";
    }

    public float GetFloatValue(string p_id)
    {
        string path = Application.streamingAssetsPath + m_configPath;

        StreamReader reader = new StreamReader(path);

        int m_count = File.ReadAllLines(path).Length;

        string[] linesRead = File.ReadAllLines(path);

        foreach (var line in linesRead)
        {
            line.Trim(' ');
            var lineSplit = line.Split('=');
            if (lineSplit[0].Equals(p_id) || lineSplit[0].Contains(p_id))
            {
                return float.Parse(lineSplit[1]);
            }
        }
        reader.Close();
        Debug.LogAssertion($"No Data Found for ID:{p_id}");
        return -1;
    }

    #endregion

    public void WriteStringToFile(string p_data)
    {
        char[] charsToTrim = { ' ', ':' };

        string hour = DateTime.Now.ToString("HH");
        string date = DateTime.Now.ToString("ddMMMyy");
        date.Trim(charsToTrim);

        string filePath = m_generateLogFolder ?
            $"/StreamingAssets/Logs/Log_{date}_{hour}.csv" :
            $"/StreamingAssets/Logs/Log_{date}_{hour}.csv";

        string path = Application.dataPath + filePath;
        if (!File.Exists(path))
            WriteHeader(path);

        StreamWriter writer = new StreamWriter(path, true);
        string dataRow = $"{p_data},";
        dataRow.Trim(' ');
        writer.WriteLine(dataRow);

        writer.Close();
        StreamReader reader = new StreamReader(path);
        reader.Close();
    }

    private void WriteHeader(string p_data)
    {
        Debug.Log($"Tried to Save to Data + {p_data}");
        StreamWriter writer = new StreamWriter(p_data, true);
        string header = $"Pledge,Date/Time";
        writer.WriteLine(header);
        writer.Close();
    }

    public void ReadStringFromFile()
    {
        string path = Application.streamingAssetsPath + m_configPath;

        StreamReader reader = new StreamReader(path);

        int m_count = File.ReadAllLines(path).Length;

        string[] linesRead = File.ReadAllLines(path);
        for (int i = 0; i < linesRead.Length; i++)
        {
            string[] details = linesRead[i].Split(',');
        }

        reader.Close();
    }

}