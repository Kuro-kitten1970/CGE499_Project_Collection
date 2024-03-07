using UnityEngine.Events;
using System.Collections.Generic;

public enum RaceEventType
{
    COUNTDOWN, START, RESTART, STOP, FINISH, QUIT
}

public class RaceEventBus
{
    private static readonly IDictionary<RaceEventType, UnityEvent> 
        Events = new Dictionary<RaceEventType, UnityEvent>();

    public static void Subscribe(RaceEventType raceEventType, UnityAction listener)
    {
        UnityEvent thisEvent;

        if (Events.TryGetValue(raceEventType, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Events.Add(raceEventType, thisEvent);
        }
    }

    public static void UnSubScribe(RaceEventType raceEventType, UnityAction listener)
    {
        UnityEvent thisEvent;

        if (Events.TryGetValue(raceEventType, out thisEvent)) thisEvent.RemoveListener(listener);
    }

    public static void Publish(RaceEventType raceEventType)
    {
        UnityEvent thisEvent;

        if (Events.TryGetValue(raceEventType, out thisEvent)) thisEvent.Invoke();
    }
}
