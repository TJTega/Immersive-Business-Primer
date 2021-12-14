using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
public class ElevatorDoors : MonoBehaviour
{
    public DOTweenAnimation animL;
    public DOTweenAnimation animR;
    public DOTweenAnimation elevatorMovingAnim;
    public bool doorOpen = false;

    public UnityAction onDoorClose;

    public AudioSource doorsOpen;
    public AudioSource doorsClosed;






    [ContextMenu("Open")]
    public void OpenDoor()
    {
        Debug.Log("Opening Doors");
        animL.DORewind();
        animR.DORewind();
        animL.DOPlayForward();
        animR.DOPlayForward();
        doorOpen = true;
        doorsOpen.Play();
    }

    [ContextMenu("Close")]
    public void CloseDoor()
    {
        Debug.Log("Closing Doors");
        animL.DOPlayBackwards();
        animR.DOPlayBackwards();
        doorOpen = false;
        doorsClosed.Play();


    }
    [ContextMenu("ElevatorMove")]
    public void ElevatorMove()
    {
        CloseDoor();
        if (!doorOpen)
        {
            Debug.Log("Elevator is Moving");
            elevatorMovingAnim.DOPlayForward();
            elevatorMovingAnim.DOPlayForward();
            doorOpen = true;
        }



    }

    public void OnDoorClose()
    {
        Debug.Log("Elevator complete");
        onDoorClose.Invoke();
    }
}