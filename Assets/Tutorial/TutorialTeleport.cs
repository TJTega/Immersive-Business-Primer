using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;

public class TutorialTeleport : MonoBehaviour
{
    public GameObject lobby;
    public GameObject floor;
    public int lobbyFloorSwitch;
    public Transform teleportLocation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        switch(lobbyFloorSwitch)
        { case 1:
                if (other.tag == "RightPointerCollider")
                {
                    Invoke("TeleportPlayer", 0);
                    lobby.active = true;
                    floor.active = false;
                }
                break;
            case 2:
                if (other.tag == "RightPointerCollider")
                {
                    Invoke("TeleportPlayer", 0);
                    lobby.active = false;
                    floor.active = true;
                }
                break;
        }
       
    }
    
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
