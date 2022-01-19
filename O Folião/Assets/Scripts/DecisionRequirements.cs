using UnityEngine;

public class DecisionRequirements : MonoBehaviour
{

    public bool CheckForDecisionSucess(Player player, Decisions decision)
    {
        if (CheckAllResources(player, decision) == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckAllResources(Player player, Decisions decision)
    {
        if (CheckMinResource(decision.minAlcool, player.GetAlcool()) == false)
        {
            Debug.Log("No Alcool");
            return false;
        }

        if (CheckMinResource(decision.minFun, player.GetFun()) == false)
        {
            Debug.Log("No Fun");
            return false;
        }

        if (CheckMinResource(decision.minSocial, player.GetSocial()) == false)
        {
            Debug.Log("No Social");
            return false;
        }

        if (CheckMinResource(decision.minEnergy, player.GetEnergy()) == false)
        {
            Debug.Log("No Energy");
            return false;
        }

        if (CheckMinResource(decision.minMoney, player.GetMoney()) == false)
        {
            Debug.Log("No Money");
            return false;
        }

        return true;
    }
    private bool CheckMinResource(int minNeeded, int resource)
    {
        if (minNeeded > resource)
        {
            return false;
        }
        else
        {
            return true;
        }

    }
}
