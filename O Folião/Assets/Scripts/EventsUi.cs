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

    [SerializeField] private Events evenaux;
    [SerializeField] private Player player;
    [SerializeField] private DecisionRequirements decisionRequirements;

    [SerializeField] private Text time;
    [SerializeField] private Clock clock;
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
        choices2.SetActive(true);
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

    public void Resultcanvas()
    {
        result.SetActive(true);
    }

    public void DoubleChoice(int decisionNumber)
    {
        

        if(decisionRequirements.CheckForDecisionSucess(player, evenaux.decisions[decisionNumber]) == true)
        {
            Sucess(decisionNumber);
            choices2.SetActive(false);
            Morechoices(evenaux.decisions[decisionNumber].sucessEvent[0].moreDecisionsStages);
        }
        else
        {
            Failure(decisionNumber);
            choices2.SetActive(false);
            Morechoices(evenaux.decisions[decisionNumber].failedEvent[0].moreDecisionsStages);
        }

        

    }
    public void TripleChoice(int decisionNumber)
    {
        if (decisionRequirements.CheckForDecisionSucess(player, evenaux.decisions[decisionNumber]) == true)
        {
            Sucess(decisionNumber);
            choices3.SetActive(false);
            Morechoices(evenaux.decisions[decisionNumber].sucessEvent[0].moreDecisionsStages);

        }
        else
        {
            Failure(decisionNumber);
            choices3.SetActive(false);
            Morechoices(evenaux.decisions[decisionNumber].failedEvent[0].moreDecisionsStages);
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
        result.GetComponentInChildren<Text>().text = evenaux.decisions[decisionNumber].sucessEvent[0].description;
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
    }


    public void Morechoices(Events[] nextDecisionStage)
    {

        if (nextDecisionStage.Length == 0)
        {
            Resultcanvas();
        }
        else if (nextDecisionStage != null)
        {
            EventUi(nextDecisionStage[0]);
        }
    }

    public void TimeUi(string timetxt)
    {       
        time.text = (timetxt);
    }

    



}
