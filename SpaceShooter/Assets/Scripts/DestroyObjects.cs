using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    [Header("�L�@�q�ɶ��ۤv�R��")]
    public float Timer;
    // Start is called before the first frame update
    void Start()
    {
        //�R������(����A�h�[�ɶ���R��)
        Destroy(gameObject, Timer);
    }

    
}
