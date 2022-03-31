using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    [SerializeField] private Events cheatShowEvent;
    [SerializeField] private Events cheatShowEventContinuity;
    [SerializeField] private Events cheatShowEventContinuity2;

    [SerializeField] private Player player;
    [SerializeField] private EventsUi eventsUi;
    [SerializeField] private Clock clock;
    



    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.ChangeStats(player, 10, 0, 0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player.ChangeStats(player, -10, 0, 0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            player.ChangeStats(player, 0, 10, 0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            player.ChangeStats(player, 0,-10, 0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            player.ChangeStats(player, 0, 0, 10, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            player.ChangeStats(player, 0, 0, -10, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            player.ChangeStats(player, 0, 0, 0, 0,10);
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            player.ChangeStats(player, 0, 0, 0, 0,-10);
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            player.ChangeStats(player, 0, 0, 0, 10, 0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            player.ChangeStats(player, 0, 0, 0, -10, 0);
        }

        /*if(Input.GetKeyDown(KeyCode.Q))
        {
            eventsUi.EventUi(cheatShowEvent);
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            eventsUi.EventUi(cheatShowEventContinuity);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            eventsUi.EventUi(cheatShowEventContinuity2);
        }*/

        //Add x minutes 
        if(Input.GetKeyDown(KeyCode.M))
        {
            
            eventsUi.TimeUi(clock.UpdateTime(60));
            eventsUi.CalendarUi();
            
        }     
    }
}
