using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    [Header("多少時間產生一台敵人")]
    public float Timer;
    [Header("敵人物件")]
    public GameObject[] Enemys;
    [Header("敵人產生的位置")]
    public Vector3 Pos;
    [Header("敵人產生位置X最大值")]
    public float MaxX;
    [Header("敵人產生位置X最小值")]
    public float MinX;

    [Header("玩家分數的文字")]
    public Text ScoreText;
    [Header("計算總分")]
    public int TotalScore;
    [Header("打到敵機加分")]
    public int AddEnemyScore;
    [Header("打到隕石加分")]
    public int AddAsteroidScore;


    [Header("玩家血條")]
    public Image PlayerBar;
    [Header("玩家總血量")]//血量的最大值
    public float PlayerTotalHP;
    [Header("敵機子彈/敵機/隕石打到玩家扣除的血量值")]
    public float HurtPlayerHP;
    //程式中計算玩家的血量值
    float ScriptTotalHP;



    [Header("遊戲暫停UI")]
    public GameObject PauseUI;
    [Header("判斷是否遊戲")]
    public bool isPause;




    private void Awake()
    {
        //持續生成敵機
        InvokeRepeating("CreateEnemy", Timer, Timer);

        //將Unity介面設定的最大血量值(屬性面板自訂義的數值)，指定給ScriptTotalHP，並且使用ScriptTotalHP來計算後面的血量
        ScriptTotalHP = PlayerTotalHP;
    }


    void CreateEnemy()
    {
        //隨機動態生成敵人
        //Random.Range隨機
        Instantiate(Enemys[Random.Range(0, Enemys.Length)], new Vector3(Random.Range(MinX, MaxX), Pos.y, Pos.z), transform.rotation);
    }

    public void Score(int ObjectID)
    {
        //ObjectID = 0 隕石 Object ID = 1 敵機
        switch (ObjectID)
        {
            case 0:
                TotalScore += AddAsteroidScore;
                break;
            case 1:
                TotalScore += AddEnemyScore;
                break;
            default:

                break;

        }
        ScoreText.text = "Score : " +  TotalScore;
            
    }

    public void PlayerHP()
    {
        ScriptTotalHP -= HurtPlayerHP;
        PlayerBar.fillAmount = ScriptTotalHP / PlayerTotalHP;
        if(ScriptTotalHP <= 0)
        {
            StaticObj.SaveTotalScore = TotalScore;
            SceneManager.LoadScene("GameOver");
        }
    }

    public void PauseButton()
    {
        isPause = !isPause;
        PauseUI.SetActive(isPause);
        //Time.timeScale = 0f; 整體時間暫停
        //Time.timeScale = 1f; 整體時間恢復
        if(isPause)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void ChangeScene(string SceneName)
    {
        Time.timeScale = 1f;

        if(SceneName == "Video")
        {
            GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().mute = true;
        }


        //自定義要切換至哪個場景
        SceneManager.LoadScene(SceneName);

    }


}
