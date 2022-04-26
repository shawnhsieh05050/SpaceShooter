using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestorys : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //切換場景時，不要將物件刪除
        //小寫g開頭的gameobject代表有該腳本的物件
        DontDestroyOnLoad(gameObject);
    }


  
}
