using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorInitializeTest : MonoBehaviour
{
    public Floor floor;
    public FloorManager floorManager;

    [ContextMenu("Initialise Floor")]
    public void InitialiseFloor()
    {
        //Find the floorManager Script

        //Pass data into floor manager script
        floorManager.floorRef = floor.name;
        floorManager.floorName = floor.floorName;
        floorManager.ceilingMat = floor.ceilingMat;
        floorManager.wallMat = floor.wallMat;
        floorManager.floorMat = floor.floorMat;
        //for (int i = 0; i < floor.assetSpawns.Length; i++)
        //{
        //    if (floor.assetSpawns[i] == -1)
        //    {
        //        floor.assetSpawns[i] = Random.Range(0, floor.assetSpawns.Length);
        //    }
        //}
        floorManager.skirtingObject = floor.skirting;
        floorManager.overheadsObject = floor.overheads;
        floorManager.subsceneAssets = floor.subsceneAssets;
        floorManager.rooms = floor.rooms;
        floorManager.doorsObject = floor.doors;

        //Initialise floor
        floorManager.Setup();
    }
}
