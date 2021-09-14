using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Room", menuName = "Scriptable Objects/Room", order = 1)]
public class Room : ScriptableObject
{
    ///<summary>This is the file name of the room's scene</summary>
    public string sceneName;
    ///<summary>This is the displayed name of the room</summary>
    public string displayName;
    ///<summary>This is the description for the room</summary>
    public string roomDescription;

    ///<summary>This is a categorisation tag</summary>
    public string tag;

    //public Cubemap roomPreview;
    ///<summary>This is ambient sound for each room</summary>
    public AudioClip ambience;

    ///<summary>This is the placement of the room on each floor</summary>
    //public Direction doorPlacement;
}
