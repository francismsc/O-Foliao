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
    bool stillmoving = false;
    public void Move(Player player,GameObject nextpoint)
    {
        
        player.ChangePosition(nextpoint);
        
    }

    public bool isMoving()
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
            if (Input.GetMouseButtonUp(0) && stillmoving == false)
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
                player.gameObject.transform.position = Vector3.MoveTowards(player.gameObject.transform.position, child.transform.position, 300 * Time.deltaTime);
                stillmoving = true;

            }
            else if (child == null || (player.gameObject.transform.position == child.transform.position && choice == false))
            {
                moving = false;
            }
            else if (player.gameObject.transform.position == child.transform.position && choice == true)
            {
                choice = false;
                moving = false;
                timetomove = false;
                stillmoving = false;
            }
            





        }
    }

    IEnumerator StillMoving(Player player,GameObject child)
    {
        yield return new WaitWhile(() => player.gameObject.transform.position != child.transform.position);
    }



}
