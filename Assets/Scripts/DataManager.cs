using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string currentNickname;
    public string nickname;
    public string secondNickname;
    public int highScore;
    public int secondScore;
    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
        LoadNickname();
    }

    [System.Serializable]
    class SaveData
    {
        public string nickname;
        public string secondNickname;
        public int highScore;
        public int secondScore;
    }
    //public void SaveHighScore()
    //{
    //    SaveData data = new SaveData();
    //    data.highScore = highScore;
    //    data.secondScore = secondScore;

    //    string json = JsonUtility.ToJson(data);

    //    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    //    Debug.Log(data.highScore);
    //}
    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.secondScore = secondScore;

        // Log the values before saving
        Debug.Log($"High score: {data.highScore}, Second score: {data.secondScore}");

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("High scores saved successfully");
    }

    //public void LoadHighScore()
    //{
    //    string path = Application.persistentDataPath + "/savefile.json";
    //    Debug.Log($"Loading high score from {path}");
    //    if (File.Exists(path))
    //    {
    //        string json = File.ReadAllText(path);
    //        SaveData data = JsonUtility.FromJson<SaveData>(json);

    //        highScore = data.highScore;
    //        secondScore = data.secondScore;
    //        Debug.Log(data.highScore);
    //    }
    //}
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Debug.Log($"Loaded JSON data: {json}"); // Check the JSON data loaded from the file
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log($"Loaded high score: {data.highScore}, Second score: {data.secondScore}"); // Check the values after deserialization

            highScore = data.highScore;
            secondScore = data.secondScore;
        }
    }

    public void SaveNickname()
    {
        SaveData data = new SaveData();
        data.nickname = nickname;
        data.secondNickname = secondNickname;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadNickname()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            nickname = data.nickname;
            secondNickname = data.secondNickname;
        }
    }
}
