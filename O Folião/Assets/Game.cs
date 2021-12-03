using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Player player;
    public Movement move;

    bool gameon = true;
    bool moveTurn = true;
    bool timetomove = true;
    GameObject objecto;
    private Node node;
    private List<GameObject> list;
    public Material mate;

    void Awake()
    {

    }

    private void Update()
    {
        if(timetomove)
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

                    if (hit.transform.tag == "Point");
                    {
                        foreach(GameObject nodes in list)
                        {
                            if (GameObject.ReferenceEquals(hit.transform.GetChild(0).gameObject, nodes))
                            {
                                foreach (GameObject points in list)
                                {
                                    points.GetComponent<Node>().BacktoNormal();
                                }

                                move.Move(player, hit.transform.GetChild(0).gameObject);

                            }
                        }

                    }
                }
            }
            

        }
    }
    private void Start()
    {

    }
}
