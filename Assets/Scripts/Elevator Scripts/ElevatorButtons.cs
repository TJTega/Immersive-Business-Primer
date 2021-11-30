using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ElevatorButtons : MonoBehaviour
{
    public static ElevatorButtons _instance;

    [Header("Buttons")]
    public List<EButton> buttons = new List<EButton>();

    [Header("Button Spawning")]
    public GameObject buttonPrefab;
    public Transform btnRoot;
    public Vector2 buttonSpacing = new Vector2(.15f, .15f);
    public int columnCount = 2;

    [Header("Label Spawning")]
    public GameObject textPrefab;
    public Transform txtRoot;
    public float labelSpacing = -0.15f;

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

        MeshRenderer mRender = gameObject.GetComponent<MeshRenderer>();
        mRender.enabled = false;
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
            GameObject clone = Instantiate(buttonPrefab, btnRoot);
            GameObject lblClone = Instantiate(textPrefab, txtRoot);

            //Find the button interact and set the correct scene to load
            ButtonInteract btn = clone.GetComponent<ButtonInteract>();
            TMP_Text text = lblClone.GetComponent<TMP_Text>();

            if (btn != null && text != null)
            {
                //Set up the button with the correct data
                btn.SetUp(i);
                text.text = $"{i}: {buttons[i].floorName}";
            }
            else
            {
                Destroy(clone);
                Destroy(lblClone);
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
            lblClone.transform.position += (-transform.up * buttonCount) * labelSpacing;

            //Controls X axis
            clone.transform.position += (-transform.forward * (buttonCount % columnCount)) * buttonSpacing.x;

            spawnedButtons.Add(clone);

            //We use button count instead of 'i' so that we can set a button to not active and have the spacing consistant 
            buttonCount++;
        }
    }
}
