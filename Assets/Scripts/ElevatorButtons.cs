using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButtons : MonoBehaviour
{
    public static ElevatorButtons _instance;

    public List<EButton> buttons = new List<EButton>();
    public GameObject buttonPrefab;
    public Transform root;
    public float buttonSpacing = .15f;

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


            //Move the button down from the root position in order to space them apart
            //TODO change this to a grid pattern rather than sraight down
            clone.transform.position += (Vector3.down * buttonCount) * buttonSpacing;
            spawnedButtons.Add(clone);

            //We use button count instead of 'i' so that we can set a button to not active and have the spacing consistant 
            buttonCount++;
        }
    }
}
