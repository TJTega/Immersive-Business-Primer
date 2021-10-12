using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentFloor : MonoBehaviour
{
    private GameObject moveContainer;
    // Start is called before the first frame update
    [ContextMenu("Snap")]
    void Start()
    {
        moveContainer = GameObject.FindGameObjectWithTag("PersistentFloorLocation");
        transform.position = moveContainer.transform.position;
        transform.rotation = moveContainer.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveContainer != null)
        {
            transform.position = moveContainer.transform.position;
            transform.rotation = moveContainer.transform.rotation;
        }
    }
}
