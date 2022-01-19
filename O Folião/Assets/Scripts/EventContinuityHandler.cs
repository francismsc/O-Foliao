using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventContinuityHandler : MonoBehaviour
{
    [SerializeField]private EventList eventList;
    public void EventContinuity(EventContinuity newEvent, Events oldEvent )
    {

        if(newEvent != null)
        {
            eventList.AddToDecks(newEvent);
            eventList.RemoveFromDecks(newEvent, oldEvent);
        }
    }
}
