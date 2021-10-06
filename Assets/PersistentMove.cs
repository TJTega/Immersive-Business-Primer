using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentMove : MonoBehaviour
{
    private GameObject moveContainer;
    // Start is called before the first frame update
    void Start()
    {
        moveContainer = GameObject.FindGameObjectWithTag("LobbyLocation");
        transform.position = moveContainer.transform.position;
        transform.rotation = moveContainer.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = moveContainer.transform.position;
        transform.rotation = moveContainer.transform.rotation;
    }
}
