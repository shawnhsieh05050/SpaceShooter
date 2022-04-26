using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBullet : MonoBehaviour
{
    [Header("等待幾秒鐘開始執行")]
    public float Timer;
    [Header("子彈物件")]
    public GameObject Bullet;
    [Header("階層下的空物件")]
    public Transform Pos;


    private void Awake()
    {
        //InvokeRepeating 持續呼叫Function直到遊戲場景關閉或停止呼叫才會停止
        //InvokeRepeating ( 要呼叫的function Name,遊戲一開始要等待多少時間才執行第一次，第二、三次.....要等待多少時間才執行(以秒為單位)

        InvokeRepeating("Create_Bullet", Timer, Timer);
    }


    void Create_Bullet()
    {
        //Instantiate 動態生成 ( 要生成的物件，要生成的位置，生成以後物件的角度
        Instantiate(Bullet, Pos.position, Pos.rotation);
    }
}
