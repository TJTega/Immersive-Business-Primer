using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TutorialTeleport : MonoBehaviour
{
    public GameObject lobby;
    public GameObject floor;
    public int lobbyFloorSwitch;
    public Transform teleportLocation;

    private void OnTriggerEnter(Collider other)
    {
        //Only go inside and teleport player if the collider that entered is "RightPointerCollider"
        if (other.tag == "RightPointerCollider")
        {
            switch (lobbyFloorSwitch)
            {
                case 1:

                    Invoke("TeleportPlayer", 0);
                    lobby.SetActive(true);
                    floor.SetActive(false);
                    break;
                case 2:

                    Invoke("TeleportPlayer", 0);
                    lobby.SetActive(false);
                    floor.SetActive(true);
                    break;
            }
        }
    }

    //Teleporting the player and xrRig instead of setting the transform.position
    //This is done to prevent players going out of bounds when exploring the edges
    public void TeleportPlayer()
    {
        XRRig xrRig = GameObject.FindGameObjectWithTag("XRRig").GetComponent(typeof(XRRig)) as XRRig;
        if (xrRig != null)
        {
            xrRig.MatchRigUpCameraForward(teleportLocation.rotation * Vector3.up, teleportLocation.rotation * Vector3.forward);

            var heightAdjustment = xrRig.rig.transform.up * xrRig.cameraInRigSpaceHeight;

            var cameraDestination = teleportLocation.transform.position + heightAdjustment;

            xrRig.MoveCameraToWorldLocation(cameraDestination);
        }
    }

}
