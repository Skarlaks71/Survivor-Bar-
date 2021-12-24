using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Level : MonoBehaviour
{
    public Transform floor;
    public Transform[] Walls;
    private bool disableWalls = true;
    private bool disableWallsFront = true;

    private WallController wallController;

    private void Awake()
    {
        wallController = new WallController();
    }

    private void OnEnable()
    {
        wallController.WallMaps.DisableWalls.performed += DisableWalls;
        wallController.WallMaps.DisableWalls.Enable();

        wallController.WallMaps.DisableWallsFront.performed += DisableFrontWalls;
        wallController.WallMaps.DisableWallsFront.Enable();
    }

    private void DisableWalls(InputAction.CallbackContext ctx)
    {
        disableWalls = !disableWalls;
        if (disableWalls)
            disableWallsFront = true;
        else
            disableWallsFront = false;
        foreach(Transform wall in Walls)
        {
            if(!disableWalls)
                wall.gameObject.SetActive(false);
            else
                wall.gameObject.SetActive(true);
        }
    }

    private void DisableFrontWalls(InputAction.CallbackContext ctx)
    {   

        disableWallsFront = !disableWallsFront;
        if (!disableWallsFront)
        {
            Walls[0].gameObject.SetActive(false);
            Walls[3].gameObject.SetActive(false);
        }
        else
        {
            Walls[0].gameObject.SetActive(true);
            Walls[3].gameObject.SetActive(true);
        }
    }

    private void OnDisable()
    {
        wallController.WallMaps.DisableWalls.Disable();
    }
}
