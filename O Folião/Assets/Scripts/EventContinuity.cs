using UnityEngine;



[CreateAssetMenu(fileName = "New EventContinuity/StoryLine", menuName = "Events/New Continuity")]
public class EventContinuity : ScriptableObject
{
    public enum DayOfWeek { Day1, Day2, Day3, Day4, Day5 };

    [SerializeField] private DayOfWeek _dayOfWeek;
    public DayOfWeek dayOfWeek { get { return _dayOfWeek; } }

    public enum Local { Stages, Bars };

    [SerializeField] private Local _local;
    public Local local { get { return _local; } }

    public enum TimeOfDay { Morning, Afternoon, Night };

    [SerializeField] private TimeOfDay _timeOfDay;
    public TimeOfDay timeOfDay { get { return _timeOfDay; } }

    [SerializeField] private Events _theEvent = null;
    public Events theEvent { get { return _theEvent; } }

}   
    
