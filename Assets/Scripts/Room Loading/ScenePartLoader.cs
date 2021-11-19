using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class SceneLoadManager
{
    public List<string> ScenesToLoad;
    public List<string> ScenesToUnload;
}
public class ScenePartLoader : MonoBehaviour
{
    public SceneLoadManager forwardManager;
    public SceneLoadManager backwardManager;

    protected float dotProduct;

    private bool shouldLoad = true;

    void LoadScene()
    {
        SceneLoadManager manager;
        if (dotProduct < 0)
        {
            manager = forwardManager;
        }
        else
        {
            manager = backwardManager;
        }

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

    protected virtual void UnLoadScene()
    {
        SceneLoadManager manager;
        if (dotProduct > 0)
        {
            manager = forwardManager;
        }
        else
        {
            manager = backwardManager;
        }

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
            shouldLoad = true;

            Vector3 pointToPlayer = PlayerInfo.playerPos - transform.position;
            dotProduct = Vector3.Dot(transform.right, pointToPlayer);
            Debug.Log(gameObject.name + ": " + dotProduct);

            TriggerCheck();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shouldLoad = false;

            Vector3 pointToPlayer = PlayerInfo.playerPos - transform.position;
            dotProduct = Vector3.Dot(transform.right, pointToPlayer);
            Debug.Log(gameObject.name + ": " + dotProduct);

           TriggerCheck();
        }
    }

    void TriggerCheck()
    {
        //shouldLoad is set from the Trigger methods
        if (shouldLoad)
        {
            Debug.Log("LOADING");
            LoadScene();
        }
        else
        {
            Debug.Log("UNLOADING");
            UnLoadScene();
        }
    }



}