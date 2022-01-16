using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] private int hours = 22;
    [SerializeField] private int minutes = 0;
    [SerializeField] private int day = 1;
    [SerializeField] private int minTimeBetweenEvents = 10;
    [SerializeField] private int minuterPerHour = 60;



    public void UpdateTime(int timepassed)
    {
        this.minutes += (minTimeBetweenEvents + timepassed) % minuterPerHour;
        this.hours += (minuterPerHour / (minTimeBetweenEvents + timepassed));
        if(this.hours >= 24)
        {
            this.hours = 0;
            this.day += 1;
        }
        Debug.Log("Day "+this.day + "Time " + this.hours + ":" + this.minutes);
        
    }
    



}
