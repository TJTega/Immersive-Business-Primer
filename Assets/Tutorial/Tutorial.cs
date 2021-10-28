using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FadeParameters
{
    private bool fade;
    private int direction;

    public void SetParameters(bool fadeInput, int diretionInput)
    {
        fade = fadeInput;
        direction = diretionInput;
    }
    public bool GetFade()
    {
        return fade;
    }

    public int GetDirection()
    {
        return direction;
    }
}
public class Tutorial : MonoBehaviour
{
    public AudioSource tutorialAudio;
    public TMP_Text subtitleText;
    public string subtitleLine;
    private AudioSource[] allAudioSources;
    private bool playAvailable= false;

    private FadeParameters fade = new FadeParameters();
    // Start is called before the first frame update
    void Start()
    {
        subtitleText.text = null;
    }

    // Update is called once per frame
    void Update()
    {
        Color color = subtitleText.color;
        if (fade.GetFade() && color.a > 0 || fade.GetFade() && color.a < 1)
        {
            color.a += Time.deltaTime * fade.GetDirection(); ;
        }
        else if (color.a <= 0)
        {
            color.a = 0;
        }
        else if (color.a >= 1)
        {
            color.a = 1;
        }
        subtitleText.color = color;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" )
        {
            if (playAvailable == false)
            {
                Invoke("StopAllAudio", 0);
                fade.SetParameters(true, -1);
                StartCoroutine("StartAudio");
            }
        }
    }
    IEnumerator StartAudio()
    {
        
        
            yield return new WaitForSeconds(.2f);
            subtitleText.text = subtitleLine;
            fade.SetParameters(true, 1);
            tutorialAudio.Play();
            playAvailable = true;
        
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
