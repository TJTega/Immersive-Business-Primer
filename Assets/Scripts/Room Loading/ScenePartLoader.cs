using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class SceneLoadManager
{
    public string[] ScenesToLoad;
    public string[] ScenesToUnload;
}
public class ScenePartLoader : MonoBehaviour
{
    public SceneLoadManager forwardManager;
    public SceneLoadManager backwardManager;

    private float dotProduct;

    private bool shouldLoad = true;

    void LoadScene()
    {

        //Loading the scene, using the gameobject name as it's the same as the name of the scene to load
        foreach (var scene in forwardManager.ScenesToLoad)
        {
            if (!SceneManager.GetSceneByName(scene).isLoaded)
            {
                SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            }
        }
        //We set it to true to avoid loading the scene twice
    }

    void UnLoadScene()
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