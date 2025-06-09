using System;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMechanic : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameFinishUI;
    public static GameMechanic Instance;
    public bool playerDead;
    
    private void Awake() {
        Instance = this;
    }

    public void SceneReload() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            gameFinishUI.SetActive(true);
            AudioManager.Instance.StopAudio();
            Destroy(gameObject);
            SceneReload();
        }
        if (collision.CompareTag("Obstacle"))
        {
            gameOverUI.SetActive(true);
            AudioManager.Instance.StopAudio();
            Destroy(gameObject);
            SceneReload();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("ice")) {
            Debug.Log("Collided with ice");
            //other.collider.tag = "Untagged";
            StartCoroutine(GravityRunner.Instance.FreezeCoroutine());
        }

        if (other.gameObject.CompareTag("Fire")) {
            gameOverUI.SetActive(true);
            AudioManager.Instance.StopAudio();
            Destroy(gameObject);
            SceneReload();
        }
    }
}