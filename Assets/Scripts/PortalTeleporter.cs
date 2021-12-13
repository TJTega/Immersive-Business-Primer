using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PortalTeleporter : MonoBehaviour
{
    public Transform reciever;

    private bool playerIsOverlapping = false;

    // Update is called once per frame
    void Update()
    {
        if (playerIsOverlapping)
        {
            Vector3 portalToPlayer = this.transform.position - reciever.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            Debug.Log("overlap");
            Debug.Log(dotProduct);

            // If this is true: The player has moved across the portal
            if (dotProduct > 0f)
            {
                // Teleport him!
                Invoke("TeleportPlayer", 0);
                //float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
                //rotationDiff += 180;
                //player.Rotate(Vector3.up, rotationDiff);
                //Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                //player.position = reciever.position + positionOffset;

                playerIsOverlapping = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Portal")
        {
            playerIsOverlapping = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Portal")
        {
            playerIsOverlapping = false;
        }
    }

    public void TeleportPlayer()
    {
        XRRig xrRig = GameObject.FindGameObjectWithTag("XRRig").GetComponent(typeof(XRRig)) as XRRig;
        if (xrRig != null)
        {
            Debug.Log("tptp");

            xrRig.MatchRigUpCameraForward(reciever.rotation * Vector3.up, reciever.rotation * Vector3.forward);

            var heightAdjustment = xrRig.rig.transform.up * xrRig.cameraInRigSpaceHeight;

            var cameraDestination = reciever.transform.position + heightAdjustment;

            xrRig.MoveCameraToWorldLocation(cameraDestination);
        }
    }
}
