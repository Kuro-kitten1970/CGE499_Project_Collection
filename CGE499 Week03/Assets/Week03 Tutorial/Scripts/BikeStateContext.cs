using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeStateContext : MonoBehaviour
{
    // This is a shiet that will kill me in the future.

    public IBikeState CurrentState { get; set; }

    private readonly BikeController _bikeController;

    public BikeStateContext(BikeController bikeController)
    {
        _bikeController = bikeController;
    }

    public void Transition()
    {
        CurrentState.Handle(_bikeController);
    }

    public void Transition(IBikeState state)
    {
        CurrentState = state;
        CurrentState.Handle(_bikeController);
    }
}
