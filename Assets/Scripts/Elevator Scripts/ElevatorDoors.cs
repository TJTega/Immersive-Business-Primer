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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == "Player")
        {
            OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            CloseDoor();
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

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

        if (onDoorClose != null)
        {
            Sequence s = DOTween.Sequence().OnComplete(() => onDoorClose.Invoke());
            s.Complete();
        }
    }
    [ContextMenu("ElevatorMove")]
    public void ElevatorMove()
    {
        Debug.Log("Elevator is Moving");
        elevatorMovingAnim.DOPlayForward();
        elevatorMovingAnim.DOPlayForward();
        doorOpen = true;
       

        if (onDoorClose != null)
        {
            Sequence s = DOTween.Sequence().OnComplete(() => onDoorClose.Invoke());
            s.Complete();
        }
    }
}