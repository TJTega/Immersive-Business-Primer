using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

public class GrabSceneNames : MonoBehaviour
{
    //This gets the folder structure to /Assets/
    private string m_Path;

    //The path for the directory to crawl
    public string defaultPath = "/Scenes/Experiences";

    public List<string> roomList;

    private TextAsset jsonFileContents;

    // Start is called before the first frame update
    void Start()
    {
        m_Path = Application.dataPath;

        DirSearch(m_Path + defaultPath);

    }

    //This method will return all files in sub-folders relative to the given path.
    public void DirSearch(string sDir)
    {
        try
        {
            foreach (string directory in Directory.GetDirectories(sDir))
            {
                foreach (string filePath in Directory.GetFiles(directory))
                {
                    string fileName = new DirectoryInfo(filePath).Name;

                    //Making sure we only grab scene files or their serttings
                    if (fileName.Contains(".unity") || fileName.Contains(".json"))
                    {
                        //Making sure we aren't grabbing unity generated files
                        if (!fileName.Contains(".meta"))
                        {
                            if (fileName.Contains(".unity"))
                            {
                                PopulateRoomList(fileName);
                            }
                            else
                            {
                                GrabSettings(filePath);
                            }
                        }
                    }
                }
                //Recursion for subfolders
                DirSearch(directory);
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    //This populates the list of rooms.
    public void PopulateRoomList(string roomName)
    {
        roomList.Add(roomName);
    }

    //This populates the list of scriptable objects attached to rooms.
    public void GrabSettings(string path)
    {
        //TODO: Grab settings using the room name and path
        //jsonFileContents = patwh;

        var fileName = new DirectoryInfo(path).Name;
        var yourFile = path.FirstOrDefault();
        print(yourFile);
        //print(fileName);

        //Room current = JsonUtility.FromJson<Room>(fileName.text);
       // string json = JsonUtility.ToJson(current);
        //Debug.Log(json);
    }
}
