using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Player player;
    public Movement move;

    void Awake()
    {
        
    }

    private void Update()
    {
        if (move.Movingtime() == true)
        {
            GetComponent<Movement>().enabled = true;
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
