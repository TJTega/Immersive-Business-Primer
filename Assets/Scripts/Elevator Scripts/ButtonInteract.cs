using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ButtonInteract : MonoBehaviour, IInteractable
{
    //This id represents the position in the 'ElevatorButtons._instance.buttons' list
    private int id;

    //Set up the button id
    public void SetUp(int id)
    {
        this.id = id;
    }

    [ContextMenu("Use")]
    public void Use()
    {
        //Run any events tied to the button
        if (ElevatorButtons._instance.buttons[id].OnButtonPress != null)
            ElevatorButtons._instance.buttons[id].OnButtonPress.Invoke();
        //Debug.Log(ElevatorButtons._instance.buttons[id].OnButtonPress);
    } 
}
