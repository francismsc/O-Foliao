using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Movement move;
    [SerializeField] private EventsUi eventsUi;
    [SerializeField] private EventList eventsList;
    [SerializeField] private Node node;
    [SerializeField] private Clock clock;


    private Events randomEvent;
    private Events[] events = null;
    public Events[] Events { get { return events; } }

    

    private void Update()
    {
        if (move.isMoving() == true)
        {
            GetComponent<Movement>().enabled = true;

        }
        if (move.isMoving() == false)
        {
            GetComponent<Movement>().enabled = false;
            randomEvent = eventsList.ChooseRandomEvent(player,node,eventsUi);
            eventsUi.EventUi(randomEvent);
            move.TimetoMove();
            
        }
    }





}
