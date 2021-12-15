using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RoomDoors : MonoBehaviour
{
    public DOTweenAnimation door;
    // Start is called before the first frame update
     void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
            {
            door.DOPlayForward();
        }
    }
     void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            door.DOPlayBackwards();
        }
    }
}
