using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement: MonoBehaviour
{
    public Player player;
    bool timetomove = true;
    private List<GameObject> list;
    public Material mate;
    bool moving = false;
    GameObject child;
    bool choice = false;
    public void Move(Player player,GameObject nextpoint)
    {
        
        player.ChangePosition(nextpoint);
        
    }

    public bool Movingtime()
    {
        return timetomove;
    }

    public void TimetoMove()
    {
        timetomove = true;
    }
    public void Update()
    {
        if (timetomove)
        {
            list = player.Position().GetComponent<Node>().GetOptions();
            foreach (GameObject nodes in list)
            {
                nodes.GetComponent<Node>().HighLight();
            }
            if (Input.GetMouseButtonUp(0))
            {

                // Create a ray from the current mouse position
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {

                    if (hit.transform.tag == "Point")
                    {
                        foreach (GameObject nodes in list)
                        {
                            if (GameObject.ReferenceEquals(hit.transform.GetChild(0).gameObject, nodes))
                            {
                                foreach (GameObject points in list)
                                {
                                    points.GetComponent<Node>().BacktoNormal();
                                }
                                child = hit.transform.GetChild(0).gameObject;
                                Move(player, child);
                                moving = true;
                                choice = true;

                            }
                        }

                    }
                }
            }

            if (moving == true && player.gameObject.transform.position != child.transform.position)
            {
                player.gameObject.transform.position = Vector3.MoveTowards(player.gameObject.transform.position, child.transform.position, 5 * Time.deltaTime);
            }
            else if (player.gameObject.transform.position == null || (player.gameObject.transform.position == child.transform.position && choice == false))
            {
                moving = false;
            }
            else if (player.gameObject.transform.position == child.transform.position && choice == true)
            {
                choice = false;
                moving = false;
                timetomove = false;
            }





        }
    }



}
