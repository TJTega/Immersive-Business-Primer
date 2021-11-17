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
    //Data for loading room signs and scenes in floor
    public ScenePartLoader[] portals = new ScenePartLoader[3];
    //public AutoSignLoader[] signs = new AutoSignLoader[3];

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
    

    ///<summary>This struct holds the data for all relevant floor mesh renderers</summary>
    public FloorMeshRenderers renderers;
    /// <summary>This holds the transform for the center of the room</summary>
    public Transform centerAnchor;

    //These hold information for currently spawned assets in the scene
    private GameObject skirting;
    private GameObject overhead;
    private GameObject subscene;
    private GameObject doors;

    // Start is called before the first frame update
    public void Setup()
    {
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

        //Holds unimplemented code for loading room scenes and signs on floor
        //SceneSetup();

        //foreach (var signLoader in signs)
        //{
        //    signLoader.worlds = worlds;
        //    signLoader.LoadSign();
        //}
    }

    public void SceneSetup()
    {
        foreach (var portal in portals)
        {
            portal.forwardManager.ScenesToLoad.Clear();
            portal.backwardManager.ScenesToUnload.Clear();
        }
        portals[0].forwardManager.ScenesToLoad.Add(rooms.leftRoom.sceneName);
        portals[1].forwardManager.ScenesToLoad.Add(rooms.backRoom.sceneName);
        portals[2].forwardManager.ScenesToLoad.Add(rooms.rightRoom.sceneName);
        portals[0].backwardManager.ScenesToUnload.Add(rooms.leftRoom.sceneName);
        portals[1].backwardManager.ScenesToUnload.Add(rooms.backRoom.sceneName);
        portals[2].backwardManager.ScenesToUnload.Add(rooms.rightRoom.sceneName);
    }
}