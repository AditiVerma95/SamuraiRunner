using System;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class GameMechanic : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameFinishUI;
    public static GameMechanic Instance;

    private void Awake() {
        Instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            gameFinishUI.SetActive(true);
            AudioManager.Instance.StopAudio();
            Destroy(gameObject);
        }
        if (collision.CompareTag("Obstacle"))
        {
            gameOverUI.SetActive(true);
            AudioManager.Instance.StopAudio();
            Destroy(gameObject);
        }
    }
    
}