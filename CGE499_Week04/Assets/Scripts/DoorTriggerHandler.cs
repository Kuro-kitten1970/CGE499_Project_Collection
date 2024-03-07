using UnityEngine;

public class DoorTriggerHandler : MonoBehaviour
{
    public int triggerID;

    private void OnTriggerEnter(Collider other)
    {
        TriggerEventManager.StartDoorEvent(triggerID);
    }
}
