using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    public ElevatorButtons elevator;

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
        //doors.Close();
        //doors.OnDoorClose += (() => StartCoroutine(LoadFloor(floor)));
    }

    /*private IEnumerator LoadFloor(Floor floor)
    {
        yield return null;
        if (!SceneManager.GetSceneByName("Corridor").isLoaded)
        {
            AsyncOperation async = SceneManager.LoadSceneAsync("Corridor");
            while (!async.isDone)
            {
                yield return null;
            }
        }
        GameObject floorManagerObject = GameObject.FindGameObjectWithTag("FloorManager");
        FloorManager floorManager = floorManagerObject.GetComponent<FloorManager>();
        floorManager.floorName = floor.floor.name;
        floorManager.wallColor = floor.floor.color;
        for (int i = 0; i < floor.floor.elementsToSpawn.Length; i++)
        {
            if (floor.floor.elementsToSpawn[i] == -1)
            {
                floor.floor.elementsToSpawn[i] = Random.Range(0, floor.floor.subsceneElements.Length);
            }
        }
        floorManager.elementsToSpawn = floor.floor.elementsToSpawn;
        floorManager.subsceneElements = floor.floor.subsceneElements;
        floorManager.worlds = floor.floor.worlds;
        floorManager.Setup();
        doors.Open();
    }*/

}
