using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEventManager : MonoBehaviour
{
    public static event Action IncreasSizeEvent;
    public static event Action ReduceSizeEvent;
        
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IncreasSizeEvent?.Invoke();
        }

        if (Input.GetMouseButtonDown(1))
        {
            ReduceSizeEvent?.Invoke();
        }
    }
}
