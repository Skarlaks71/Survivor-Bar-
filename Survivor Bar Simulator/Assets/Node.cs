using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{
    //public BoxCollider nodeCol;
    public LayerMask nodeLayer;
    public Vector3 nodePos;
    public Vector2 nodeCoord;
    public bool canBuild;

    public Node(Vector3 _nodePos,Vector2 _coord,bool _canBuild, LayerMask _nodeLayer)
    {
        nodePos = _nodePos;
        nodeCoord = _coord;
        canBuild = _canBuild;
        nodeLayer = _nodeLayer;
        
    }

    /// <summary> Show all data about this node </summary> 
    public void Stats()
    {
        Debug.Log("Coord: " + "[ "+nodeCoord.x+" : "+nodeCoord.y+" ]" + "\n"
            + "WorldPos: " + nodePos + "\n"
            + "CanBuild: " + canBuild + "\n"
            + "Layer: " + nodeLayer.value);
        
    }
}
