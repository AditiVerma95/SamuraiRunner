using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {
    private AudioSource audioSource;
    [SerializeField] private AudioClip idleAudio;
    [SerializeField] private AudioClip runningAudio;
    public static AudioManager Instance;

    private void Awake() {
        // Only set Instance if it's null to prevent overwriting
        if (Instance == null) {
            Instance = this;
        }
    }

    private void Start() {
        audioSource = GetComponent<AudioSource>();

        // Load saved volume or use 1.0 if none exists
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        audioSource.volume = savedVolume;

        // Sync slider if found
        Slider slider = GameObject.Find("VolumeSlider")?.GetComponent<Slider>();
        if (slider != null) {
            slider.value = savedVolume;
        }

        if (SceneManager.GetActiveScene().buildIndex != 0) {
            PlayIdleAudio();
        }
    }

    public void SetVolume(float value) {
        if (audioSource != null) {
            audioSource.volume = value;
            PlayerPrefs.SetFloat("Volume", value);
            PlayerPrefs.Save();
        }
    }

    public void PlayIdleAudio() {
        if (idleAudio != null) {
            audioSource.clip = idleAudio;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void PlayRunningAudio() {
        if (runningAudio != null) {
            audioSource.clip = runningAudio;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void StopAudio() {
        audioSource.Stop();
    }
}