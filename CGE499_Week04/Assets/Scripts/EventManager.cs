using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action increaseSizeEvent;
    public static event Action decreaseSizeEvent;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            increaseSizeEvent?.Invoke();
        }
        
        if (Input.GetMouseButton(1))
        {
            decreaseSizeEvent?.Invoke();
        }
    }
}
