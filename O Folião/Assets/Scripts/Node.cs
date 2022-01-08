using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public enum Type { Normal, Store, Bar, Extra };

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


    public string NodeType(Player player)
    {
        node = GetNode(player);
        Debug.Log("ya");
        return node.type.ToString();
    }




    



}
