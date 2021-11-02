using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildThings : MonoBehaviour
{
    public Transform obj;
    GridIso grid;

    private void Start()
    {
        grid = GetComponent<GridIso>();
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
                Vector3 mousePos = grid.GetNodeFromWorldPoint(grid.CalculateMousePositionInGrid()).nodePos;
                Vector3 objPos = new Vector3(mousePos.x, obj.localScale.y / 2, mousePos.z);
                Transform newObj = Instantiate(obj, objPos, Quaternion.identity);
            }
        }
    }
}
