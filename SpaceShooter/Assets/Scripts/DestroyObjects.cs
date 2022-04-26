using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    [Header("過一段時間自己刪除")]
    public float Timer;
    // Start is called before the first frame update
    void Start()
    {
        //刪除物件(物件，多久時間後刪除)
        Destroy(gameObject, Timer);
    }

    
}
