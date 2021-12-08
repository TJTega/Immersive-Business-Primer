using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //public SceneReference lobbyScene;
    public string lobbyScene;

    public ElevatorButtons elevator;

    public ElevatorDoors elevatorDoors;

    public List<Floor> floors;

    public TMP_Text currentFloorText;

    //public Elevator doors;
    private void Awake()
    {
        SceneManager.LoadSceneAsync("Lighting", LoadSceneMode.Additive);
        LoadButtons();
    }

    private void LoadButtons()
    {
        #region Lobby Button
        //Adds the lobby button to elevator buttons
        EButton lobbyButton = new EButton();
        lobbyButton.active = true;
        lobbyButton.floorName = "Reception";
        //Sets lobby button action
        lobbyButton.OnButtonPress = () =>
        {
                elevatorDoors.ElevatorMove();
            //Sets elevator action
            if (elevatorDoors.doorOpen)
            {
                Debug.Log("Been Called Open");
                elevatorDoors.onDoorClose = () =>
                {
                    StartCoroutine(LoadLobby());
                };
            }
            else
            {
                Debug.Log("Been Called Closed");
                StartCoroutine(LoadLobby());
            }
        };
        elevator.buttons.Add(lobbyButton);
        #endregion

        #region Floor Buttons
        //Grabs the data from each element in the floors list
        foreach (var floor in floors)
        {
            EButton button = new EButton();
            button.active = true;
            Floor temp = floor;
            button.floorName = floor.floorName;
            button.OnButtonPress = (() => StartLoadFloor(temp));
            elevator.buttons.Add(button);
        }
        #endregion

        //initializes the buttons
        elevator.CreateButtons();
    }

    private void StartLoadFloor(Floor floor)
    {
        //Debug.Log(floor.name);
        //Code to make doors shut every time the button is pressed
        if (floor != FloorManager.currentFloor)
        {
            elevatorDoors.ElevatorMove();
            if (elevatorDoors.doorOpen)
            {
                Debug.Log("Been Called Open");
                elevatorDoors.onDoorClose = () => StartCoroutine(LoadFloor(floor));
            }
            else
            {
                Debug.Log("Been Called Closed");
                StartCoroutine(LoadFloor(floor));
            }

        }
    }

    public IEnumerator LoadLobby(float waitForSeconds = 0f)
    {
        yield return new WaitForSeconds(waitForSeconds);

        if (!SceneManager.GetSceneByName(lobbyScene).isLoaded)
        {
            SceneManager.LoadSceneAsync(lobbyScene);
        }
        if (!SceneManager.GetSceneByName("Lighting").isLoaded)
        {
            SceneManager.LoadSceneAsync("Lighting", LoadSceneMode.Additive);
        }

        currentFloorText.text = "Reception";

        //elevatorDoors.ElevatorMove();
        elevatorDoors.onDoorClose = null;
    }

    public IEnumerator LoadFloor(Floor floor)
    {
        //Temporary commenting for testing with play elevator animation
        Debug.Log("Loading Floor");

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
        if (SceneManager.GetSceneByName("Sound & Animation").isLoaded)
        {
            SceneManager.UnloadSceneAsync("Sound & Animation");
        }

        //Find the floorManager Script
        GameObject floorManagerObject = GameObject.FindGameObjectWithTag("FloorManager");
        FloorManager floorManager = floorManagerObject.GetComponent<FloorManager>();

        currentFloorText.text = floor.floorName;

        #region Floor manager settings
        //Pass data into floor manager script
        FloorManager.currentFloor = floor;
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
        #endregion

        //Trying to get elevator animations working
        //elevatorDoors.ElevatorMove();
        elevatorDoors.onDoorClose = null;
    }
}
