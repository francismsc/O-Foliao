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

    
    void Awake()
    {
        rnd = Random.Range(1, 254);
        LoadEvents();
 
    }

    private void Update()
    {
        if (move.isMoving() == true)
        {
            GetComponent<Movement>().enabled = true;
        }
        if (move.isMoving() == false)
        {
            GetComponent<Movement>().enabled = false;
            ChooseRandomEvent();
            move.TimetoMove();
            
        }
    }

    void ChooseEventType()
    {

    }

    void LoadEvents()
    {
        Object[] objs = Resources.LoadAll("Events", typeof(Events));
        events = new Events[objs.Length];
        for (int i = 0; i < objs.Length; i++)
        {
            events[i] = (Events)objs[i];
        }

    }

    void ChooseRandomEvent()
    {
        rnd = Random.Range(0, Events.Length);
        Debug.Log(Events[rnd].Event);
        foreach (Decisions decision in Events[rnd].decisions)
        {
            eventsUi.eventUi(Events[rnd]);
        } 
    }

    void SpawnEvent()
    {

    }
}
