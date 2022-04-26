using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Audio;//Audio Mixer library

public class Menu : MonoBehaviour
{
    [Header("放設定頁面物件")]
    public GameObject SettingUI;
    //open or !open menu page
    bool ControlSettingUI;
    // Start is called before the first frame update

    [Header("BGM Prefab")]
    public GameObject BGM;

    //Control sound open and off
    bool Control_Soundss;

    //聲音控制切換圖片
    //[Header("聲音開的圖片")]
    //public Sprite OpenSoundSprite;
   // [Header("聲音關的圖片")]
    //public Sprite CloseSoundSprite;
    [Header("聲音按鈕")]
    public Image SoundButtonImage;

    [Header("聲音Slider")]
    public Slider SoundSlider;

    [Header("遊戲解析度尺寸")]
    public Dropdown ScreenSizeDropdown;


    [Header("Toggle_BGM")]
    public Toggle ToggleBGM;
    [Header("Toggle_SFX")]
    public Toggle ToggleSFX;
    [Header("AudioMixer")]
    public AudioMixer AudioMixerObj;






    private void Awake()
    {
        //若場景中已經有BGM，則回傳數值 = 1，反之為0
        if (GameObject.FindGameObjectsWithTag("BGM").Length <= 0)
        {
            //若為0，動態生成物件
            Instantiate(BGM);
        }
        //LoadStreamingAssets("SoundOpen");
    }

    void Update()
    {
        //整體遊戲音量 AudioListener ( 0 - 1 )
        AudioListener.volume = SoundSlider.value;
        
    }




    public void NextScenes()
    {
        //找尋場景上物件標籤為BGM，物件身上的聲音原件，Mute開啟
        GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().mute = true;// open mute
        SceneManager.LoadScene("Video");
        //Application.LoadLevel("Video");
    }
    
    public void QuitGames()
    {
        Application.Quit();
    }
    
    public void Settings()
    {

        //Set bool = true or false
        ControlSettingUI = !ControlSettingUI;

        //open or close menu page 
        SettingUI.SetActive(ControlSettingUI);
    }

    public void ControlSounds()
    {
        Control_Soundss = !Control_Soundss;

        //AudioListener.pause = true 整體遊戲聲音無聲 false 復原
        AudioListener.pause = Control_Soundss;

        //當ControlSoundss = true
        if (Control_Soundss)
        {
            //按鈕圖片帶入關聲音的圖片
            //SoundButtonImage.sprite = CloseSoundSprite;
            //按鈕圖片直接帶入Resources
            SoundButtonImage.sprite = Resources.Load<Sprite>("SoundClose");
            //LoadStreamingAssets("SoundClose");
            SoundSlider.value = 0;
        }
        else
        {
            //按鈕圖片帶入開啟聲音的圖片
            //SoundButtonImage.sprite = OpenSoundSprite;
            SoundButtonImage.sprite = Resources.Load<Sprite>("SoundOpen");
            //LoadStreamingAssets("SoundOpen");
            SoundSlider.value = 1;
        }

    }
    void LoadStreamingAssets(string TextureName)
    {
        //宣告圖片
        Texture texture;
        //使用網址方式抓取.streamingAssets路徑裡的圖片
        WWW www = new WWW(Application.streamingAssetsPath + " / " + TextureName + ".png");
        
        Debug.Log(Application.streamingAssetsPath + "/" + TextureName + ".png");

        //資料夾內的圖片帶入到Texture變數中
        texture = www.texture;

        //透過Sprite.Create將Texture帶入到聲音的按鈕image中
        SoundButtonImage.sprite = Sprite.Create(texture as Texture2D, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }

    //透過Slider的OnValueChanged改變偵測數值狀態
    public void ControlSoundVolumeSlider()
    {
        if(SoundSlider.value > 0f)
        {
            AudioListener.pause = false;
            Control_Soundss = false;
            SoundButtonImage.sprite = Resources.Load<Sprite>("SoundOpen");
        }
        else
        {
            AudioListener.pause = false;
            Control_Soundss = true;
            SoundButtonImage.sprite = Resources.Load<Sprite>("SoundClose");
        }
    }

    public void ChangeDropdown()
    {
        switch (ScreenSizeDropdown.value)
        {
            //1080*1920
            case 0:
                Screen.SetResolution(1080, 1920, false);//設定螢幕解析度，寬、高、全螢幕 ( true = 全螢幕 )
                break;
            //720*1080
            case 1:
                Screen.SetResolution(720, 1080, false);
                break;
            //480*800
            case 2:
                Screen.SetResolution(480, 800, false);
                break;

            default:
                break;
        }
    }

    public void Toggle_BGM()
    {  
        //檢查BGM Toggle的ison是開還是關
        
        if (ToggleBGM.isOn)
        {
            AudioMixerObj.SetFloat("BGM", 0);
        }
        else
        {
            AudioMixerObj.SetFloat("BGM", -80f);
        }
    }

    public void Toggle_SFX()
    {
        if (ToggleSFX.isOn)
        {
            AudioMixerObj.SetFloat("VFX", 0f);
        }
        else
        {
            AudioMixerObj.SetFloat("VFX", -80f);
        }
    }


}
