using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


    [Serializable()]
    public struct Decisions
{ 
        [SerializeField] private string _decisionDescription;
        public string decisionDescription { get { return _decisionDescription; } }

        [SerializeField] private int _minAlcool;
        public int minAlcool { get { return _minAlcool; } }

        [SerializeField] private int _minFun;
        public int minFun { get { return _minFun; } }

        [SerializeField] private int _minSocial;
        public int minSocial { get { return _minSocial; } }

        [SerializeField] private int _minEnergy;
        public int minEnergy { get { return _minEnergy; } }

        [SerializeField] private int _minMoney;
        public int minMoney { get { return _minMoney; } }

        [SerializeField] SucessEvent[] _sucessEvent;
        public SucessEvent[] sucessEvent { get { return _sucessEvent; } }

        [SerializeField] FailedEvent[] _failedEvent;
        public FailedEvent[] failedEvent { get { return _failedEvent; } }

    }
[Serializable()]
public struct SucessEvent
{
    [SerializeField] private string _description;
    public string description { get { return _description; } }

    [SerializeField] private int _timePassed;
    public int timePassed { get { return _timePassed; } }

    [SerializeField] private int _alcoolPlus;
    public int alcoolPlus { get { return _alcoolPlus; } }

    [SerializeField] private int _funPlus;
    public int funPlus { get { return _funPlus; } }

    [SerializeField] private int _socialPlus;
    public int socialPlus { get { return _socialPlus; } }

    [SerializeField] private int _moneyPlus;
    public int moneyPlus { get { return _moneyPlus; } }

    [SerializeField] private int _energyPlus;
    public int energyPlus { get { return _energyPlus; } }

    [SerializeField] private Events[] _moreDecisionsStages;
    public Events[] moreDecisionsStages { get { return _moreDecisionsStages; } }

    [SerializeField] private EventContinuity _nextEventStoryLine;
    public EventContinuity nextEventStoryLine { get { return _nextEventStoryLine; } }
}


[Serializable()]
public struct FailedEvent
{
    [SerializeField] private string _description;
    public string description { get { return _description; } }

    [SerializeField] private int _timePassed;
    public int timePassed { get { return _timePassed; } }

    [SerializeField] private int _alcoolPlus;
    public int alcoolPlus { get { return _alcoolPlus; } }

    [SerializeField] private int _funPlus;
    public int funPlus { get { return _funPlus; } }

    [SerializeField] private int _socialPlus;
    public int socialPlus { get { return _socialPlus; } }

    [SerializeField] private int _moneyPlus;
    public int moneyPlus { get { return _moneyPlus; } }

    [SerializeField] private int _energyPlus;
    public int energyPlus { get { return _energyPlus; } }

    [SerializeField] private Events[] _moreDecisionsStages;
    public Events[] moreDecisionsStages { get { return _moreDecisionsStages; } }

    [SerializeField] private EventContinuity _nextEventStoryLine;
    public EventContinuity nextEventStoryLine {get { return _nextEventStoryLine; } }
}


[CreateAssetMenu(fileName = "New Event", menuName = "Events/new Event")]
public class Events : ScriptableObject
{

    [SerializeField] private String _event = String.Empty;
    public String Event { get { return _event; } }

    [SerializeField] private Sprite _background = null;
    public Sprite background { get { return _background; } }

    [SerializeField] Decisions[] _decisions = null;
    public Decisions[] decisions { get { return _decisions; } }


    //Tags only for easy finding and placing of the object
    public enum Alcool { Low30, Normal, High80 };

    [SerializeField]
    private Alcool alcool;

    public enum Energy { Low30, Normal };

    [SerializeField]
    private Energy energy;

    public enum TimeOfDay { Morning, Afternoon, Night };

    [SerializeField] private TimeOfDay _timeOfDay;
    public TimeOfDay timeOfDay { get { return _timeOfDay; } }


    public enum DayOfWeek { Day1, Day2, Day3, Day4, Day5 };

    [SerializeField] private DayOfWeek _dayOfWeek;
    public DayOfWeek dayOfWeek { get { return _dayOfWeek; } }

    public enum Locals { Stages, Bars, Hotels };

    [SerializeField] private Locals[] _locals;
    public Locals[] locals { get { return _locals; } }





}