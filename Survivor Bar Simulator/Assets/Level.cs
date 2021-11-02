using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform floor;
    public Transform Wall;
    Grid grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = FindObjectOfType<Grid>();
        CreateDefaultLevel();
    }

    void CreateDefaultLevel()
    {
        
    }
}
