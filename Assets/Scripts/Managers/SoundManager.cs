using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] VoiceFiles;

    [SerializeField] private AudioSource audioSource;

    [SerializeField] private GameManager gManager;

    public bool playAvailable = false;
    public bool triggered = false;

    public int voiceLines;

    // Start is called before the first frame update
    void Start()
    {
        triggered = true;
        playAvailable = true;

        voiceLines = 0;

        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 10;
        audioSource.volume = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
