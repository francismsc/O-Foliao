using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EventList : MonoBehaviour
{
    [SerializeField]
    private const int lowAlcoolLvl = 30;

    [SerializeField]
    private const int highAlcoolLvl = 80;

    [SerializeField]
    private const int lowEnergyLvl = 30;



    private Events[] events = null;
    protected Events randomEvent = null;
    private Events[] alcoolEvents = null;
    private Events[] energyEvents = null;
    private Events[] timeOfDayEvents = null;
    private Events[] dayEvents = null;

    private int rnd;

    [Header("Local Decks")]
    [SerializeField] private Events[] stagesDeck;
    [SerializeField] private Events[] barsDeck;

    [Header("Resources Decks")]
    [SerializeField] private Events[] lowAlcoolDeck;
    [SerializeField] private Events[] highAlcoolDeck;
    [SerializeField] private Events[] lowEnergyDeck;

    [Header("TimeOfDay Decks")]
    [SerializeField] private Events[] morningDeck;
    [SerializeField] private Events[] afternoonDeck;
    [SerializeField] private Events[] nightDeck;

    [Header("Day Decks")]
    [SerializeField] private Events[] day1Deck;
    [SerializeField] private Events[] day2Deck;
    [SerializeField] private Events[] day3Deck;

    public Clock clock;

    private void Awake()
    {
        rnd = Random.Range(1, 254);
    }



    public Events[] GetLocalEventType(Node.Type nodetype)
    {
        switch(nodetype)
        {
            case (Node.Type.Stages):
                return stagesDeck;
            case (Node.Type.Bars):
                return barsDeck;
            default:
                Debug.Log("Error:GetLocalEvent");
                return null;
               
        }
    }

    public Events[] GetTimeOfDayEvents()
    {
        switch(clock.GetCurrentTimeOfDay())
        {
            case (Clock.TimesOfDay.Morning):
                return morningDeck;

            case (Clock.TimesOfDay.Afternoon):
                return afternoonDeck;

            case (Clock.TimesOfDay.Night):
                return nightDeck;
            default:
                Debug.Log("Error:GetTimeOfEvent");
                return null;
              
        }
    }

    public Events[] GetDayEvents()
    {
        switch (clock.GetDay())
        {
            case (1):
                return day1Deck;

            case (2):
                return day2Deck;

            case (3):
                return day3Deck;

            default:
                Debug.Log("Error:GetTimeOfEvent");
                return null;

        }
    }

    private Events[] ChooseEventType(Player player, Node node)
    {
        return GetLocalEventType(node.NodeType(player));
    }

    private Events[] ChooseAlcoolEvents(Player player)
    {
        int alcool = player.GetAlcool();
        if (alcool <= lowAlcoolLvl)
        {
            return lowAlcoolDeck;
        }
        else if (alcool >= highAlcoolLvl)
        {
            return highAlcoolDeck;
        }
        else
        {
            return null;
        }
    }

    private Events[] ChooseEnergyEvents(Player player)
    {
        int energy = player.GetEnergy();
        if (energy <= lowEnergyLvl)
        {
            return lowEnergyDeck;
        }
        else
        {
            return null;
        }

    }

    private Events[] UnionEvents(Events[] locationDeck, Events[] alcoolDeck,
        Events[] energyDeck)
    {
        Events[] eventaux = locationDeck;
        if (locationDeck != null)
        {
            if (alcoolDeck != null)
            {
                eventaux = eventaux.Union(alcoolDeck).ToArray();

                return eventaux;
            }

            if (energyDeck != null)
            {
                eventaux = eventaux.Union(energyDeck).ToArray();
            }
        }
        return eventaux;
    }

    private Events[] IntersectEvents(Events[] mainDeck, Events[] timeofDayDeck,
    Events[] dayDeck)
    {
        Events[] eventaux = mainDeck;
        if (mainDeck != null)
        {
            if (timeofDayDeck != null)
            {
                eventaux = eventaux.Union(timeofDayDeck).ToArray();

            }

            if (dayDeck != null)
            {
                eventaux = eventaux.Union(dayDeck).ToArray();
            }
        }
        return eventaux;
    }

    public Events ChooseRandomEvent(Player player, Node node, EventsUi eventsUi)
    {
        events = ChooseEventType(player, node);
        alcoolEvents = ChooseAlcoolEvents(player);
        energyEvents = ChooseEnergyEvents(player);
        timeOfDayEvents = GetTimeOfDayEvents();
        dayEvents = GetDayEvents();


        events = UnionEvents(events, alcoolEvents, energyEvents);
        events = IntersectEvents(events, timeOfDayEvents, dayEvents);


        rnd = Random.Range(0, events.Length);
        randomEvent = events[rnd];
        return randomEvent;
        
    }










}