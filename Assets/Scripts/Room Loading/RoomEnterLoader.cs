using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnterLoader : ScenePartLoader
{
    public string floorRef;
    Floor floor;

    private void Awake()
    {
        //floor = Resources.Load($"Floors/{floorRef}") as Floor;
        //Debug.Log(floor.name);
    }
    protected override void UnLoadScene()
    {
        base.UnLoadScene();
        if(base.dotProduct < 0)
        {

        }
    }
}
