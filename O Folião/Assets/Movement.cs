using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement: MonoBehaviour
{

    public void Move(Player player,GameObject nextpoint)
    {
        player.ChangePosition(nextpoint);   
    }

    

}
