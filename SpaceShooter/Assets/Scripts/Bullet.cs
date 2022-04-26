using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("子彈移動速度")]
    public float Speed;
    [Header("玩家爆炸特效")]
    public GameObject FXPlayer;
    [Header("敵機爆炸特效")]
    public GameObject FXEnemy;
    [Header("隕石爆炸特效")]
    public GameObject FXAsteroid;


    //[Header("爆炸音效")]
    //public AudioSource AudioSFX;
    //爆炸特效已經放在特效裡了





    [Header("GM腳本")]
    public GM GMScripts;
    void Start()
    {
        GMScripts = GameObject.Find("GM").GetComponent<GM>();    
    }



    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider hit)
    {
        //有此腳本的物件為玩家子彈+碰撞到敵機
        //1.特效 2.聲音 3.對方消失
        if(gameObject.tag == "PlayerBullet" && hit.GetComponent<Collider>().tag == "Enemy")
        {
            GMScripts.Score(1);




            Instantiate(FXEnemy, hit.transform.position, hit.transform.rotation);
            Destroy(hit.gameObject);
            Destroy(gameObject);
        }
      /*
        if (gameObject.tag == "PlayerBullet" && (hit.GetComponent<Collider>().tag == "Enemy" || hit.GetComponent<Collider>().tag == "Asteroid"))
        {
            Instantiate(FXEnemy, hit.transform.position, hit.transform.rotation);
            Destroy(hit.gameObject);
            Destroy(gameObject);
        }*/
        
        if (gameObject.tag == "PlayerBullet" && hit.GetComponent<Collider>().tag == "Asteroid")
        {
            //有此腳本的物件為玩家子彈+碰撞到隕石
            //1.特效 2.聲音 3.對方消失
            GMScripts.Score(0);
            Instantiate(FXAsteroid, hit.transform.position, hit.transform.rotation);
            Destroy(hit.gameObject);
            Destroy(gameObject);
        }

        //有此腳本的物件為敵機子彈+碰撞到玩家
        //1.特效 2.聲音 3.對方扣血


        if (gameObject.tag == "EnemyBullet" && hit.GetComponent<Collider>().tag == "Player")
        {
            GMScripts.PlayerHP();
            Instantiate(FXPlayer, hit.transform.position, hit.transform.rotation);
            Destroy(gameObject);
        }



        







        



    }
}
