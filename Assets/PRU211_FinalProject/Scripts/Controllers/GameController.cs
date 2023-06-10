using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_IOS
using Unity.Advertisement.IosSupport;
#endif


public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public UseProfile useProfile;
    // public MusicManager musicManager;

    protected void Awake()
    {
        Instance = this;
        Init();
        DontDestroyOnLoad(this);

        //GameController.Instance.useProfile.IsRemoveAds = true;
    }

    private void Start()
    {
        //musicManager.PlayBGMusic();
    }

    public void Init()
    {
        Application.targetFrameRate = 60;
        //useProfile.IsRemoveAds = true;
        useProfile.CurrentLevelPlay = UseProfile.CurrentLevel;
    }

    public void LoadScene(string sceneName)
    {
    }

    public static void SetUserProperties()
    {
        // if (UseProfile.IsFirstTimeInstall)
        // {
        //     UseProfile.FirstTimeOpenGame = UnbiasedTime.Instance.Now();
        //     UseProfile.LastTimeOpenGame = UseProfile.FirstTimeOpenGame;
        //     UseProfile.IsFirstTimeInstall = false;
        // }
        //
        // var lastTimeOpen = UseProfile.LastTimeOpenGame;
        // UseProfile.RetentionD = (UseProfile.FirstTimeOpenGame - UnbiasedTime.Instance.Now()).Days;
        //
        // var dayPlayerd = (TimeManager.ParseTimeStartDay(UnbiasedTime.Instance.Now()) -
        //                   TimeManager.ParseTimeStartDay(UseProfile.LastTimeOpenGame)).Days;
        // if (dayPlayerd >= 1)
        // {
        //     UseProfile.LastTimeOpenGame = UnbiasedTime.Instance.Now();
        //     UseProfile.DaysPlayed++;
        // }
    }
}