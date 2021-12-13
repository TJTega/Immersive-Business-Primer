
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
    [Header("Meta")]
    ///<summary>This is the displayed name of each floor</summary>
    public string floorName;
    ///<summary>This is a categorisation tag</summary>
    public string tag;

    [Header("Materials")]
    ///<summary>General material for the ceiling of each floor</summary>
    public Material ceilingMat;
    ///<summary>General material for the walls of each floor</summary>
    public Material wallMat;
    ///<summary>General material for the floor of each floor</summary>
    public Material floorMat;

    [Header("Meshes")]
    ///<summary>This holds an asset for that would be displayed as skirting</summary>
    public GameObject skirting;
    ///<summary>This holds an asset for that would be displayed as overheads</summary>
    public GameObject overheads;
    ///<summary>This holds the volume settings for each floor</sumskimary>
    public VolumeProfile volumeProfile;

    ///<summary>This is a gameObject holding general assets for floors</summary>
    public GameObject subsceneAssets;
    /// <summary>This holds the prefab for the floor doors</summary>
    public GameObject doors;

    ///<summary>This is ambient sound for the floor</summary>
    public AudioClip ambience;

    [Header("Rooms")]
    ///<summary>Class containing left, back and right rooms</summary>
    public Rooms rooms;
}
