using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("���a���ʳt��")]
    public float Speed;

    //�Ѽƪ����Ѧҳ������������ʪ�position�AZ�b��J���⪺Zposition
    [Header("MinX")]
    public float MinX;

    [Header("MinY")]
    public float MinY;

    [Header("MaxX")]
    public float MaxX;

    [Header("MaxY")]
    public float MaxY;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
#if UNITY_STANDALONE_WIN

        //���o�b�V�g�k�A�i�q����L�W�U���kWASD�ηn��Joystick�A�i�Ѧ�Preference Input
        transform.Translate(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * Speed * Time.deltaTime);

#endif


#if UNITY_ANDROID

        //�ϥΤ�����������i�汱�������m
        //Input.acceleration���������
        transform.Translate(Input.acceleration.x * Speed * Time.deltaTime,0,Input.acceleration.y * Speed *Time.deltaTime);

#endif









        //Math.Clamp����(�����,�̤p��,�̤j��)
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX), Mathf.Clamp(transform.position.y, MinY, MaxY), -0.4f);
    }
}
