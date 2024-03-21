using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIMainScene : MonoBehaviour
{
    public TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        if (inputField.text != null)
        {
            // DataManager.Instance.nickname = inputField.text;
            DataManager.Instance.currentNickname = inputField.text;
            SceneManager.LoadScene("main");
        }
        else
        {
            Debug.Log("You should enter a name!");
        }
    }
}
