using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("�ĤH���ʳt��")]
    public float Speed;
    [Header("���a�z���S��")]
    public GameObject FXPlayer;


    [Header("GM�}��")]
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
            //�����}�������󬰼ľ�����+�I���쪱�a����
            //1.�S�� 2.�n�� 3.����
            GMScripts.PlayerHP();
            Instantiate(FXPlayer, hit.transform.position, hit.transform.rotation);
            Destroy(gameObject);
        }

    }
}
