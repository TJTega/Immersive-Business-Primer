using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrabScenes : MonoBehaviour
{
    //Reference to room scriptable object
    Room roomSO;

    //This gets the folder structure to /Assets/
    private string m_Path;

    //The path for the directory to crawl
    public string defaultPath = "/Scenes/Experiences";

    //List of discovered rooms and list of discovered settings
    public List<string> roomList;
    public List<Room> settingsList;

    //Dictionary key = room name, value back = settings
    public Dictionary<string, string> roomSettings = new Dictionary<string, string>();

    public string Something;

    void Start()
    {
        //current = ScriptableObject.CreateInstance("Room") as Room;
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

    //This links each room to their Room_Settings.json
    public void LinkRoomsToSettings()
    {
        //EditorBuildSettings.scenes.
        for (int i = 0; i < settingsList.Count; i++)
        {
            //string jsonData = settingsList[i];
            string room = roomList[i];

            if (!roomSettings.ContainsKey(room))
            {
                //roomSettings.Add(room, jsonData);
            }
        }
    }

    //Grab settings from scriptable object file
    public void GrabRoomSettings(string path)
    {
        string tempPath = path;
        //Fixing up the string as LoadAssetPath will only accept "/" (forward slashes) as valid paths
        tempPath = Path.GetFullPath(path);
        tempPath = tempPath.Replace(@"\", "/");
        string toBeSearched = "/Assets/";
        string pathFix = "Assets/" + tempPath.Substring(tempPath.LastIndexOf(toBeSearched) + toBeSearched.Length);

        Room roomSettings = (Room)AssetDatabase.LoadAssetAtPath(pathFix, typeof(Room));
        roomSO = roomSettings;
        settingsList.Add(roomSO);

        string json = JsonUtility.ToJson(roomSO, true);
        GenerateRoomSettingsJson(path, json);
    }

    //This generates room settings in Json format.
    public void GenerateRoomSettingsJson(string path, string roomSettings)
    {
        File.WriteAllText(path.Replace(".asset", ".json"), roomSettings);
    }
}
