using UnityEngine;
using UnityEngine.Events;

public class DoorHandler : MonoBehaviour
{
    public bool open;
    public bool isOpened;
    public int doorID;

    private void OnEnable()
    {
        TriggerEventManager.openDoorEvent += OpenDoor;
    }

    private void OnDisable()
    {
        TriggerEventManager.openDoorEvent -= OpenDoor;
    }

    private void OpenDoor(int triggerID)
    {
        if (triggerID == doorID) open = true;
    }

    private void Update()
    {
        if (isOpened == false && open == true)
        {
            isOpened = true;
            transform.position += Vector3.up * 5f;
        }
    }
}
