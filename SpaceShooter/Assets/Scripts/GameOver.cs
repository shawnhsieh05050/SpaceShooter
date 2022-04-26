using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [Header("目前分數的文字")]
    public Text ScoreText;

    string SaveHeightScore = "SaveHeightScore";

    [Header("最高分數的文字")]
    public Text HeightScoreText;

    // Start is called before the first frame update
    void Start()
    {
        //檢查資料欄位中是否已經有資料，如果沒有資料會回傳false，有資料回傳true
        if (!PlayerPrefs.HasKey(SaveHeightScore))
        {
            //如果欄位還沒有資料，代表為第一筆資料，直接將目前分數儲存在最高分數欄位中
            PlayerPrefs.SetInt(SaveHeightScore, StaticObj.SaveTotalScore);
        }
        else
        {
            //檢查最高分數欄位的分數是否>目前得分數
            if (PlayerPrefs.GetInt(SaveHeightScore) > StaticObj.SaveTotalScore) 
            {
                //將目前得分寫入到最高分數欄位
                PlayerPrefs.SetInt(SaveHeightScore, StaticObj.SaveTotalScore);
            }
        }

        HeightScoreText.text = "最高分數 : " + PlayerPrefs.GetInt(SaveHeightScore);

        ScoreText.text = "目前分數 : " + StaticObj.SaveTotalScore;
    }

    public void ChangeScene(string SceneName)
    {
        
        //自定義要切換至哪個場景
        SceneManager.LoadScene(SceneName);

    }
}
