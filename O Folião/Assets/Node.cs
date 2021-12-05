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
    List<GameObject> Options;



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

    public Node GetNode(Player player)
    {
        return player.Position().GetComponent<Node>();
    }


    public void Event(Player player)
    {
        node = GetNode(player);
        if(node.type == Type.Normal)
        {
            

        }
        else if(node.type == Type.Store)
        {

        }
        else if(node.type == Type.Bar)
        {

        }
        else if(node.type == Type.Extra)
        {

        }
    }




    



}
