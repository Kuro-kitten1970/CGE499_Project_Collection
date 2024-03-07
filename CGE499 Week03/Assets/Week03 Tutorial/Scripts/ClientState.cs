using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientState : MonoBehaviour
{
    private BikeController bikeController;

    private void Start()
    {
        bikeController = (BikeController)FindObjectOfType(typeof(BikeController));
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Start Bike"))
            bikeController.StartBike();

        if (GUILayout.Button("Turn Left"))
            bikeController.Turn(BikeController.Direction.Left);

        if (GUILayout.Button("Turn Right"))
            bikeController.Turn(BikeController.Direction.Right);

        if (GUILayout.Button("Stop Bike"))
            bikeController.StopBike();
    }
}
