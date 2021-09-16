using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteract : MonoBehaviour, IInteractable
{
    private Vector3 fix = new Vector3(1, 1, 1);
    private void Update()
    {
        //Hopefully a short term cheat to make the buttons visible and stop them from scaling down to (0,0,0)
        this.transform.localScale = fix;
    }

    //This id represents the position in the 'ElevatorButtons._instance.buttons' list
    private int id;

    //Set up the button id
    public void SetUp(int id)
    {
        this.id = id;
    }

    public void Use()
    {
        Debug.Log("Elevator button: " + id + " has been pressed.");
        //Run any events tied to the button
        if (ElevatorButtons._instance.buttons[id].OnButtonPress != null)
            ElevatorButtons._instance.buttons[id].OnButtonPress.Invoke();
    }
}
