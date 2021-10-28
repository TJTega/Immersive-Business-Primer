using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
public class ElevatorDoors : MonoBehaviour
{
    public DOTweenAnimation animL;
    public DOTweenAnimation animR;
   private bool doorOpen = false;

    public UnityEvent onDoorClose;

    public AudioSource doorsOpen;
    public AudioSource doorsClosed;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        OpenDoor();
    }

    private void OnTriggerExit(Collider other)
    {
        CloseDoor();
    }

    [ContextMenu("Open")]
    public void OpenDoor()
    {
       
        animL.DOPlayForward();
        animR.DOPlayForward();
        doorOpen = true;
        doorsOpen.Play();
    }

    [ContextMenu("Close")]
    public void CloseDoor()
    {
        animL.DOPlayBackwards();
        animR.DOPlayBackwards();
        doorOpen = false;
        doorsClosed.Play();

        if (doorOpen == false && onDoorClose != null)
            onDoorClose.Invoke();
    }
}