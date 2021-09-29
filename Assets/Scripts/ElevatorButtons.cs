using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButtons : MonoBehaviour
{
    public static ElevatorButtons _instance;

    public List<EButton> buttons = new List<EButton>();
    public GameObject buttonPrefab;
    public Transform root;
    public Vector2 buttonSpacing = new Vector2(.15f, .15f);
    public int columnCount = 2;

    private List<GameObject> spawnedButtons = new List<GameObject>();
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
    }

    public void CreateButtons()
    {
        int buttonCount = 0;
        int row = 0;
        for (int i = 0; i < buttons.Count; i++)
        {
            //If the button is not set to active then do not create it.
            if (buttons[i].active == false)
                continue;

            //Create the button under the root object and give it the correct name and color
            GameObject clone = Instantiate(buttonPrefab, root);


            //Find the button interact and set the correct scene to load
            ButtonInteract btn = clone.GetComponent<ButtonInteract>();
            if (btn != null)
            {
                //Set up the button with the correct data
                btn.SetUp(i);
            }
            else
            {
                Destroy(clone);
                Debug.LogError("No ButtonInteract component was found on the button, it was destroyed");
            }


            //Arranges the buttons in a configurable grid pattern
            //Controls y-axis
            if (buttonCount % columnCount == 0)
            {
                clone.transform.position += (-transform.up * (buttonCount / columnCount)) * buttonSpacing.y;
                row = buttonCount / columnCount;
            }
            else
            {
                clone.transform.position += (-transform.up * row) * buttonSpacing.y;
            }

            //Controls X axis
            clone.transform.position += (transform.right * (buttonCount % columnCount)) * buttonSpacing.x;

            spawnedButtons.Add(clone);

            //We use button count instead of 'i' so that we can set a button to not active and have the spacing consistant 
            buttonCount++;
        }
    }
}
