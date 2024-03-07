using UnityEngine;

public class BikeController : MonoBehaviour
{
    public float maxSpeed = 2.0f;
    public float turnDistance = 2.0f;

    public float CurrentSpeed { get; set; }

    public enum Direction
    {
        Left = -1, Right = 1
    }

    public Direction  CurrentTurnDirection { get; private set; }

    private IBikeState _starState, _stopState, _turnState;

    private BikeStateContext _bikeStateContext;

    void Start()
    {
        _bikeStateContext = new BikeStateContext(this);

        _starState = gameObject.AddComponent<BikeStartState>();
        _stopState = gameObject.AddComponent<BikeStopState>();
        _turnState = gameObject.AddComponent<BikeTurnState>();

        _bikeStateContext.Transition(_stopState);
    }

    public void StartBike()
    {
        _bikeStateContext.Transition(_starState);
    }

    public void StopBike()
    {
        _bikeStateContext.Transition(_stopState);
    }

    public void Turn(Direction direction)
    {
        CurrentTurnDirection = direction;

        _bikeStateContext.Transition(_turnState);
    }
}
