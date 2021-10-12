using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public AudioSource tutorialAudio;
    public Text subtitleText;
    public string subtitleLine;
    private AudioSource[] allAudioSources;
    private bool playAvailable= false;
    // Start is called before the first frame update
    void Start()
    {
        subtitleText.text = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" )
        {
            Invoke("StopAllAudio", 0);
          
            StartCoroutine("StartAudio");
        }
    }
    IEnumerator StartAudio()
    {
        yield return new WaitForSeconds(.2f);
        subtitleText.text = subtitleLine;
        tutorialAudio.Play();
    }



    void Awake()
    {
        allAudioSources = Object.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
    }

    void StopAllAudio()
    {
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
            Debug.Log("Stopping Music....");
        }
    }
}
