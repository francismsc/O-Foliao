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
    private int MaxSocial;
    [SerializeField]
    private int MaxEnergy;

    [SerializeField]
    private int alcool;
    [SerializeField]
    private int fun;
    [SerializeField]
    private int social;
    [SerializeField]
    private int energy;

    [SerializeField]
    private int money;
    [SerializeField]
    private GameObject position;
    [SerializeField]
    public SceneChanger scene;

    public barsUI bars;


    private void Start()
    {
        alcool = 99;
        fun = MaxFun;
        social = MaxSocial;
        energy = MaxEnergy;
        bars.SetMaxAllBars(MaxAlcool, MaxFun, MaxSocial, MaxEnergy,  money);



    }



    public void GetAllStats()
    {

    }


    public void ChangeStats(Player player, int alcool = 0, int fun = 0, int social = 0, int money = 0, int energy = 0)
    {
        player.alcool += alcool;
        player.fun += fun;
        player.social += social;
        player.money += money;
        player.energy += energy;

        if(player.alcool > MaxAlcool)
        {
            player.alcool = MaxAlcool;
        }
        if (player.fun > MaxFun)
        {
            player.fun = MaxFun;
        }
        if(player.social > MaxSocial)
        { 
            player.social = MaxSocial;
        }
        if(player.energy > MaxEnergy)
        {
            player.energy = MaxEnergy;
        }

        if (player.alcool < 0)
        {
            player.alcool = 0;
        }
        if (player.fun < 0)
        {
            player.fun = 0;
        }
        if (player.social < 0)
        {
            player.social = 0;
        }
        if (player.energy < 0)
        {
            player.energy = 0;
        }



        Debug.Log("Alcool " + player.alcool);
        Debug.Log("Fun " + player.fun);
        Debug.Log("Social " + player.social);
        Debug.Log("Energy " + player.energy);

        bars.SetValueAllBars(player.alcool, player.fun, player.social, player.energy, player.money);
        if (player.alcool == 100 || player.energy == 0)
        {
            Debug.Log("DIE");
            scene.die();
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
