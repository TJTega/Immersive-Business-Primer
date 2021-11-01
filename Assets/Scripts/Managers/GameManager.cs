using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    public ElevatorButtons elevator;

    public ElevatorDoors elevatorDoors;

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
        SceneManager.LoadSceneAsync("Lighting", LoadSceneMode.Additive);
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
        //Code to make doors shut every time the button is pressed
        if (elevatorDoors.doorOpen)
        {
            elevatorDoors.CloseDoor();
            elevatorDoors.onDoorClose = () => StartCoroutine(LoadFloor(floor));

            Debug.Log("Been Called Open");
        }
        else
        {
            StartCoroutine(LoadFloor(floor));
            Debug.Log("Been Called Closed");
        }
        Debug.Log(elevatorDoors.onDoorClose);
    }

    private IEnumerator LoadFloor(Floor floor)
    {
        //Temporary commenting for testing with play elevator animation
        //DOTween.Play("Elevator");

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
        if (SceneManager.GetSceneByName("MakingItPretty").isLoaded)
        {
            SceneManager.UnloadSceneAsync("MakingItPretty");
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
        floorManager.subsceneAssets = floor.subsceneAssets;
        floorManager.rooms = floor.rooms;
        floorManager.doorsObject = floor.doors;
        //Initialise floor
        floorManager.Setup();

        //Trying to get elevator animations working

        //elevatorDoors.onDoorClose = null;
        elevatorDoors.OpenDoor();
    }
}
