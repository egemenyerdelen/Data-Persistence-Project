using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InGameUIScreen : MonoBehaviour
{
    public Text highScoreText;
    public Text secondScoreText;
    public Text currentNickname;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentNickname.text = DataManager.Instance.currentNickname;
        highScoreText.text = "1. " + DataManager.Instance.nickname + " - " + DataManager.Instance.highScore;
        secondScoreText.text = "2. " + DataManager.Instance.secondNickname + " - " + DataManager.Instance.secondScore;
    }
}
