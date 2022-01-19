using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventsUi : MonoBehaviour
{
    [SerializeField] private GameObject choices2;
    [SerializeField] private Image background2;
    [SerializeField] private Text choice0Button0;
    [SerializeField] private Text choice0Button1;
    [SerializeField] private Text description1;


    [SerializeField] private GameObject choices3;
    [SerializeField] private Image background3;
    [SerializeField] private Text choice1Button0;
    [SerializeField] private Text choice1Button1;
    [SerializeField] private Text choice1Button2;
    [SerializeField] private Text description2;

    [SerializeField] private GameObject result;
    [SerializeField] private GameObject resources;

    [SerializeField] private Events evenaux;
    [SerializeField] private Player player;
    [SerializeField] private DecisionRequirements decisionRequirements;

    [SerializeField] private Text time;
    [SerializeField] private Text calendar;
    [SerializeField] private Clock clock;

    [SerializeField] private EventContinuityHandler eventContinuityHandler;
    public void EventUi(Events even)
    {
        evenaux = even;
        if (even.decisions.Length == 2)
        {

            background2.sprite = even.background;
            choice0Button0.text = even.decisions[0].decisionDescription;
            choice0Button1.text = even.decisions[1].decisionDescription;
            description1.text = even.Event;
            choices2.SetActive(true);

        }
        if (even.decisions.Length == 3)
        {

            background3.sprite = even.background;
            choice1Button0.text = even.decisions[0].decisionDescription;
            choice1Button1.text = even.decisions[1].decisionDescription;
            choice1Button2.text = even.decisions[2].decisionDescription;
            description2.text = even.Event;
            choices3.SetActive(true);

        }

    }

    public void ResultCanvas()
    {
        result.SetActive(true);
    }

    public void ResourcesCanvas()
    {
        resources.SetActive(true);
    }

    public void DoubleChoice(int decisionNumber)
    {
        

        if(decisionRequirements.CheckForDecisionSucess(player, evenaux.decisions[decisionNumber]) == true)
        {
            Sucess(decisionNumber);
            eventContinuityHandler.EventContinuity
                (evenaux.decisions[decisionNumber].sucessEvent[0].nextEventStoryLine,
                 evenaux);
            choices2.SetActive(false);
            Morechoices(evenaux.decisions[decisionNumber].sucessEvent[0].moreDecisionsStages);
        }
        else
        {
            Failure(decisionNumber);
            eventContinuityHandler.EventContinuity
                (evenaux.decisions[decisionNumber].failedEvent[0].nextEventStoryLine,
                 evenaux);
            choices2.SetActive(false);
            Morechoices(evenaux.decisions[decisionNumber].failedEvent[0].moreDecisionsStages);
        }

        

    }
    public void TripleChoice(int decisionNumber)
    {
        if (decisionRequirements.CheckForDecisionSucess(player, evenaux.decisions[decisionNumber]) == true)
        {
            Sucess(decisionNumber);
            eventContinuityHandler.EventContinuity
                (evenaux.decisions[decisionNumber].sucessEvent[0].nextEventStoryLine,
                 evenaux);
            choices3.SetActive(false);
            Morechoices(evenaux.decisions[decisionNumber].sucessEvent[0].moreDecisionsStages);

        }
        else
        {
            Failure(decisionNumber);
            eventContinuityHandler.EventContinuity
                (evenaux.decisions[decisionNumber].failedEvent[0].nextEventStoryLine,
                 evenaux);
            choices3.SetActive(false);
            Morechoices(evenaux.decisions[decisionNumber].failedEvent[0].moreDecisionsStages);
        }


    }

    public void ShowResourceChanges(int decisionNumber, bool sucess)
    {
        if(sucess)
        { 
            result.GetComponentInChildren<Text>().text += "\n" +
            ResourceToString(evenaux.decisions[decisionNumber].sucessEvent[0].alcoolPlus,
            "Álcool")
            + ResourceToString(evenaux.decisions[decisionNumber].sucessEvent[0].funPlus,
            "Diversão")
            + ResourceToString(evenaux.decisions[decisionNumber].sucessEvent[0].socialPlus,
            "Social")
            + ResourceToString(evenaux.decisions[decisionNumber].sucessEvent[0].energyPlus,
            "Energia");
        }else if(!sucess)
        {
            result.GetComponentInChildren<Text>().text += "\n" + 
            ResourceToString(evenaux.decisions[decisionNumber].failedEvent[0].alcoolPlus,
            "Álcool")
            + ResourceToString(evenaux.decisions[decisionNumber].failedEvent[0].funPlus,
            "Diversão")
            + ResourceToString(evenaux.decisions[decisionNumber].failedEvent[0].socialPlus,
            "Social")
            + ResourceToString(evenaux.decisions[decisionNumber].failedEvent[0].energyPlus,
            "Energia");
        }
    }

    private void Sucess(int decisionNumber)
    {
        player.ChangeStats(player, evenaux.decisions[decisionNumber].sucessEvent[0].alcoolPlus,
                evenaux.decisions[0].sucessEvent[0].funPlus, 
                evenaux.decisions[0].sucessEvent[0].socialPlus,
                evenaux.decisions[0].sucessEvent[0].moneyPlus, 
                evenaux.decisions[0].sucessEvent[0].energyPlus);
        TimeUi(clock.UpdateTime(evenaux.decisions[0].sucessEvent[0].timePassed));
        CalendarUi();

        result.GetComponentInChildren<Text>().text = evenaux.decisions[decisionNumber].sucessEvent[0].description;
        ShowResourceChanges(decisionNumber, true);
    }

    private void Failure(int decisionNumber)
    {
        player.ChangeStats(player, evenaux.decisions[decisionNumber].failedEvent[0].alcoolPlus,
            evenaux.decisions[0].failedEvent[0].funPlus, 
            evenaux.decisions[0].failedEvent[0].socialPlus,
            evenaux.decisions[0].failedEvent[0].moneyPlus, 
            evenaux.decisions[0].failedEvent[0].energyPlus);
        TimeUi(clock.UpdateTime(evenaux.decisions[0].failedEvent[0].timePassed));
        result.GetComponentInChildren<Text>().text = evenaux.decisions[decisionNumber].failedEvent[0].description;
        ShowResourceChanges(decisionNumber, false);
    }


    public void Morechoices(Events[] nextDecisionStage)
    {

        if (nextDecisionStage.Length == 0)
        {
            ResultCanvas();
        }
        else if (nextDecisionStage != null)
        {
            ResultCanvas();
            EventUi(nextDecisionStage[0]);
        }
    }

    public void TimeUi(string timetxt)
    {       
        time.text = (timetxt);
    }

    public void CalendarUi()
    {
        calendar.text = "Day " + clock.GetDay();
    }

    public string ResourceToString(int value, string resource)
    {
        if(value > 0 && value < 15)
        {
            return resource + ": +  ";
        }
        else if(value >= 15 )
        {
            return resource + ": ++  ";
        }
        else if(value < 0 && value > -15)
        {
            return resource + ": -  ";
        }
        else if(value < -15)
        {
            return resource + ": --  ";
        }
        else
        {
            return "";
        }
    }



}
