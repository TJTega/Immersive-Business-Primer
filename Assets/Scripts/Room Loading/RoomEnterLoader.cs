using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnterLoader : ScenePartLoader
{
    Floor floor;

    private void Awake()
    {
        floor = FloorManager.currentFloor;
        //Debug.Log(floor.name);
    }

    protected override void LoadScene()
    {
        base.LoadScene();
        if (base.dotProduct > 0)
        {
            //Debug.Log("Going Back");

            GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
            GameManager manager = gameManagerObject.GetComponent<GameManager>();

            StartCoroutine(manager.LoadFloor(floor));
        }
    }
}
