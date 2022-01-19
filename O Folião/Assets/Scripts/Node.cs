using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public enum Type {Stages, Bars, Hotels};

    [SerializeField]
    private Type type;
    [SerializeField]
    private Material normal;
    [SerializeField]
    private Material highLight;
    public Node node;


    [SerializeField]
    List<GameObject> options;

    public List<GameObject> GetOptions()
    {
       return this.options;
    }
        
    public void HighLight()
    {
        gameObject.GetComponentInParent<Renderer>().material = highLight;
    }

    public void BacktoNormal()
    {
        gameObject.GetComponentInParent<Renderer>().material = normal;
    }

    public Node GetNode(Player player)
    {
        return player.Position().GetComponent<Node>();
    }


    public Type NodeType(Player player)
    {
        node = GetNode(player);
        return node.type;
    }




    



}
