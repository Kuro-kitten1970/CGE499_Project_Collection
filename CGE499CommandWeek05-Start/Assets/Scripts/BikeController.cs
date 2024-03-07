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

    private string _status = "Stopped";

    private void OnEnable()
    {
        RaceEventBus.Subscribe(RaceEventType.START, StartBike);
        RaceEventBus.Subscribe(RaceEventType.STOP, StopBike);
    }

    private void OnDisable()
    {
        RaceEventBus.Unsubscribe(RaceEventType.START, StartBike);
        RaceEventBus.Unsubscribe(RaceEventType.STOP, StopBike);
    }

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

        _status = "Started";
    }

    public void StopBike()
    {
        _bikeStateContext.Transition(_stopState);

        _status = "Stopped";
    }

    /*public void Turn(Direction direction)
    {
        CurrentTurnDirection = direction;

        _bikeStateContext.Transition(_turnState);
    }

    private void OnGUI()
    {
        GUI.color = Color.green;
        GUI.Label(new Rect(10, 60, 200, 20), "BIKE STATUS: " + _status);
    }*/

    #region Week 05 Command

    private bool isTurboOn;
    private float distance = 1.0f;

    public void ToggleTurbo()
    {
        isTurboOn = !isTurboOn;
        Debug.Log("Turbo Active : " + isTurboOn);
    }

    public void Turn(Direction direction)
    {
        if (direction == Direction.Left)
        {
            transform.Translate(Vector3.left * distance);
        }

        if (direction == Direction.Right)
        {
            transform.Translate(Vector3.right * distance);
        }
    }

    public void ResetPosition()
    {
        transform.position = new Vector3(0,0,0);
    }

    #endregion
}
