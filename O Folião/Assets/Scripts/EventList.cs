using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class EventList : MonoBehaviour
{
    [SerializeField]
    private const int lowAlcoolLvl = 30;

    [SerializeField]
    private const int highAlcoolLvl = 80;

    [SerializeField]
    private const int lowEnergyLvl = 30;



    private List<Events> events = null;
    private Events randomEvent = null;
    private List<Events> alcoolEvents = null;
    private List<Events> energyEvents = null;
    private List<Events> timeOfDayEvents = null;
    private List<Events> dayEvents = null;

    private int rnd;

    [Header("Local Decks")]
    [SerializeField] private List<Events> stagesDeck;
    [SerializeField] private List<Events> barsDeck;
    [SerializeField] private List<Events> hotelDeck;

    [Header("Resources Decks")]
    [SerializeField] private List<Events> lowAlcoolDeck;
    [SerializeField] private List<Events> highAlcoolDeck;
    [SerializeField] private List<Events> lowEnergyDeck;

    [Header("TimeOfDay Decks")]
    [SerializeField] private List<Events> morningDeck;
    [SerializeField] private List<Events> afternoonDeck;
    [SerializeField] private List<Events> nightDeck;

    [Header("Day Decks")]
    [SerializeField] private List<Events> day1Deck;
    [SerializeField] private List<Events> day2Deck;
    [SerializeField] private List<Events> day3Deck;

    public Clock clock;
    public EventContinuityHandler eventContinuity;
    [SerializeField] private EventsUi eventsUi;

    private List<Events> GetLocalEventType(Node.Type nodetype)
    {
        switch(nodetype)
        {
            case (Node.Type.Stages):
                return stagesDeck;
            case (Node.Type.Bars):
                return barsDeck;
            case (Node.Type.Hotels):
                return hotelDeck;
            default:
                Debug.Log("Error:GetLocalEvent");
                return null;
               
        }
    }

    private List<Events> GetTimeOfDayEvents()
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

    private List<Events> GetDayEvents()
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

    private List<Events> ChooseEventType(Player player, Node node)
    {
        return GetLocalEventType(node.NodeType(player));
    }

    private List<Events> ChooseAlcoolEvents(Player player)
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

    private List<Events> ChooseEnergyEvents(Player player)
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

    private List<Events> UnionEvents(List<Events> locationDeck, List<Events> alcoolDeck,
        List<Events> energyDeck)
    {
        List<Events> eventaux = locationDeck;
        if (locationDeck != null)
        {
            if (alcoolDeck != null)
            {
                eventaux = eventaux.Union(alcoolDeck).ToList();

                return eventaux;
            }

            if (energyDeck != null)
            {
                eventaux = eventaux.Union(energyDeck).ToList();
            }
        }
        return eventaux;
    }

    private List<Events> IntersectEvents(List<Events> mainDeck, List<Events> timeofDayDeck,
    List<Events> dayDeck)
    {
        List<Events> eventaux = mainDeck;
        if (mainDeck != null)
        {
            if (timeofDayDeck != null)
            {
                eventaux = eventaux.Intersect(timeofDayDeck).ToList();

            }

            if (dayDeck != null)
            {
                eventaux = eventaux.Intersect(dayDeck).ToList();
            }
        }
        return eventaux;
    }

    public Events ChooseRandomEvent(Player player, Node node, EventsUi eventsUi)
    {

        events = ChooseEventType(player, node);
        //if temporário apenas arranjo rápido para uma feature
        if (events == hotelDeck)
        {
            return hotelDeck[0];
        }
            alcoolEvents = ChooseAlcoolEvents(player);
            energyEvents = ChooseEnergyEvents(player);
            timeOfDayEvents = GetTimeOfDayEvents();
            dayEvents = GetDayEvents();



            events = UnionEvents(events, alcoolEvents, energyEvents);
            events = IntersectEvents(events, timeOfDayEvents, dayEvents);


            rnd = Random.Range(0, events.Count);
            randomEvent = events[rnd];
        
        return randomEvent;
        
    }

    public void AddToDecks(EventContinuity newEvent)
    {
        switch ((int)newEvent.dayOfWeek)
        {
            case 0:
                day1Deck.Add(newEvent.theEvent);
                break;
            case 1:
                day2Deck.Add(newEvent.theEvent);
                break;
            default:
                day3Deck.Add(newEvent.theEvent);
                break;
        }

        switch ((int)newEvent.timeOfDay)
        {
            case 0:
                morningDeck.Add(newEvent.theEvent);
                break;
            case 1:
                afternoonDeck.Add(newEvent.theEvent);
                break;
            case 2:
                nightDeck.Add(newEvent.theEvent);
                break;
            default:
                Debug.Log("Error timeofdayContinuity");
                break;
        }

        switch ((int)newEvent.local)
        {
            case 0:
                stagesDeck.Add(newEvent.theEvent);
                break;
            case 1:
                barsDeck.Add(newEvent.theEvent);
                break;
            default:
                Debug.Log("Error localContinuity");
                break;
        }
    }

    public void RemoveFromDecks(EventContinuity newEvent, Events oldEvent)
    {
        switch ((int)oldEvent.dayOfWeek)
        {
            case 0:
                day1Deck.Remove(oldEvent);
                break;
            case 1:
                day2Deck.Remove(oldEvent);
                break;
            default:
                day3Deck.Remove(oldEvent);
                break;
        }

        switch ((int)oldEvent.timeOfDay)
        {
            case 0:
                morningDeck.Remove(oldEvent);
                break;
            case 1:
                afternoonDeck.Remove(oldEvent);
                break;
            case 2:
                nightDeck.Remove(oldEvent);
                break;
            default:
                Debug.Log("Error timeofdayContinuity");
                break;
        }

        for (int local = 0; local < oldEvent.locals.Length; local++)
        {
            switch ((int)oldEvent.locals[local])
            {
                case 0:
                    stagesDeck.Remove(oldEvent);
                    break;
                case 1:
                    barsDeck.Remove(oldEvent);
                    break;
                default:
                    Debug.Log("Error localContinuity");
                    break;
            }
        }
    }



}