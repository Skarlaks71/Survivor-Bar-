using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{
    //public BoxCollider nodeCol;
    public LayerMask nodeLayer;
    public Vector3 nodePos;
    public bool canBuild;

    public Node(Vector3 _nodePos,bool _canBuild, LayerMask _nodeLayer)
    {
        nodePos = _nodePos;
        canBuild = _canBuild;
        nodeLayer = _nodeLayer;
        
    }
}
