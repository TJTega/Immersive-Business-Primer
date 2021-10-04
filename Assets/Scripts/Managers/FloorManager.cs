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
    public SubsceneAssets assets;
    [HideInInspector]
    public Rooms rooms;
    [HideInInspector]
    public int[] assetSpawns;

    public FloorMeshRenderers renderers;
    public Transform centerAnchor;
    public GameObject[] spawnPoints = new GameObject[4];

    private GameObject root;
    private GameObject skirting;
    private GameObject overhead;

    // Start is called before the first frame update
    public void Setup()
    {
        if (root != null)
        {
            Destroy(root);
        }

        //Sets wall, floor and ceiling materials
        renderers.ceilingRenderer.material = ceilingMat;
        foreach (var renderer in renderers.wallRenderers)
        {
            renderer.material = wallMat;
        }
        renderers.floorRenderer.material = floorMat;
        if (skirtingObject != null)
        {
            skirting = Instantiate(skirtingObject, centerAnchor, false);
        }
        else
        {
            DestroyImmediate(skirting);
        }
        if (overheadsObject != null)
        {
            overhead = Instantiate(overheadsObject, centerAnchor, false);
        }
        else
        {
            DestroyImmediate(overhead);
        }

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
        //root = new GameObject("Element Root");
        //for (int i = 0; i < spawnPoints.Length; i++)
        //{
        //    GameObject clone = Instantiate(assets.elements[assetSpawns[i]], spawnPoints[i].transform, false);
        //    clone.transform.parent = root.transform;
        //}
    }
}