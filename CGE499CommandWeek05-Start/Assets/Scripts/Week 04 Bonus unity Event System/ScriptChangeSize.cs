using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptChangeSize : MonoBehaviour
{
    private void OnEnable()
    {
        ScriptEventManager.IncreasSizeEvent += IncreaseSize;
        ScriptEventManager.ReduceSizeEvent += ReduceSize;
    }

    private void OnDisable()
    {
        ScriptEventManager.IncreasSizeEvent -= IncreaseSize;
        ScriptEventManager.ReduceSizeEvent -= ReduceSize;
    }

    private void IncreaseSize()
    {
        transform.localScale = new Vector3(transform.localScale.x * 1.5f,
                                           transform.localScale.y * 1.5f,
                                           transform.localScale.z * 1.5f);
    }

    private void ReduceSize()
    {
        transform.localScale = new Vector3(transform.localScale.x * 0.8f,
                                           transform.localScale.y * 0.8f,
                                           transform.localScale.z * 0.8f);
    }

    
}
