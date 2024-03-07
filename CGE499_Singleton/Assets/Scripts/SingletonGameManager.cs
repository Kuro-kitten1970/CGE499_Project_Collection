using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonGameManeger : MonoBehaviour
{
    public static SingletonGameManeger _instance;

    public bool isGameOver = false;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
