using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static Vector3 playerPos;
    public static int loadNumber = 0;

    private void Update()
    {
        playerPos = transform.position;
    }
}
