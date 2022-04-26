using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�ϥμv���{���w
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    [Header("�\��v������")]
    public VideoPlayer VideoObj;
    //�P�_�{�b�O�_�i�H�����v���O�_����
    bool VideoState;
    
    void Start()
    {
        StartCoroutine(WaitTime());

    }

    IEnumerator WaitTime()
    {
        VideoState = false;
        //�����즹�ɡA���}���b�����d1��A�A���U����A����L�}���٬O�|�~�����
        yield return new WaitForSeconds(1f);
        VideoState = true;
    }


    // Update is called once per frame
    void Update()
    {
        //�v���w�g���񧹲�VideoObj.isPlaying = false
        //�v�����b���� VideoObj.isPlaying = true
        //�p�G�v�����񧹲��åB�v����bool��true�A�~�i�H����U�@�ӳ���


        if (!VideoObj.isPlaying && VideoState)
        {
            GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().mute = false;
            SceneManager.LoadScene("Game");
        }
    }

    public void NextScene()
    {
        GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().mute = false;
        SceneManager.LoadScene("Game");
    }
}
