using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    Player player = new Player();
    Movement move = new Movement();
    bool on = true;
    bool moveTurn = true;
    // Start is called before the first frame update
    void Awake()
    {

    }

    private void Update()
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

                }
            }
        }
    }
    private void Start()
    {

    }
}
