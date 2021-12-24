using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildThings : MonoBehaviour
{
    public Transform[] objs;
    public LayerMask gridMask;
    private int objectSelection;
    GridIso grid;

    private void Start()
    {
        grid = GetComponent<GridIso>();
    }

    public void SelectObject(int value)
    {
        objectSelection = value;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            grid.ShowGizmos();
        }

        if (grid.displayTileGizmos)
        {
            if (Input.GetMouseButtonDown(0))
            {

                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 20;
                Vector3 worldPosInGrid = Vector3.zero;// = Camera.main.ScreenToWorldPoint(mousePos);
                Ray ray;
                RaycastHit hitInfo;

                ray = Camera.main.ScreenPointToRay(mousePos);

                bool isHit = Physics.Raycast(ray, out hitInfo, 1000, gridMask);
                if (isHit)
                {
                    worldPosInGrid = hitInfo.point;
                    //print("hitInfo " + hitInfo.transform.position);
                    Node gridNode = grid.GetNodeFromWorldPoint(worldPosInGrid);
                    if (!gridNode.canBuild)
                    {
                        gridNode.canBuild = true;
                        gridNode.Stats();
                        Vector3 objPos = new Vector3(gridNode.nodePos.x, gridNode.nodePos.y + 0.3f, gridNode.nodePos.z);
                        Transform newObj = Instantiate(objs[objectSelection], objPos, Quaternion.identity);
                    }
                }
                
            }
        }
    }
}
