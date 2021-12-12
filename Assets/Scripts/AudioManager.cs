using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // variable instance for the Audio Manager
    private static AudioManager _instance;

    // public property to retrieve the Audio Manager instance
    public static AudioManager Instance
    {
        get
        {
            // check if instance is NULL, throw an error message if it is 
            if (_instance == null)
            {
                Debug.LogError("Audio Manager is NULL !!");
            }
            // else return the instance
            return _instance;
        }
    }

    public AudioSource _voiceOver;

    private void Awake()
    {
        // assign the instance to this
        _instance = this;
    }

    public void PlayVoiceOver(AudioClip clipToPlay)
    {
        _voiceOver.clip = clipToPlay;
        _voiceOver.Play();
    }
}
