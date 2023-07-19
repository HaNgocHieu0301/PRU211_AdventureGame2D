using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIStartGame : MonoBehaviour
{
    public Text score;
    public Button continueGameBtn;
    public Button newGameBtn;
    public Button settingBtn;
    void Start()
    {
        continueGameBtn.onClick.AddListener(ContinueGame);
        newGameBtn.onClick.AddListener(NewGame);
        // settingBtn.onClick.AddListener(Setting);
        score.text = "Score: " + PlayerPrefs.GetInt("Coins").ToString();
    }

    private void Setting()
    {
        throw new System.NotImplementedException();
    }

    private void NewGame()
    {
        PlayerPrefs.SetInt("curLevel",0);
        SceneManager.LoadScene(StringHelper.GAME_PLAY_SCENE);
    }

    private void ContinueGame()
    {
        SceneManager.LoadScene(StringHelper.GAME_PLAY_SCENE);
    }
}
