using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GrabSceneNames : MonoBehaviour
{
    string m_Path;

    // Start is called before the first frame update
    void Start()
    {
        m_Path = Application.dataPath;
        //Debug.Log(m_Path);
        DirSearch(m_Path + "/Scenes");
    }

    static void DirSearch(string sDir)
    {
        try
        {
            foreach (string d in Directory.GetDirectories(sDir))
            {
                foreach (string f in Directory.GetFiles(d))
                {
                    Debug.Log(f);
                }
                DirSearch(d);
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
