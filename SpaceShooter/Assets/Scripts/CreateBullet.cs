using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBullet : MonoBehaviour
{
    [Header("���ݴX�����}�l����")]
    public float Timer;
    [Header("�l�u����")]
    public GameObject Bullet;
    [Header("���h�U���Ū���")]
    public Transform Pos;


    private void Awake()
    {
        //InvokeRepeating ����I�sFunction����C�����������ΰ���I�s�~�|����
        //InvokeRepeating ( �n�I�s��function Name,�C���@�}�l�n���ݦh�֮ɶ��~����Ĥ@���A�ĤG�B�T��.....�n���ݦh�֮ɶ��~����(�H�����)

        InvokeRepeating("Create_Bullet", Timer, Timer);
    }


    void Create_Bullet()
    {
        //Instantiate �ʺA�ͦ� ( �n�ͦ�������A�n�ͦ�����m�A�ͦ��H�᪫�󪺨���
        Instantiate(Bullet, Pos.position, Pos.rotation);
    }
}
