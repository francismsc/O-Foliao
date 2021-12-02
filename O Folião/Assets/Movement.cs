using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement
{
    public void Move(Player player)
    {
       
    }

    public bool Clicked()
    {
        if (Input.GetMouseButtonUp(0))
        {
            // Create a ray from the current mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // If the raycast hits any of the Tiles from the map
                if (hit.transform.tag == "Point") ;
                {
                    Debug.Log("Ya");
                    return false;
                }
            }

        }
        return true;
    }

}
