using UnityEngine;

public class Clock : MonoBehaviour
{

    [SerializeField] private int hours = 22;
    [SerializeField] private int minutes = 0;
    [SerializeField] private int day = 1;
    [SerializeField] private int minTimeBetweenEvents = 10;
    [SerializeField] private int minuterPerHour = 60;

    public enum TimesOfDay
    {
        Night,
        Afternoon,
        Morning
    }

    public TimesOfDay currentTimeOfDay { get; private set; }
    private TimesOfDay[] timesOfDay;
    private bool daychange = false;
    private int extraHours;
    private int extraMin;

    public int GetHours()
    {
        return this.hours;
    }

    public int GetDay()
    {
        return this.day;
    }

    public TimesOfDay GetCurrentTimeOfDay()
    {
        return this.currentTimeOfDay;
    }

    public string UpdateTime(int timepassed)
    {


        this.minutes += (minTimeBetweenEvents + timepassed);

        extraHours = this.minutes / minuterPerHour;

        this.hours += extraHours;


        extraMin = this.minutes % minuterPerHour;


        if (this.minutes >= minuterPerHour)
        {

            this.minutes = 0 + extraMin;

        }

        if (this.hours >= 24)
        {
            this.hours = 0 + extraHours-1;
            daychange = true;

        }

        if(this.hours >= 6 && daychange == true)
        {
            this.day += 1;
            daychange = false;

        }

        TimeOfDay();

        return (hours.ToString() + ":" + minutes.ToString());
        
    }

    private void TimeOfDay()
    {
        int hours = GetHours();
        GetCurrentTimeOfDay();
        if (hours >= 6 && hours < 12)
        {
            currentTimeOfDay = TimesOfDay.Morning;
        }
        else if (hours >= 12 && hours < 20)
        {
            currentTimeOfDay = TimesOfDay.Afternoon;
        }
        else if (hours >= 20 || hours < 6)
        {
            currentTimeOfDay = TimesOfDay.Night;
        }

    }



    



}
