using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AutoSignLoader : MonoBehaviour
{
    /// <summary>
    /// This holds reference to the room name field on the sign
    /// </summary>
    public TMP_Text roomName;
    /// <summary>
    /// This holds reference to the room description field on the sign
    /// </summary>
    public TMP_Text roomDescription;

    [HideInInspector]
    public Room room;

    public void LoadSign()
    {
        if (room != null)
        {
            roomName.text = room.displayName;
            roomDescription.text = room.roomDescription;
        }
        else
        {
            roomName.text = "Error: 404";
            roomDescription.text = "Room not found!";
        }
    }
}
