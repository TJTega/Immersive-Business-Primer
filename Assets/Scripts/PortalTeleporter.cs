using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PortalTeleporter : MonoBehaviour
{
    public Transform reciever;
    public Transform thisTP;
    private Transform player;
    private bool playerIsOverlapping = false;
    private bool hasTraveled = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsOverlapping)
        {
            Vector3 portalToPlayer = thisTP.position - player.position;
            float dotProduct = Vector3.Dot(transform.forward, portalToPlayer);

            // If this is true: The player has moved across the portal
            if (dotProduct < 0f)
            {
                // Teleport him!
                Invoke("TeleportPlayer", 0.5f);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }

    public void TeleportPlayer()
    {
        XRRig xrRig = GameObject.FindGameObjectWithTag("XRRig").GetComponent(typeof(XRRig)) as XRRig;

        //Entering a room
        if (xrRig != null && playerIsOverlapping && !hasTraveled)
        {
            xrRig.MatchRigUpCameraForward(reciever.rotation * Vector3.up, reciever.rotation * Vector3.forward);
            var heightAdjustment = xrRig.rig.transform.up * xrRig.cameraInRigSpaceHeight;
            var cameraDestination = reciever.transform.position + heightAdjustment;
            xrRig.MoveCameraToWorldLocation(cameraDestination);
            playerIsOverlapping = false;
            hasTraveled = true;
        }
    }
}
