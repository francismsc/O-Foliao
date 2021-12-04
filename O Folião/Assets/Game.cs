using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Player player;
    public Movement move;
    private Node node;

    public List<Decisions> decisions;
    public List<Events> events;

    void Awake()
    {
        
    }

    private void Update()
    {
        if (move.Movingtime() == true)
        {
            GetComponent<Movement>().enabled = true;
        }
        if(move.Movingtime() == false)
        {
            node.Event(player);
        }
        if (Input.GetMouseButtonUp(1))
        {
            move.TimetoMove();
        }
    }
    private void Start()
    {

    }
}
