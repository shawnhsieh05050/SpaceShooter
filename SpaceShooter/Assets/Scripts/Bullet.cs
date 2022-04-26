using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("�l�u���ʳt��")]
    public float Speed;
    [Header("���a�z���S��")]
    public GameObject FXPlayer;
    [Header("�ľ��z���S��")]
    public GameObject FXEnemy;
    [Header("�k���z���S��")]
    public GameObject FXAsteroid;


    //[Header("�z������")]
    //public AudioSource AudioSFX;
    //�z���S�Ĥw�g��b�S�ĸ̤F





    [Header("GM�}��")]
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
        //�����}�������󬰪��a�l�u+�I����ľ�
        //1.�S�� 2.�n�� 3.������
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
            //�����}�������󬰪��a�l�u+�I����k��
            //1.�S�� 2.�n�� 3.������
            GMScripts.Score(0);
            Instantiate(FXAsteroid, hit.transform.position, hit.transform.rotation);
            Destroy(hit.gameObject);
            Destroy(gameObject);
        }

        //�����}�������󬰼ľ��l�u+�I���쪱�a
        //1.�S�� 2.�n�� 3.��覩��


        if (gameObject.tag == "EnemyBullet" && hit.GetComponent<Collider>().tag == "Player")
        {
            GMScripts.PlayerHP();
            Instantiate(FXPlayer, hit.transform.position, hit.transform.rotation);
            Destroy(gameObject);
        }



        







        



    }
}
