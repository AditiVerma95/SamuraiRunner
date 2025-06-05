using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    private AudioSource audioSource;
    [SerializeField] private AudioClip idleAudio;
    [SerializeField] private AudioClip runningAudio;
    public static AudioManager Instance;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        PlayIdleAudio();
    }

    public void PlayIdleAudio() {
        audioSource.clip = idleAudio;
        audioSource.Play();
    }
    
    public void PlayRunningAudio() {
        audioSource.clip = runningAudio;
        audioSource.Play();
    }

    public void StopAudio() {
        audioSource.Stop();
    }
}
