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
        //Grabs the data from each element in the floors list
        foreach (var floor in floors)
        {
            EButton button = new EButton();
            button.active = true;
            Floor temp = floor;
            button.OnButtonPress = (() => StartLoadFloor(temp));
            elevator.buttons.Add(button);
        }
        //initializes the buttons
        elevator.CreateButtons();
    }

    private void StartLoadFloor(Floor floor)
    {
        //Closes door and starts to load the floor
        doors.CloseDoor();
        //doors.OnDoorClose += (() => StartCoroutine(LoadFloor(floor)));
        StartCoroutine(LoadFloor(floor));
    }

    private IEnumerator LoadFloor(Floor floor)
    {
        yield return null;

        

        //If the scene isn't loaded
        if (!SceneManager.GetSceneByName("Floor").isLoaded)
        {
            //Load the scene
            AsyncOperation async = SceneManager.LoadSceneAsync("Floor", LoadSceneMode.Additive);
            //Don't continue until scene is loaded
            while (!async.isDone)
            {
                yield return null;
            }
        }
        if (!SceneManager.GetSceneByName("Lighting").isLoaded)
        {
            //Load general lighting scene on top of floor
            AsyncOperation async = SceneManager.LoadSceneAsync("Lighting", LoadSceneMode.Additive);
            //Don't continue until scene is loaded
            while (!async.isDone)
            {
                yield return null;
            }
        }
        if (SceneManager.GetSceneByName("Lobby").isLoaded)
        {
            SceneManager.UnloadSceneAsync("Lobby");
        }
        if (SceneManager.GetSceneByName("Calibration").isLoaded)
        {
            SceneManager.UnloadSceneAsync("Calibration");
        }
        //Find the floorManager Script
        GameObject floorManagerObject = GameObject.FindGameObjectWithTag("FloorManager");
        FloorManager floorManager = floorManagerObject.GetComponent<FloorManager>();

        //Pass data into floor manager script
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
        floorManager.skirtingObject = floor.skirting;
        floorManager.overheadsObject = floor.overheads;
        floorManager.assetSpawns = floor.assetSpawns;
        floorManager.assets = floor.assets;
        floorManager.rooms = floor.rooms;

        //Initialise floor
        floorManager.Setup();

        //Open doors
        doors.OpenDoor();
    }

}
