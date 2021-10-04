using Microsoft.SpatialAudio.Spatializer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

[Serializable]
public class Rooms
{
    ///<summary>This is the structure for the room on the left</summary>
    public Room leftRoom;
    ///<summary>This is the structure for the room on the back</summary>
    public Room backRoom;
    ///<summary>This is the structure for the room on the right</summary>
    public Room rightRoom;
}

[CreateAssetMenu(fileName = "Floor", menuName = "Scriptable Objects/Floor", order = 1)]
public class Floor : ScriptableObject
{
    ///<summary>This is the displayed name of each floor</summary>
    public string floorName;
    ///<summary>This is a categorisation tag</summary>
    public string tag;

    ///<summary>General material for the ceiling of each floor</summary>
    public Material ceilingMat;
    ///<summary>General material for the walls of each floor</summary>
    public Material wallMat;
    ///<summary>General material for the floor of each floor</summary>
    public Material floorMat;
    ///<summary>This holds an asset for that would be displayed as skirting</summary>
    public GameObject skirting;
    ///<summary>This holds an asset for that would be displayed as overheads</summary>
    public GameObject overheads;
    ///<summary>This holds the volume settings for each floor</sumskimary>
    public VolumeProfile volumeProfile;

    ///<summary>This is a scriptable object holding general assets for floors</summary>
    public SubsceneAssets assets;
    ///<summary>This is an array holding the indexes of objects pointing at which locations to spawn at</summary>
    public int[] assetSpawns;

    ///<summary>Class containing left, back and right rooms</summary>
    public Rooms rooms;
}
