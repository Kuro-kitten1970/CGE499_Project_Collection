using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombHandler : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Is Game Over = " + SingletonGameManeger._instance.isGameOver);
    }
}
