using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int maxAlcool = 100;
    [SerializeField]
    private int maxFun = 100;
    [SerializeField]
    private int maxSocial = 100;
    [SerializeField]
    private int maxEnergy = 100;

    [SerializeField]
    private int alcool = 0;
    [SerializeField]
    private int fun = 50;
    [SerializeField]
    private int social = 50;
    [SerializeField]
    private int energy = 100;

    [SerializeField]
    private int money;
    [SerializeField]
    private GameObject position;
    [SerializeField]
    private SceneChanger scene;
    [SerializeField]
    private BarsUI bars;


    private void Start()
    {
        bars.SetMaxAllBars(maxAlcool, maxFun, maxSocial, maxEnergy,  money);
    }

    public int GetAllStats()
    {
        return this.alcool;
    }


    public void ChangeStats(Player player, int alcool = 0, int fun = 0, 
                            int social = 0, int money = 0, int energy = 0)
    {
        player.alcool += alcool;
        player.fun += fun;
        player.social += social;
        player.money += money;
        player.energy += energy;

        if(player.alcool > maxAlcool)
        {
            player.alcool = maxAlcool;
        }
        if (player.fun > maxFun)
        {
            player.fun = maxFun;
        }
        if(player.social > maxSocial)
        { 
            player.social = maxSocial;
        }
        if(player.energy > maxEnergy)
        {
            player.energy = maxEnergy;
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

        bars.SetValueAllBars(player.alcool, player.fun, player.social, 
                             player.energy, player.money);
        if (player.alcool == 100 || player.energy == 0)
        {
            scene.Death();
        }

    }

    public void ChangePosition(GameObject position)
    {
        this.position = position;
    }

    public int GetAlcool()
    {
        return this.alcool;
    }

    public int GetEnergy()
    {
        return this.energy;
    }
    public int GetFun()
    {
        return this.fun;
    }

    public int GetSocial()
    {
        return this.social;
    }

    public int GetMoney()
    {
        return this.money;
    }

    public GameObject Position()
    {
        return this.position;
    }

    


    






}
