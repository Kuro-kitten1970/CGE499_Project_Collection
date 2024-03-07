using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Invoker invoker;
    private bool isReplaying;
    private bool isRecording;
    private BikeController bikeController;
    private Command btnA, btnD, btnW;

    private void Start()
    {
        invoker = gameObject.AddComponent<Invoker>();
        bikeController = FindObjectOfType<BikeController>();

        btnA = new TurnLeft(bikeController);
        btnD = new TurnRight(bikeController);
        btnW = new ToggleTurbo(bikeController);
    }

    private void Update()
    {
        if (!isReplaying && isRecording)
        {
            if (Input.GetKeyUp(KeyCode.A))
            {
                invoker.ExecuteCommand(btnA);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                invoker.ExecuteCommand(btnD);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                invoker.ExecuteCommand(btnW);
            }
        }
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Start Record"))
        {
            bikeController.ResetPosition();
            isReplaying = false;
            isRecording = true;
            invoker.Record();
        }

        if (GUILayout.Button("Stop Record"))
        {
            bikeController.ResetPosition();
            isRecording = false;
        }

        if (!isRecording)
        {
            if (GUILayout.Button("Start Replay"))
            {
                bikeController.ResetPosition();
                isRecording = false;
                isReplaying = true;
                invoker.Replay();
            }
        }
    }
}
