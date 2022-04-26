using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Audio;//Audio Mixer library

public class Menu : MonoBehaviour
{
    [Header("��]�w��������")]
    public GameObject SettingUI;
    //open or !open menu page
    bool ControlSettingUI;
    // Start is called before the first frame update

    [Header("BGM Prefab")]
    public GameObject BGM;

    //Control sound open and off
    bool Control_Soundss;

    //�n����������Ϥ�
    //[Header("�n���}���Ϥ�")]
    //public Sprite OpenSoundSprite;
   // [Header("�n�������Ϥ�")]
    //public Sprite CloseSoundSprite;
    [Header("�n�����s")]
    public Image SoundButtonImage;

    [Header("�n��Slider")]
    public Slider SoundSlider;

    [Header("�C���ѪR�פؤo")]
    public Dropdown ScreenSizeDropdown;


    [Header("Toggle_BGM")]
    public Toggle ToggleBGM;
    [Header("Toggle_SFX")]
    public Toggle ToggleSFX;
    [Header("AudioMixer")]
    public AudioMixer AudioMixerObj;






    private void Awake()
    {
        //�Y�������w�g��BGM�A�h�^�Ǽƭ� = 1�A�Ϥ���0
        if (GameObject.FindGameObjectsWithTag("BGM").Length <= 0)
        {
            //�Y��0�A�ʺA�ͦ�����
            Instantiate(BGM);
        }
        //LoadStreamingAssets("SoundOpen");
    }

    void Update()
    {
        //����C�����q AudioListener ( 0 - 1 )
        AudioListener.volume = SoundSlider.value;
        
    }




    public void NextScenes()
    {
        //��M�����W������Ҭ�BGM�A���󨭤W���n�����AMute�}��
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

        //AudioListener.pause = true ����C���n���L�n false �_��
        AudioListener.pause = Control_Soundss;

        //��ControlSoundss = true
        if (Control_Soundss)
        {
            //���s�Ϥ��a�J���n�����Ϥ�
            //SoundButtonImage.sprite = CloseSoundSprite;
            //���s�Ϥ������a�JResources
            SoundButtonImage.sprite = Resources.Load<Sprite>("SoundClose");
            //LoadStreamingAssets("SoundClose");
            SoundSlider.value = 0;
        }
        else
        {
            //���s�Ϥ��a�J�}���n�����Ϥ�
            //SoundButtonImage.sprite = OpenSoundSprite;
            SoundButtonImage.sprite = Resources.Load<Sprite>("SoundOpen");
            //LoadStreamingAssets("SoundOpen");
            SoundSlider.value = 1;
        }

    }
    void LoadStreamingAssets(string TextureName)
    {
        //�ŧi�Ϥ�
        Texture texture;
        //�ϥκ��}�覡���.streamingAssets���|�̪��Ϥ�
        WWW www = new WWW(Application.streamingAssetsPath + " / " + TextureName + ".png");
        
        Debug.Log(Application.streamingAssetsPath + "/" + TextureName + ".png");

        //��Ƨ������Ϥ��a�J��Texture�ܼƤ�
        texture = www.texture;

        //�z�LSprite.Create�NTexture�a�J���n�������simage��
        SoundButtonImage.sprite = Sprite.Create(texture as Texture2D, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }

    //�z�LSlider��OnValueChanged���ܰ����ƭȪ��A
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
                Screen.SetResolution(1080, 1920, false);//�]�w�ù��ѪR�סA�e�B���B���ù� ( true = ���ù� )
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
        //�ˬdBGM Toggle��ison�O�}�٬O��
        
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
