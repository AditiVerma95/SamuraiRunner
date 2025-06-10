using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {
    private Stack<GameObject> stack;

    [SerializeField] private Button backButton;

    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject howToPlayPanel;
    [SerializeField] private GameObject levelSelectPanel;

    private GameObject currentPanel;
    public static MainMenuManager Instance;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        stack = new Stack<GameObject>();
        currentPanel = startPanel;
        backButton.gameObject.SetActive(false);
    }
    
    public void Play() {
        ChangePanel(levelSelectPanel);
    }

    public void SelectLevel(int buldIndex) {
        SceneManager.LoadScene(buldIndex);
    }
    public void Options() {
        ChangePanel(optionsPanel);
    }

    public void HowToPlay() {
        ChangePanel(howToPlayPanel);
    }

    public void Exit() {
        Application.Quit();
    }

    public void Back() {
        currentPanel.SetActive(false);
        currentPanel = stack.Pop();
        currentPanel.SetActive(true);
        
        if (currentPanel == startPanel) {
            backButton.gameObject.SetActive(false);
        }
    }

    private void ChangePanel(GameObject panel) {
        stack.Push(currentPanel);
        currentPanel.SetActive(false);
        currentPanel = panel;
        currentPanel.SetActive(true);
        backButton.gameObject.SetActive(true);
    }

    
}
