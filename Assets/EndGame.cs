using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public void BackToMenu()
    {
        PlayerPrefs.SetInt("curLevel", 0);
        PlayerPrefs.SetInt("Key", 0);
        SceneManager.LoadScene("StartGameScene");
    }
}
