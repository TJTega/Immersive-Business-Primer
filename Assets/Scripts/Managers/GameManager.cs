using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    public ElevatorButtons elevator;
    public ElevatorDoors doors;

    public List<Floor> floors;

    //public Elevator doors;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
        LoadButtons();
    }

    private void LoadButtons()
    {

        foreach (var floor in floors)
        {
            EButton button = new EButton();
            button.active = true;
            Floor temp = floor;
            button.OnButtonPress += (() => StartLoadFloor(temp));
            elevator.buttons.Add(button);
        }
        elevator.CreateButtons();
    }

    private void StartLoadFloor(Floor floor)
    {
        //doors.anim.SetBool("IsDoorOpen", false);
        //doors.OnDoorClose += (() => StartCoroutine(LoadFloor(floor)));
        StartCoroutine(LoadFloor(floor));
    }

    private IEnumerator LoadFloor(Floor floor)
    {
        yield return null;
        //if (!SceneManager.GetSceneByName("Floor").isLoaded)
        //{
        //    AsyncOperation async = SceneManager.LoadSceneAsync("Floor");
        //    while (!async.isDone)
        //    {
        //        yield return null;
        //    }
        //}
        GameObject floorManagerObject = GameObject.FindGameObjectWithTag("FloorManager");
        FloorManager floorManager = floorManagerObject.GetComponent<FloorManager>();
        floorManager.floorName = floor.floorName;
        floorManager.ceilingMat = floor.ceilingMat;
        floorManager.wallMat = floor.wallMat;
        floorManager.floorMat = floor.floorMat;
        //for (int i = 0; i < floor.assetSpawns.Length; i++)
        //{
        //    if (floor.assetSpawns[i] == -1)
        //    {
        //        floor.assetSpawns[i] = Random.Range(0, floor.assetSpawns.Length);
        //    }
        //}
        floorManager.assetSpawns = floor.assetSpawns;
        floorManager.assets = floor.assets;
        floorManager.rooms = floor.rooms;
        floorManager.Setup();
        //doors.Open();
    }

}
