using System;
using System.Collections;
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
    private int count = 0;

    [HideInInspector]
    public Vector3 setOffset;

    protected virtual void LoadScene()
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


        count = 0;

        //Loading the scene, using the gameobject name as it's the same as the name of the scene to load
        foreach (var scene in manager.ScenesToLoad)
        {
            StartCoroutine(WaitLoad(scene, manager));
        }
        //Debug.Log("Should be loading");
    }

    public IEnumerator WaitLoad(string scene, SceneLoadManager manager)
    {
        if (!SceneManager.GetSceneByName(scene).isLoaded)
        {
            AsyncOperation async = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            while (!async.isDone)
            {
                yield return null;
            }
            count += 1;
            SetOffsets(manager);
        }
    }

    private void SetOffsets(SceneLoadManager manager)
    {
        if (count == manager.ScenesToLoad.Count)
        {
            GameObject[] offsets = GameObject.FindGameObjectsWithTag("Offset");

            foreach (var offset in offsets)
            {
                Debug.Log(offset);
                if (offset != null)
                    offset.transform.position += setOffset;
            }
        }
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

        if (forwardManager.ScenesToLoad != null && forwardManager.ScenesToLoad.Count > 0)
        {
            if (SceneManager.GetSceneByName(forwardManager.ScenesToLoad[0]).isLoaded)
            {
                foreach (var scene in manager.ScenesToUnload)
                {
                    if (SceneManager.GetSceneByName(scene).isLoaded)
                    {
                        //Debug.Log($"Unloading: {scene}");
                        SceneManager.UnloadSceneAsync(scene);
                    }
                }
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
            //Debug.Log(gameObject.name + ": " + dotProduct);

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
            //Debug.Log(gameObject.name + ": " + dotProduct);

            TriggerCheck();
        }
    }

    void TriggerCheck()
    {
        //shouldLoad is set from the Trigger methods
        if (shouldLoad)
        {
            //Debug.Log("LOADING");
            LoadScene();
        }
        else
        {
            //Debug.Log("UNLOADING");
            UnLoadScene();
        }
    }
}