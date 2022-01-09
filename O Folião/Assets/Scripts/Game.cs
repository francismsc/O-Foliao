using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviour
{
    public Player player;
    public Movement move;
    public EventsUi eventsUi;
    public EventList eventsList;
    public Node node;
    private int rnd;
    public int number = 1;

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
            eventsList.ChooseRandomEvent(player,node,eventsUi);
            move.TimetoMove();
            
        }
    }





}
