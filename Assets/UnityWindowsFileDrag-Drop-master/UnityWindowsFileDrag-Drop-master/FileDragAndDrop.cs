using B83.Win32;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class FileDragAndDrop : MonoBehaviour
{
    public RawImage image;

    List<string> log = new List<string>();
    void OnEnable ()
    {
        // must be installed on the main thread to get the right thread id.
        UnityDragAndDropHook.InstallHook();
        UnityDragAndDropHook.OnDroppedFiles += OnFiles;
    }
    void OnDisable()
    {
        UnityDragAndDropHook.UninstallHook();
    }

    void OnFiles(List<string> aFiles, POINT aPos)
    {
        // do something with the dropped file names. aPos will contain the 
        // mouse position within the window where the files has been dropped.
        string str =aFiles.Aggregate((a, b) => a + "\n\t" + b);
        Debug.LogError(str);
        log.Add(str);
    }

    private void OnGUI()
    {
        if (GUILayout.Button("clear log"))
            log.Clear();
        foreach (var s in log)
        {
           
                WWW www = new WWW("file:///" + s);
                image.texture = www.texture;
            
        }
           
    }
}
