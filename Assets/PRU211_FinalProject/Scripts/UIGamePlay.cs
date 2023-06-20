using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGamePlay : MonoBehaviour
{
    public static UIGamePlay Instance;
    public GameObject pausePanel;
    public GameObject winPanel;
    public GameObject losePanel;
    public Button pauseButton;
    public Button restartButton;
    public Button homeButton;
    public Button continueButton;
    public Button nextLevelButton;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        pauseButton.onClick.AddListener(Pause);
        restartButton.onClick.AddListener(RestartGame);
        homeButton.onClick.AddListener(BackToHome);
        continueButton.onClick.AddListener(Continue);
        nextLevelButton.onClick.AddListener(NextLevel);
    }

    private void NextLevel()
    {
        int curLevel = PlayerPrefs.GetInt("curLevel", 0);
        PlayerPrefs.SetInt("curLevel",curLevel+1);
        SceneManager.LoadScene(StringHelper.GAME_PLAY_SCENE);
    }

    private void Continue()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }

    private void BackToHome()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(StringHelper.START_GAME_SCENE);
    }

    private void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(StringHelper.GAME_PLAY_SCENE);
    }

    private void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }

    public void Win()
    {
        winPanel.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }
    public void Lose()
    {
        losePanel.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }
}
