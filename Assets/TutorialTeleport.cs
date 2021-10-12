using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTeleport : MonoBehaviour
{
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
        if (other.tag == "RightPointerCollider")
            GameObject.FindGameObjectWithTag("XRRig").transform.position = teleportLocation.position;
    }

}
