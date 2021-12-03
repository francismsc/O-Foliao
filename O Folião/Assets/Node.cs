using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField]
    private Material normal;
    [SerializeField]
    private Material highLight;


    [SerializeField]
    List<GameObject> Options;



    private INodeBehaviour nodeEvent;

    private void Awake()
    {
        nodeEvent = GetComponent<INodeBehaviour>();
    }

    public List<GameObject> GetOptions()
    {
       return this.Options;
    }
        


    public void HighLight()
    {
        gameObject.GetComponentInParent<Renderer>().material = highLight;
    }

    public void BacktoNormal()
    {
        gameObject.GetComponentInParent<Renderer>().material = normal;
    }


    



}
