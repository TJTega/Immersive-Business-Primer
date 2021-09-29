using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ElevatorDoors : MonoBehaviour
{
    public Animator animL;
    public Animator animR;
    public bool doorOpen = false;

    public UnityAction OnDoorClose;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("inininiinin");
        OpenDoor();
    }

    private void OnTriggerExit(Collider other)
    {
        CloseDoor();
    }

    [ContextMenu("Open")]
    public void OpenDoor()
    {
        animL.SetBool("IsDoorOpen", true);
        animR.SetBool("IsDoorOpen", true);
        doorOpen = true;
    }

    [ContextMenu("Close")]
    public void CloseDoor()
    {
        animL.SetBool("IsDoorOpen", false);
        animR.SetBool("IsDoorOpen", false);
        doorOpen = false;

        if (doorOpen == false && OnDoorClose != null)
            OnDoorClose.Invoke();
    }
}