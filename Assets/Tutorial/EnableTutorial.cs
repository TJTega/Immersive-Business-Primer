using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTutorial : MonoBehaviour
{
    private bool active;
    public GameObject tutorialPieces;
    
    // Start is called before the first frame update
    void Start()
    {
        tutorialPieces.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        tutorialPieces.SetActive(true);
        gameObject.SetActive(false);
    }
}
