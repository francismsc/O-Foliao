using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField]
    private GameObject option1;

    [SerializeField]
    public GameObject option2;

    [SerializeField]
    public GameObject option3;

    [SerializeField]
    public GameObject option4;

    public string type { get; set; }

    public Node()
    {
        //normalNode = new NormalEvent();
    }


}
