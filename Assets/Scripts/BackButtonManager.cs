using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonManager : MonoBehaviour
{

    public void BackButton() {
        MainMenuManager.Instance.Play();
        SceneManager.LoadScene("0");
    }
}
