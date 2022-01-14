using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventsUi : MonoBehaviour
{
    public GameObject choices2;
    public Image background2;
    public Text choice0Button0;
    public Text choice0Button1;
    public Text description1;


    public GameObject choices3;
    public Image background3;
    public Text choice1Button0;
    public Text choice1Button1;
    public Text choice1Button2;
    public Text description2;

    public GameObject result;

    public Events evenaux;
    public Player player;
    public void EventUi(Events even)
    {
        evenaux = even;
        if (even.decisions.Length == 2)
        {

            background2.sprite = even.background;
            choice0Button0.text = even.decisions[0].stringI;
            choice0Button1.text = even.decisions[1].stringI;
            description1.text = even.Event;
            choices2.SetActive(true);

        }
        if (even.decisions.Length == 3)
        {

            background3.sprite = even.background;
            choice1Button0.text = even.decisions[0].stringI;
            choice1Button1.text = even.decisions[1].stringI;
            choice1Button2.text = even.decisions[2].stringI;
            description2.text = even.Event;
            choices3.SetActive(true);

        }

    }

    public void Resultcanvas()
    {
        result.SetActive(true);
    }

    public void Choice21()
    {
        player.ChangeStats(player, evenaux.decisions[0].alcoolPlus, evenaux.decisions[0].funPlus, evenaux.decisions[0].socialPlus, evenaux.decisions[0].moneyPlus, evenaux.decisions[0].energyPlus);
        choices2.SetActive(false);
        result.GetComponentInChildren<Text>().text = evenaux.decisions[0].stringF;

    }

    public void Choice22()
    {
        player.ChangeStats(player, evenaux.decisions[1].alcoolPlus, evenaux.decisions[1].funPlus, evenaux.decisions[1].socialPlus, evenaux.decisions[1].moneyPlus, evenaux.decisions[1].energyPlus);
        choices2.SetActive(false);
        result.GetComponentInChildren<Text>().text = evenaux.decisions[1].stringF;

    }

    public void Choice31()
    {
        player.ChangeStats(player, evenaux.decisions[0].alcoolPlus, evenaux.decisions[0].funPlus, evenaux.decisions[0].socialPlus, evenaux.decisions[0].moneyPlus, evenaux.decisions[0].energyPlus);
        choices3.SetActive(false);
        result.GetComponentInChildren<Text>().text = evenaux.decisions[0].stringF;

    }
    public void Choice32()
    {
        player.ChangeStats(player, evenaux.decisions[1].alcoolPlus, evenaux.decisions[1].funPlus, evenaux.decisions[1].socialPlus, evenaux.decisions[1].moneyPlus, evenaux.decisions[1].energyPlus);
        choices3.SetActive(false);
        result.GetComponentInChildren<Text>().text = evenaux.decisions[1].stringF;

    }
    public void Choice33()
    {
        player.ChangeStats(player, evenaux.decisions[2].alcoolPlus, evenaux.decisions[2].funPlus, evenaux.decisions[2].socialPlus, evenaux.decisions[2].moneyPlus, evenaux.decisions[2].energyPlus);
        choices3.SetActive(false);
        result.GetComponentInChildren<Text>().text = evenaux.decisions[2].stringF;

    }

    public void Morechoices1()
    {
        if (evenaux.decisions[0].moreDecisionsStages.Length == 0)
        {
            Resultcanvas();
        }
        else if (evenaux.decisions[0].moreDecisionsStages[0] != null)
        {

            Debug.Log(evenaux.decisions[0].moreDecisionsStages[0]);
            EventUi(evenaux.decisions[0].moreDecisionsStages[0]);

        }
    }

    public void Morechoices2()
    {
        if (evenaux.decisions[1].moreDecisionsStages.Length == 0)
        {
            Resultcanvas();
        }
        else if (evenaux.decisions[1].moreDecisionsStages[0] != null)
        {

            Debug.Log(evenaux.decisions[1].moreDecisionsStages[0]);
            EventUi(evenaux.decisions[1].moreDecisionsStages[0]);

        }
    }

    public void Morechoices3()
    {
        if (evenaux.decisions[2].moreDecisionsStages.Length == 0)
        {
            Resultcanvas();
        }
        else if (evenaux.decisions[2].moreDecisionsStages[0] != null)
        {
            EventUi(evenaux.decisions[2].moreDecisionsStages[0]);
        }
    }




}
