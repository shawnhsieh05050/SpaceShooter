using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("玩家移動速度")]
    public float Speed;

    //參數直接參考場景角色能夠移動的position，Z軸填入角色的Zposition
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

        //取得軸向寫法，可通用鍵盤上下左右WASD及搖桿Joystick，可參考Preference Input
        transform.Translate(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * Speed * Time.deltaTime);

#endif


#if UNITY_ANDROID

        //使用手機的陀螺儀進行控制飛機的位置
        //Input.acceleration手機陀螺儀
        transform.Translate(Input.acceleration.x * Speed * Time.deltaTime,0,Input.acceleration.y * Speed *Time.deltaTime);

#endif









        //Math.Clamp限制(限制項目,最小值,最大值)
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX), Mathf.Clamp(transform.position.y, MinY, MaxY), -0.4f);
    }
}
