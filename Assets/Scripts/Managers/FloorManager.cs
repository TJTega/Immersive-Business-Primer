using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class FloorMeshRenderers
{
    ///<summary>This is the renderer for the ceiling of each floor</summary>
    public MeshRenderer ceilingRenderer;
    ///<summary>This is the renderer for the walls of each floor</summary>
    public MeshRenderer[] wallRenderers;
    ///<summary>This is the renderer for the floor of each floor</summary>
    public MeshRenderer floorRenderer;
}

public class FloorManager : MonoBehaviour
{
    [Header("Room Loading")]
    ///<summary>Data for loading rooms in the floor</summary>
    public ScenePartLoader[] portals = new ScenePartLoader[3];
    ///<summary>Data for loading room signs in the floor</summary>
    public AutoSignLoader[] signs = new AutoSignLoader[3];

    [HideInInspector]
    public static Floor currentFloor;
    [HideInInspector]
    public string floorName = "";
    [HideInInspector]
    public Material ceilingMat;
    [HideInInspector]
    public Material wallMat;
    [HideInInspector]
    public Material floorMat;
    [HideInInspector]
    public GameObject skirtingObject;
    [HideInInspector]
    public GameObject overheadsObject;
    [HideInInspector]
    public GameObject subsceneAssets;
    [HideInInspector]
    public Rooms rooms;
    [HideInInspector]
    public GameObject doorsObject;
    
    [Header("Floor Loading")]
    ///<summary>This struct holds the data for all relevant floor mesh renderers</summary>
    public FloorMeshRenderers renderers;

    public AudioSource ambientSource;
    /// <summary>This holds the transform for the center of the room</summary>
    public Transform centerAnchor;

    public Vector3 offset;

    //These hold information for currently spawned assets in the scene
    private GameObject skirting;
    private GameObject overhead;
    private GameObject subscene;
    private GameObject doors;

    // Start is called before the first frame update
    public void Setup()
    {
        if (currentFloor.ambience != null)
        {
            ambientSource.clip = currentFloor.ambience;
            ambientSource.Play();
        }

        //Sets ceiling material
        renderers.ceilingRenderer.material = ceilingMat;
        //Sets material for each wall
        foreach (var renderer in renderers.wallRenderers)
        {
            renderer.material = wallMat;
        }
        //Sets floor material
        renderers.floorRenderer.material = floorMat;

        //Overwrites skirting object, deletes if not set
        if (skirtingObject != null)
        {
            Destroy(skirting);
            skirting = Instantiate(skirtingObject, centerAnchor, false);
        }
        else
        {
            Destroy(skirting);
        }

        //Overwrites overhead object, deletes if not set
        if (overheadsObject != null)
        {
            Destroy(overhead);
            overhead = Instantiate(overheadsObject, centerAnchor, false);
        }
        else
        {
            Destroy(overhead);
        }

        //Overwrites subscene object, deletes if not set
        if (subsceneAssets != null)
        {
            Destroy(subscene);
            subscene = Instantiate(subsceneAssets, centerAnchor, false);
        }
        else
        {
            Destroy(subscene);
        }
        if (doorsObject != null)
        {
            Destroy(doors);
            doors = Instantiate(doorsObject, centerAnchor, false);
        }
        else
        {
            Destroy(doors);
        }

        //holds unimplemented code for loading room scenes and signs on floor
        SceneSetup();
        
    }

    private void SceneSetup()
    {
        //RoomEnterLoader[] roomEnters = new RoomEnterLoader[3];
        //GameObject roomEnterLObject = GameObject.FindGameObjectWithTag("RoomEnterL");
        //GameObject roomEnterBObject = GameObject.FindGameObjectWithTag("RoomEnterB");
        //GameObject roomEnterRObject = GameObject.FindGameObjectWithTag("RoomEnterR");
        //roomEnters[0] = roomEnterLObject.GetComponent<RoomEnterLoader>();
        //roomEnters[1] = roomEnterBObject.GetComponent<RoomEnterLoader>();
        //roomEnters[2] = roomEnterRObject.GetComponent<RoomEnterLoader>();
        //Debug.Log($"{roomEnterLObject.name}");

        //if (floorRef != "")
        //{
        //    foreach (var room in roomEnters)
        //    {
        //        room.floorRef = floorRef;
        //    }

        //}
        //else
        //{
        //    floorRef = roomEnters[0].floorRef;
        //}

        //Updates signs to match rooms
        signs[0].room = rooms.leftRoom;
        signs[1].room = rooms.backRoom;
        signs[2].room = rooms.rightRoom;
        
        //Loads each sign
        signs[0].LoadSign();
        signs[1].LoadSign();
        signs[2].LoadSign();


        foreach (var portal in portals)
        {
            portal.forwardManager.ScenesToLoad.Clear();
            portal.backwardManager.ScenesToUnload.Clear();
            portal.setOffset = offset;
        }
        if (rooms.leftRoom != null)
        {
            //Adds default enter scene
            portals[0].forwardManager.ScenesToLoad.Add("RoomEnterLeft");
            portals[0].backwardManager.ScenesToUnload.Add("RoomEnterLeft");

            //Adds scene based on floor scriptable object
            portals[0].forwardManager.ScenesToLoad.Add(rooms.leftRoom.sceneName);
            portals[0].backwardManager.ScenesToUnload.Add(rooms.leftRoom.sceneName);
        }
        if (rooms.backRoom != null)
        {
            //Adds default enter scene
            portals[1].forwardManager.ScenesToLoad.Add("RoomEnterBack");
            portals[1].backwardManager.ScenesToUnload.Add("RoomEnterBack");

            //Adds scene based on floor scriptable object
            portals[1].forwardManager.ScenesToLoad.Add(rooms.backRoom.sceneName);
            portals[1].backwardManager.ScenesToUnload.Add(rooms.backRoom.sceneName);
        }
        if (rooms.rightRoom != null)
        {
            //Adds default enter scene
            portals[2].forwardManager.ScenesToLoad.Add("RoomEnterRight");
            portals[2].backwardManager.ScenesToUnload.Add("RoomEnterRight");

            //Adds scene based on floor scriptable object
            portals[2].forwardManager.ScenesToLoad.Add(rooms.rightRoom.sceneName);
            portals[2].backwardManager.ScenesToUnload.Add(rooms.rightRoom.sceneName);
        }
    }
}