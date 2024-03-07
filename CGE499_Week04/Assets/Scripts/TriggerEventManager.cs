using System;
using UnityEngine;

public class TriggerEventManager : MonoBehaviour
{
    public static event Action<int> openDoorEvent;

    public static void StartDoorEvent(int id)
    {
        openDoorEvent?.Invoke(id);
    }
}
