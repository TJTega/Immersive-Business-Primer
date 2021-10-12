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
    //public AutoSceneLoader[] sceneLoaders = new AutoSceneLoader[3];
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

    ///<summary>This struct holds the data for all relevant floor mesh renderers</summary>
    public FloorMeshRenderers renderers;
    /// <summary>This holds the transform for the center of the room</summary>
    public Transform centerAnchor;

    //These hold information for currently spawned assets in the scene
    private GameObject skirting;
    private GameObject overhead;
    private GameObject subscene;

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
            DestroyImmediate(skirting);
            skirting = Instantiate(skirtingObject, centerAnchor, false);
        }
        else
        {
            DestroyImmediate(skirting);
        }

        //Overwrites overhead object, deletes if not set
        if (overheadsObject != null)
        {
            DestroyImmediate(overhead);
            overhead = Instantiate(overheadsObject, centerAnchor, false);
        }
        else
        {
            DestroyImmediate(overhead);
        }

        //Overwrites subscene object, deletes if not set
        if (subsceneAssets != null)
        {
            DestroyImmediate(subscene);
            subscene = Instantiate(subsceneAssets, centerAnchor, false);
        }
        else
        {
            DestroyImmediate(subscene);
        }

        //Holds unimplemented code for loading room scenes and signs on floor
        //foreach (var sceneLoader in sceneLoaders)
        //{
        //    sceneLoader.worlds = worlds;
        //    sceneLoader.Setup();
        //}
        //foreach (var signLoader in signs)
        //{
        //    signLoader.worlds = worlds;
        //    signLoader.LoadSign();
        //}
    }
}