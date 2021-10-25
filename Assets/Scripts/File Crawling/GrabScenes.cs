using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrabScenes : MonoBehaviour
{
    //Reference to room scriptable object
    Room current;
    Room roomSO;

    //This gets the folder structure to /Assets/
    private string m_Path;

    //The path for the directory to crawl
    public string defaultPath = "/Scenes/Experiences";

    //List of discovered rooms and list of discovered settings
    public List<string> roomList;
    public List<string> settingsList;

    //Dictionary key = room name, value back = settings
    public Dictionary<string, string> roomSettings = new Dictionary<string, string>();

    public string Something;

    void Start()
    {
        current = ScriptableObject.CreateInstance("Room") as Room;
        //Testing = ScriptableObject.CreateInstance("Room") as Room;
        m_Path = Application.dataPath;

        DirSearch(m_Path + defaultPath);
        LinkRoomsToSettings();
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
                    string fileExtension = new DirectoryInfo(filePath).Extension;

                    //Making sure we aren't grabbing unity generated files
                    if (fileExtension != ".meta")
                    {
                        //Actions based on file extension
                        switch (fileExtension)
                        {
                            case ".unity":
                                PopulateRoomList(fileName);
                                break;
                            case ".asset":
                                GrabRoomSettings(filePath);
                                break;
                            //case ".json":
                            //    GrabRoomSettings(filePath);
                            //    break;
                            default: break;
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
    public void GenerateRoomSettingsJson(string path)
    {
        //Grabbing settings from path
        using (StreamReader stream = new StreamReader(path))
        {
            string jsonFile = stream.ReadToEnd();

            //From JsonUtility Documentation:
            //When writing to a Scriptabe Object or Class use FromJsonOverwrite()
            //Works same as FromJson()
            JsonUtility.FromJsonOverwrite(jsonFile, current);
        }

        string json = JsonUtility.ToJson(current, true);
        settingsList.Add(json);
    }

    //This links each room to their Room_Settings.json
    public void LinkRoomsToSettings()
    {
        for (int i = 0; i < settingsList.Count; i++)
        {
            string jsonData = settingsList[i];
            string room = roomList[i];

            if (!roomSettings.ContainsKey(room))
            {
                roomSettings.Add(room, jsonData);
            }
        }
    }

    //Grab settings from scriptable object file
    public void GrabRoomSettings(string path)
    {
        path = Path.GetFullPath(path);
        path = path.Replace(@"\", "/");
        string toBeSearched = "/Assets/";
        string pathFix = "Assets/" + path.Substring(path.LastIndexOf(toBeSearched) + toBeSearched.Length);

        Room roomSettings = (Room)AssetDatabase.LoadAssetAtPath(pathFix, typeof(Room));
        roomSO = roomSettings;
    }
}
