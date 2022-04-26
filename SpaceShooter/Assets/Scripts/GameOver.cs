using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [Header("�ثe���ƪ���r")]
    public Text ScoreText;

    string SaveHeightScore = "SaveHeightScore";

    [Header("�̰����ƪ���r")]
    public Text HeightScoreText;

    // Start is called before the first frame update
    void Start()
    {
        //�ˬd�����줤�O�_�w�g����ơA�p�G�S����Ʒ|�^��false�A����Ʀ^��true
        if (!PlayerPrefs.HasKey(SaveHeightScore))
        {
            //�p�G����٨S����ơA�N���Ĥ@����ơA�����N�ثe�����x�s�b�̰�������줤
            PlayerPrefs.SetInt(SaveHeightScore, StaticObj.SaveTotalScore);
        }
        else
        {
            //�ˬd�̰�������쪺���ƬO�_>�ثe�o����
            if (PlayerPrefs.GetInt(SaveHeightScore) > StaticObj.SaveTotalScore) 
            {
                //�N�ثe�o���g�J��̰��������
                PlayerPrefs.SetInt(SaveHeightScore, StaticObj.SaveTotalScore);
            }
        }

        HeightScoreText.text = "�̰����� : " + PlayerPrefs.GetInt(SaveHeightScore);

        ScoreText.text = "�ثe���� : " + StaticObj.SaveTotalScore;
    }

    public void ChangeScene(string SceneName)
    {
        
        //�۩w�q�n�����ܭ��ӳ���
        SceneManager.LoadScene(SceneName);

    }
}
