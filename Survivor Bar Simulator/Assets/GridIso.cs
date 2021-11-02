using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridIso : MonoBehaviour
{
    public bool displayTileGizmos;
    public Vector2 worldSizeGrid;
    public Vector2 sizeCell;
    public LayerMask walkable;
    public GameObject floor;

    Node[,] grid;
    List<Vector3> gridPosList = new List<Vector3>();

    Plane plane;

    private void Awake()
    {
        plane = new Plane(Vector3.up, 100);
        grid = new Node[(int)worldSizeGrid.x, (int)worldSizeGrid.y];
        CreateGrid();
    }

    
    private void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            
            print("Mouse Pos in grid is: " + CalculateMousePositionInGrid());
        }

        /*
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ShowGizmos();
        }
        */
    }
    
    public void ShowGizmos()
    {
        displayTileGizmos = !displayTileGizmos;
    }

    void CreateGrid()
    {
        gridPosList.Clear();
        Vector2 realGridSize = worldSizeGrid * sizeCell;

        for (int x = 0; x<worldSizeGrid.x; x++)
        {
            for (int y = 0; y<worldSizeGrid.y; y++)
            {

                //center grid formula (T - 2*CS/2)/2 , where T is the real size of grid and CS is the size of cell
                float posX = x * sizeCell.x - (realGridSize.x - 2 * (sizeCell.x / 2)) / 2;
                float posZ = y * sizeCell.y - (realGridSize.y - 2 * (sizeCell.y / 2)) / 2;
                Vector3 worldPoint = new Vector3(posX, 1, posZ);
                //BoxCollider nodeCollider = new BoxCollider();
                //nodeCollider.size = new Vector3(sizeCell.x, 0, sizeCell.y);
                grid[x, y] = new Node(worldPoint,false,walkable);
                
                gridPosList.Add(grid[x,y].nodePos);
                
            }
        }
    }

    public Vector3 CalculateMousePositionInGrid()
    {
        Vector3 worldPosInGrid = Vector3.zero;

        float distance = 50;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (grid != null)
        {
            if (Physics.Raycast(ray,out hit))
            {
                if (hit.transform.gameObject == floor.gameObject)
                {
                    worldPosInGrid = hit.point;
                    worldPosInGrid.x = Mathf.RoundToInt(worldPosInGrid.x);
                    worldPosInGrid.z = Mathf.RoundToInt(worldPosInGrid.z);
                }
            }
        }

        return worldPosInGrid;
    }

    public Node GetNodeFromWorldPoint(Vector3 worldPos)
    {
        float percentX = (worldPos.x + (worldSizeGrid.x * sizeCell.x) / 2) / (worldSizeGrid.x * sizeCell.x);
        float percentZ = (worldPos.z + (worldSizeGrid.y * sizeCell.y) / 2) / (worldSizeGrid.y * sizeCell.y);
        percentX = Mathf.Clamp01(percentX);
        percentZ = Mathf.Clamp01(percentZ);

        int x = Mathf.RoundToInt((worldSizeGrid.x - 1)*percentX);
        int y = Mathf.RoundToInt((worldSizeGrid.y - 1)*percentZ);
        return grid[x, y];
    }

    Vector3 ToIso(Vector3 point)
    {
        return new Vector3(point.x - point.z, 0, (point.x + point.z) / 2);
    }

    private void OnDrawGizmos()
    {
        if (gridPosList.Count > 0)
        {
            if (grid != null)
            {
                Node mousePos = GetNodeFromWorldPoint(CalculateMousePositionInGrid());
                foreach (Node node in grid)
                {
                    if (displayTileGizmos)
                    {
                        Gizmos.color = Color.black;
                        if (mousePos == node)
                        {
                            Gizmos.color = (node.canBuild)?Color.black:Color.red;
                            Gizmos.DrawCube(node.nodePos, new Vector3(sizeCell.x, 0, sizeCell.y));
                        }
                        Gizmos.DrawWireCube(node.nodePos, new Vector3(sizeCell.x, 0.1f, sizeCell.y));
                    }
                }
                Gizmos.color = Color.green;
                Gizmos.DrawWireCube(transform.position, new Vector3(plane.distance,0,plane.distance));
                
            }   

            
        }
    }
}
