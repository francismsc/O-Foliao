using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviour
{
    public Player player;
    public Movement move;
    private Node node;
    public EventsUi eventsUi;
    private int rnd;
    public int number = 1;

    //public List<Decisions> decisions;
    //public List<Events> events;

    private Events[] _events = null;
    public Events[] Events { get { return _events; } }
    void Awake()
    {
        rnd = Random.Range(1, 254);
        LoadEvents();
    }

    private void Update()
    {
        if (move.Movingtime() == true)
        {
            GetComponent<Movement>().enabled = true;
        }
        if (move.Movingtime() == false)
        {
            GetComponent<Movement>().enabled = false;
            ChooseRandomEvent();
            move.TimetoMove();
            
        }
    }



    void LoadEvents()
    {
        Object[] objs = Resources.LoadAll("Events", typeof(Events));
        _events = new Events[objs.Length];
        for (int i = 0; i < objs.Length; i++)
        {
            _events[i] = (Events)objs[i];
        }

    }

    void ChooseRandomEvent()
    {
        rnd = Random.Range(0, Events.Length);
        Debug.Log(Events[rnd].Event);
        foreach (Decisions decision in Events[rnd].decisions)
        {
            Debug.Log(decision.stringI);
            Debug.Log(decision.stringF);
            Debug.Log(decision.alcoolD);
            Debug.Log(decision.funD);
            Debug.Log(decision.hungerD);
            Debug.Log(decision.socialD);
            Debug.Log(decision.moneyD);
            eventsUi.eventUi(Events[rnd]);
        } 
    }

    void SpawnEvent()
    {

    }
}
