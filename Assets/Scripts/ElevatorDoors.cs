using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoors : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("inininiinin");
        anim.SetBool("IsDoorOpen", true);
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("IsDoorOpen", false);
    }
}