using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGamePlay : MonoBehaviour
{
    public static UIGamePlay Instance;
    public Text scoreText;
    public GameObject pausePanel;
    public GameObject winPanel;
    public GameObject losePanel;
    public Button pauseButton;
    public Button restartButton;
    public Button homeButton;
    public Button continueButton;
    public Button nextLevelButton;
    public int score;

    public GameObject _mainCharater;
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
        scoreText.gameObject.SetActive(true);
        score = 0;
        PlayerPrefs.SetInt("Key", 0);
        _mainCharater.SetActive(true);

    }

    public void NextLevel()
    {
        AudioManager.Instance.audio_decide.Play();
        int curLevel = PlayerPrefs.GetInt("curLevel", 0);
        PlayerPrefs.SetInt("curLevel", curLevel + 1);
        SceneManager.LoadScene(StringHelper.GAME_PLAY_SCENE);
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins", 0) + score);
        PlayerPrefs.SetInt("Key", 0);

    }

    public void Continue()
    {
        AudioManager.Instance.audio_decide.Play();
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        _mainCharater.SetActive(true);
    }

    public void BackToHome()
    {
        AudioManager.Instance.audio_decide.Play();
        Time.timeScale = 1;
        SceneManager.LoadScene(StringHelper.START_GAME_SCENE);
        PlayerPrefs.SetInt("Key", 0);

        
    }

    public void RestartGame()
    {
        AudioManager.Instance.audio_decide.Play();
        Time.timeScale = 1;
        SceneManager.LoadScene(StringHelper.GAME_PLAY_SCENE);
        PlayerPrefs.SetInt("Key", 0);
        
    }

    public void Pause()
    {
        AudioManager.Instance.audio_decide.Play();
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        _mainCharater.SetActive(false);

    }

    public void Win()
    {
        _mainCharater.SetActive(false);

        scoreText.gameObject.SetActive(false);

        AudioManager.Instance.audio_win.Play();
        winPanel.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }

    public void Lose()
    {
        _mainCharater.SetActive(false);

        scoreText.gameObject.SetActive(false);
        AudioManager.Instance.audio_lose.Play();
        losePanel.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }
}