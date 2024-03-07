using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;


public class Invoker : MonoBehaviour
{
    private bool isRecording;
    private bool isReplaying;

    private float replayTime;
    private float recordingTime;

    private SortedList<float, Command> recCommand = new SortedList<float, Command>();

    public void ExecuteCommand(Command command)
    {
        command.Execute();

        if (isRecording)
        {
            recCommand.Add(recordingTime, command);

            Debug.Log(recordingTime);
            Debug.Log(command);
        }
    }

    public void Record()
    {
        recordingTime = 0f;
        isRecording = true;
    }

    public void Replay()
    {
        replayTime = 0f;
        isReplaying = true;

        if (recCommand.Count <= 0)
        {
            Debug.Log("Error");
        }

        recCommand.Reverse();
    }

    private void FixedUpdate()
    {
        if (isRecording)
        {
            recordingTime += Time.deltaTime;
        }

        if (isReplaying)
        {
            replayTime += Time.deltaTime;

            if (recCommand.Any())
            {
                if (Mathf.Approximately(replayTime, recCommand.Keys[0]))
                {
                    Debug.Log(replayTime);
                    Debug.Log(recCommand);

                    recCommand.Values[0].Execute();
                    recCommand.RemoveAt(0);
                }
                else
                {
                    isReplaying = !true;
                }
            }
        }
    }
}
