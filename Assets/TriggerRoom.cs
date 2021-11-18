using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class SceneLoadManager2
{
    public List<string> ScenesToLoad;
    public List<string> ScenesToUnload;
}
public class TriggerRoom : MonoBehaviour
{
    SceneLoadManager2 manager;
    public bool load = true;
    public SceneLoadManager2 forwardManager;
    public SceneLoadManager2 backwardManager;

    public bool loadNewScene = false;

    private bool shouldLoad = true;

    void LoadScene()
    {

    
        //Loading the scene, using the gameobject name as it's the same as the name of the scene to load
        foreach (var scene in manager.ScenesToLoad)
        {
            if (!SceneManager.GetSceneByName(scene).isLoaded)
            {
                SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            }
            Debug.Log("Should be loading");
        }

        //We set it to true to avoid loading the scene twice
    }

    void UnLoadScene()
    {
       
        
        foreach (var scene in manager.ScenesToUnload)
        {
            if (SceneManager.GetSceneByName(scene).isLoaded)
            {
                SceneManager.UnloadSceneAsync(scene);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           

            TriggerCheck();
        }
    }

    
    
    [ContextMenu("use")]
    void TriggerCheck()
    {
       
        if (load == true)
        {
            manager = forwardManager;
            LoadScene();

            UnLoadScene();
        }
        else
        {
            manager = backwardManager;
            LoadScene();
           
            UnLoadScene();
        }
        //shouldLoad is set from the Trigger methods
        
        
    }

}
