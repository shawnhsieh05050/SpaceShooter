using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    [Header("�h�֮ɶ����ͤ@�x�ĤH")]
    public float Timer;
    [Header("�ĤH����")]
    public GameObject[] Enemys;
    [Header("�ĤH���ͪ���m")]
    public Vector3 Pos;
    [Header("�ĤH���ͦ�mX�̤j��")]
    public float MaxX;
    [Header("�ĤH���ͦ�mX�̤p��")]
    public float MinX;

    [Header("���a���ƪ���r")]
    public Text ScoreText;
    [Header("�p���`��")]
    public int TotalScore;
    [Header("����ľ��[��")]
    public int AddEnemyScore;
    [Header("����k�ۥ[��")]
    public int AddAsteroidScore;


    [Header("���a���")]
    public Image PlayerBar;
    [Header("���a�`��q")]//��q���̤j��
    public float PlayerTotalHP;
    [Header("�ľ��l�u/�ľ�/�k�ۥ��쪱�a��������q��")]
    public float HurtPlayerHP;
    //�{�����p�⪱�a����q��
    float ScriptTotalHP;



    [Header("�C���Ȱ�UI")]
    public GameObject PauseUI;
    [Header("�P�_�O�_�C��")]
    public bool isPause;




    private void Awake()
    {
        //����ͦ��ľ�
        InvokeRepeating("CreateEnemy", Timer, Timer);

        //�NUnity�����]�w���̤j��q��(�ݩʭ��O�ۭq�q���ƭ�)�A���w��ScriptTotalHP�A�åB�ϥ�ScriptTotalHP�ӭp��᭱����q
        ScriptTotalHP = PlayerTotalHP;
    }


    void CreateEnemy()
    {
        //�H���ʺA�ͦ��ĤH
        //Random.Range�H��
        Instantiate(Enemys[Random.Range(0, Enemys.Length)], new Vector3(Random.Range(MinX, MaxX), Pos.y, Pos.z), transform.rotation);
    }

    public void Score(int ObjectID)
    {
        //ObjectID = 0 �k�� Object ID = 1 �ľ�
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
        //Time.timeScale = 0f; ����ɶ��Ȱ�
        //Time.timeScale = 1f; ����ɶ���_
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


        //�۩w�q�n�����ܭ��ӳ���
        SceneManager.LoadScene(SceneName);

    }


}
