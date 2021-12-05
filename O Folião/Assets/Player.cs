using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int MaxAlcool;
    [SerializeField]
    private int MaxFun;
    [SerializeField]
    private int MaxHunger;
    [SerializeField]
    private int MaxSocial;

    [SerializeField]
    private int alcool;
    [SerializeField]
    private int fun;
    [SerializeField]
    private int hunger;
    [SerializeField]
    private int social;
    [SerializeField]
    private int money;
    [SerializeField]
    private GameObject position;

    public barsUI bars;

    private void Start()
    {
        alcool = MaxAlcool;
        fun = MaxFun;
        hunger = MaxHunger;
        social = MaxSocial;
        bars.SetMaxAllBars(MaxAlcool, MaxFun, MaxHunger, MaxSocial);


    }


    public void GetAllStats()
    {

    }


    public void ChangeStats(Player player, int alcool = 0, int fun = 0, int hunger = 0, int social = 0, int money = 0)
    {
        player.alcool += alcool;
        player.fun += fun;
        player.hunger += hunger;
        player.social += social;
        player.money += money;

        if(player.alcool > MaxAlcool)
        {
            player.alcool = MaxAlcool;
        }
        if (player.fun > MaxFun)
        {
            player.fun = MaxFun;
        }
        if (player.hunger > MaxHunger)
        {
            player.hunger = MaxHunger;
        }
        if(player.social > MaxSocial)
        { 
            player.social = MaxSocial;
        }

        if (player.alcool < 0)
        {
            player.alcool = 0;
        }
        if (player.fun < 0)
        {
            player.fun = 0;
        }
        if (player.hunger < 0)
        {
            player.hunger = 0;
        }
        if (player.social < 0)
        {
            player.social = 0;
        }

        Debug.Log("Alcool " + player.alcool);
        Debug.Log("Fun " + player.fun);
        Debug.Log("Hunger " + player.hunger);
        Debug.Log("Social " + player.social);

        bars.SetValueAllBars(player.alcool, player.fun, player.hunger, player.social);
    }

    public void ChangePosition(GameObject position)
    {
        this.position = position;
    }

    public void GetAlcool()
    {
        Debug.Log(this.alcool);
    }

    public GameObject Position()
    {
        return this.position;
    }

    


    






}
