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
    private Events[] alcoolevents = null;
    private Events[] energyevents = null;


    private int rnd;

    [SerializeField] private Events[] stagesDeck;

    [SerializeField] private Events[] barsDeck;

    [SerializeField] private Events[] lowAlcoolDeck;

    [SerializeField] private Events[] highAlcoolDeck;

    [SerializeField] private Events[] lowEnergyDeck;

    private void Awake()
    {
        rnd = Random.Range(1, 254);
    }



    public Events[] GetCertainEventType(Node.Type nodetype)
    {
        if (nodetype == Node.Type.Stages)
        {
            return stagesDeck;
        }
        else if (nodetype == Node.Type.Bars)
        {
            return barsDeck;
        }

        return null;

    }
    private Events[] ChooseEventType(Player player, Node node)
    {
        return GetCertainEventType(node.NodeType(player));
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

    private Events[] IntersectEvents(Events[] locationDeck, Events[] alcoolDeck,
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

    public Events ChooseRandomEvent(Player player, Node node, EventsUi eventsUi)
    {
        events = ChooseEventType(player, node);
        alcoolevents = ChooseAlcoolEvents(player);
        energyevents = ChooseEnergyEvents(player);
        events = IntersectEvents(events, alcoolevents, energyevents);


        rnd = Random.Range(0, events.Length);
        randomEvent = events[rnd];
        return randomEvent;
        
    }










}