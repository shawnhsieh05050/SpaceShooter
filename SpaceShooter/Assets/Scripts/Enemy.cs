using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("敵人移動速度")]
    public float Speed;
    [Header("玩家爆炸特效")]
    public GameObject FXPlayer;


    [Header("GM腳本")]
    public GM GMScripts;
    void Start()
    {
        GMScripts = GameObject.Find("GM").GetComponent<GM>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider hit)
    {
        
        if ( hit.GetComponent<Collider>().tag == "Player")
        {
            //有此腳本的物件為敵機機身+碰撞到玩家機身
            //1.特效 2.聲音 3.扣血
            GMScripts.PlayerHP();
            Instantiate(FXPlayer, hit.transform.position, hit.transform.rotation);
            Destroy(gameObject);
        }

    }
}
