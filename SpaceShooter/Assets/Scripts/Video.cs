using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//使用影片程式庫
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    [Header("擺放影片物件")]
    public VideoPlayer VideoObj;
    //判斷現在是否可以偵測影片是否播完
    bool VideoState;
    
    void Start()
    {
        StartCoroutine(WaitTime());

    }

    IEnumerator WaitTime()
    {
        VideoState = false;
        //當執行到此時，此腳本在此停留1秒，再往下執行，但其他腳本還是會繼續執行
        yield return new WaitForSeconds(1f);
        VideoState = true;
    }


    // Update is called once per frame
    void Update()
    {
        //影片已經撥放完畢VideoObj.isPlaying = false
        //影片正在撥放 VideoObj.isPlaying = true
        //如果影片撥放完畢並且影片的bool為true，才可以換到下一個場景


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
