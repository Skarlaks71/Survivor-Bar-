using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridIso : MonoBehaviour
{
    public bool displayTileGizmos;

    [Header("Grid World")]
    public Vector2 worldSizeGrid;
    public Vector2 sizeCell;
    public LayerMask walkable;
    public LayerMask gridMask;
    public float distanceRay;

    [Header("Grid Floor")]
    public Transform floor;
    public Vector2 worldSizeGridFloor;
    public Vector2 sizeCellFloor;
    private Vector2 realGridFloorSize;

    Node[,] grid;
    Node[,] gridFloor;
    List<Vector3> gridPosList = new List<Vector3>();

    Plane plane;

    private void Awake()
    {
        plane = new Plane(Vector3.up, 100);
        grid = new Node[(int)worldSizeGrid.x, (int)worldSizeGrid.y];
        gridFloor = new Node[(int)worldSizeGridFloor.x, (int)worldSizeGridFloor.y];
        realGridFloorSize = worldSizeGridFloor * sizeCellFloor;
        CreateGrid();
        //CreateFloor();
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
                Vector3 worldPoint = new Vector3(posX, .3f, posZ);
                
                grid[x, y] = new Node(worldPoint,new Vector2(x,y),false,walkable);
                
                gridPosList.Add(grid[x,y].nodePos);
                
            }
        }

        
    }

    void CreateFloor()
    {
        for (int x = 0; x < worldSizeGridFloor.x; x++)
        {
            for (int y = 0; y < worldSizeGridFloor.y; y++)
            {

                //center grid formula (T - 2*CS/2)/2 , where T is the real size of grid and CS is the size of cell
                float posX = x * sizeCell.x - (realGridFloorSize.x - 2 * (sizeCellFloor.x / 2)) / 2;
                float posZ = y * sizeCell.y - (realGridFloorSize.y - 2 * (sizeCellFloor.y / 2)) / 2;
                Vector3 worldPoint = new Vector3(posX, 0.3f, posZ);

                //gridFloor[x, y] = new Node(worldPoint, false, walkable);

                //gridPosList.Add(grid[x, y].nodePos);

            }
        }

        SpawnTiles();
    }

    private void SpawnTiles()
    {
        foreach (Node tileG in gridFloor)
        {
            //print(tileG.worldPos);
            GameObject tileClone = (GameObject)Instantiate(floor.gameObject, tileG.nodePos, Quaternion.identity);
            tileClone.transform.parent = this.gameObject.transform;
        }
    }

    public Vector3 CalculateMousePositionInGrid()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = distanceRay;
        Vector3 worldPosInGrid = Vector3.zero;// = Camera.main.ScreenToWorldPoint(mousePos);
        Ray ray;
        RaycastHit hitInfo;

        ray = Camera.main.ScreenPointToRay(mousePos);

        bool isHit = Physics.Raycast(ray, out hitInfo, 1000, gridMask);
        if (isHit)
        {
            worldPosInGrid = hitInfo.transform.position;
            print("hitInfo " + hitInfo.transform.position);
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

        if (grid != null)
        {

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = distanceRay;
            Vector3 worldPosition = new Vector3();// = Camera.main.ScreenToWorldPoint(mousePos);
            Ray ray;
            RaycastHit hitInfo;

            ray = Camera.main.ScreenPointToRay(mousePos);

            bool isHit = Physics.Raycast(ray, out hitInfo, 1000, gridMask);
            if (isHit)
            {
                worldPosition = hitInfo.point;
                //print("hitInfo " + hitInfo.transform.position);
            }


            if (displayTileGizmos)
            {
                foreach (Node n in grid)
                {
                    Gizmos.color = Color.gray;

                    if (isHit)
                    {
                        if (GetNodeFromWorldPoint(worldPosition) == n)
                        {
                            
                            Gizmos.color = (n.canBuild) ? Color.red : Color.blue;
                            Gizmos.DrawWireCube(n.nodePos, new Vector3(sizeCell.x, 0.1f, sizeCell.y));
                        }

                    }

                    Gizmos.DrawWireCube(n.nodePos, new Vector3(sizeCell.x, 0.01f, sizeCell.y));
                }
            }
            

        }   
    }
}
