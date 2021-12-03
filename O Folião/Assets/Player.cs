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

    public void ChangeStats(int alcool = 0, int fun = 0, int hunger = 0, int social = 0, int money = 0)
    {
        this.alcool += alcool;
        this.fun += fun;
        this.hunger += hunger;
        this.social += social;
        this.money += money;

        if(this.alcool > 100 || this.fun > 100 || this.hunger > 100 || this.social > 100)
        {
            this.alcool = 100;
            this.fun = 100;
            this.hunger = 100;
            this.social = 100;
        }

        if (this.alcool < 0 || this.fun < 0 || this.hunger < 0 || this.social < 0)
        {
            this.alcool = 0;
            this.fun = 0;
            this.hunger = 0;
            this.social = 0;
        }


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
