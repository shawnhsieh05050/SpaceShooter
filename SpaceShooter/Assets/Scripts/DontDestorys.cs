using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestorys : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //���������ɡA���n�N����R��
        //�p�gg�}�Y��gameobject�N���Ӹ}��������
        DontDestroyOnLoad(gameObject);
    }


  
}
