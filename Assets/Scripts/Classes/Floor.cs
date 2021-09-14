using Microsoft.SpatialAudio.Spatializer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class Rooms
{
    public Room leftRoom;
    public Room backRoom;
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

    ///<summary>This is a scriptable object holding general assets for floors</summary>
    public SubsceneAssets assets;
    ///<summary>This is an array holding the indexes of objects pointing at which locations to spawn at</summary>
    public int[] assetSpawnPoints;

    public Rooms rooms;
}
