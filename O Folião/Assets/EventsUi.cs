using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventsUi : MonoBehaviour
{
    public GameObject choices2;
    public GameObject background2;
    public GameObject choice0button0;
    public GameObject choice0button1;
    public GameObject description1;


    public GameObject choices3;
    public GameObject background3;
    public GameObject choice1button0;
    public GameObject choice1button1;
    public GameObject choice1button2;
    public GameObject description2;

    public GameObject result;

    public Events evenaux;
    public Player player;
    public void eventUi(Events even)
    {
        evenaux = even;
        if(even.decisions.Length == 2)
        {

            background2.GetComponent<Image>().sprite = even.background;
            choice0button0.GetComponentInChildren<Text>().text = even.decisions[0].stringI;
            choice0button1.GetComponentInChildren<Text>().text = even.decisions[1].stringI;
            description1.GetComponentInChildren<Text>().text = even.Event;
            choices2.SetActive(true);

        }
        if (even.decisions.Length == 3)
        {

            background3.GetComponent<Image>().sprite = even.background;
            choice1button0.GetComponentInChildren<Text>().text = even.decisions[0].stringI;
            choice1button1.GetComponentInChildren<Text>().text = even.decisions[1].stringI;
            choice1button2.GetComponentInChildren<Text>().text = even.decisions[2].stringI;
            description2.GetComponentInChildren<Text>().text = even.Event;
            choices3.SetActive(true);

        }

    }

    public void resultcanvas()
    {
        result  .SetActive(true);
    }

    public void choice11()
    {
        player.ChangeStats(player, evenaux.decisions[0].alcoolD, evenaux.decisions[0].funD, evenaux.decisions[0].socialD, evenaux.decisions[0].moneyD, evenaux.decisions[0].energyD);
        choices2.SetActive(false);
        result.GetComponentInChildren<Text>().text = evenaux.decisions[0].stringF;
        resultcanvas();
    }

    public void choice12()
    {
        player.ChangeStats(player, evenaux.decisions[1].alcoolD, evenaux.decisions[1].funD, evenaux.decisions[1].socialD, evenaux.decisions[1].moneyD, evenaux.decisions[1].energyD);
        choices2.SetActive(false);
        result.GetComponentInChildren<Text>().text = evenaux.decisions[1].stringF;
        resultcanvas();
    }

    public void choice31()
    {
        player.ChangeStats(player, evenaux.decisions[0].alcoolD, evenaux.decisions[0].funD, evenaux.decisions[0].socialD, evenaux.decisions[0].moneyD, evenaux.decisions[0].energyD);
        choices3.SetActive(false);
        result.GetComponentInChildren<Text>().text = evenaux.decisions[0].stringF;
        resultcanvas();
    }
    public void choice32()
    {
        player.ChangeStats(player, evenaux.decisions[1].alcoolD, evenaux.decisions[1].funD, evenaux.decisions[1].socialD, evenaux.decisions[1].moneyD, evenaux.decisions[1].energyD);
        choices3.SetActive(false);
        result.GetComponentInChildren<Text>().text = evenaux.decisions[1].stringF;
        resultcanvas();
    }
    public void choice33()
    {
        player.ChangeStats(player, evenaux.decisions[2].alcoolD, evenaux.decisions[2].funD, evenaux.decisions[2].socialD, evenaux.decisions[2].moneyD, evenaux.decisions[2].energyD);
        choices3.SetActive(false);
        result.GetComponentInChildren<Text>().text = evenaux.decisions[2].stringF;
        resultcanvas();
    }


}
