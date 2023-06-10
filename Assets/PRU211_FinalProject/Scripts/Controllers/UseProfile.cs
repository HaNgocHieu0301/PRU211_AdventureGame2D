using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class UseProfile : MonoBehaviour
{
    public static int CurrentLevel
    {
        get
        {
            return PlayerPrefs.GetInt(StringHelper.CURRENT_LEVEL, 1);
        }
        set
        {
            PlayerPrefs.SetInt(StringHelper.CURRENT_LEVEL, value);
            PlayerPrefs.Save();
        }
    }
    public int CurrentLevelPlay
    {
        get
        {
            return PlayerPrefs.GetInt(StringHelper.CURRENT_LEVEL_PLAY, 1);
        }
        set
        {
            PlayerPrefs.SetInt(StringHelper.CURRENT_LEVEL_PLAY, value);
            PlayerPrefs.Save();
        }
    }
    
    public static bool IsFirstTimeInstall
    {
        get
        {
            return PlayerPrefs.GetInt(StringHelper.FIRST_TIME_INSTALL, 1) == 1;
        }
        set
        {
            PlayerPrefs.SetInt(StringHelper.FIRST_TIME_INSTALL, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

    public static int DaysPlayed
    {
        get
        {
            return PlayerPrefs.GetInt(StringHelper.DAYS_PLAYED, 1);
        }
        set
        {
            PlayerPrefs.SetInt(StringHelper.DAYS_PLAYED, value);
            PlayerPrefs.Save();
        }
    }

    #region unnecessary
    // public bool IsRemoveAds
    // {
    //     get
    //     {
    //         return PlayerPrefs.GetInt(StringHelper.REMOVE_ADS, 0) == 1;
    //     }
    //     set
    //     {
    //         PlayerPrefs.SetInt(StringHelper.REMOVE_ADS, value ? 1 : 0);
    //         PlayerPrefs.Save();
    //     }
    // }
    //
    // public bool OnSound
    // {
    //     get
    //     {
    //         return PlayerPrefs.GetInt(StringHelper.ONOFF_SOUND, 1) == 1;
    //     }
    //     set
    //     {
    //         PlayerPrefs.SetInt(StringHelper.ONOFF_SOUND, value ? 1 : 0);
    //         GameController.Instance.musicManager.SetSoundVolume(value ? 1 : 0);
    //         PlayerPrefs.Save();
    //     }
    // }
    //
    // public bool OnMusic
    // {
    //     get
    //     {
    //         return PlayerPrefs.GetInt(StringHelper.ONOFF_MUSIC, 1) == 1;
    //     }
    //     set
    //     {
    //         PlayerPrefs.SetInt(StringHelper.ONOFF_MUSIC, value ? 1 : 0);
    //         GameController.Instance.musicManager.SetMusicVolume(value ? 0.7f : 0);
    //         PlayerPrefs.Save();
    //     }
    // }
    
    // public bool OnVibration
    // {
    //     get
    //     {
    //         return PlayerPrefs.GetInt(StringHelper.ONOFF_VIBRATION, 1) == 1;
    //     }
    //     set
    //     {
    //         PlayerPrefs.SetInt(StringHelper.ONOFF_VIBRATION, value ? 1 : 0);
    //         PlayerPrefs.Save();
    //     }
    // }
    
    // public static int RetentionD
    // {
    //     get
    //     {
    //         return PlayerPrefs.GetInt(StringHelper.RETENTION_D, 0);
    //     }
    //     set
    //     {
    //         if (value < 0)
    //             value = 0;
    //
    //         PlayerPrefs.SetInt(StringHelper.RETENTION_D, value);
    //         PlayerPrefs.Save();
    //     }
    // }
    
    // public static int PayingType
    // {
    //     get
    //     {
    //         return PlayerPrefs.GetInt(StringHelper.PAYING_TYPE, 0);
    //     }
    //     set
    //     {
    //         PlayerPrefs.SetInt(StringHelper.PAYING_TYPE, value);
    //         PlayerPrefs.Save();
    //     }
    // }
    
    // public static DateTime FirstTimeOpenGame
    // {
    //     get
    //     {
    //         if (PlayerPrefs.HasKey(StringHelper.FIRST_TIME_OPEN_GAME))
    //         {
    //             var temp = Convert.ToInt64(PlayerPrefs.GetString(StringHelper.FIRST_TIME_OPEN_GAME));
    //             return DateTime.FromBinary(temp);
    //         }
    //         else
    //         {
    //             // var newDateTime = UnbiasedTime.Instance.Now().AddDays(-1);
    //             PlayerPrefs.SetString(StringHelper.FIRST_TIME_OPEN_GAME, newDateTime.ToBinary().ToString());
    //             PlayerPrefs.Save();
    //             return newDateTime;
    //         }
    //     }
    //     set
    //     {
    //         PlayerPrefs.SetString(StringHelper.FIRST_TIME_OPEN_GAME, value.ToBinary().ToString());
    //         PlayerPrefs.Save();
    //     }
    // }
    // public static DateTime LastTimeOpenGame
    // {
    //     get
    //     {
    //         if (PlayerPrefs.HasKey(StringHelper.LAST_TIME_OPEN_GAME))
    //         {
    //             var temp = Convert.ToInt64(PlayerPrefs.GetString(StringHelper.LAST_TIME_OPEN_GAME));
    //             return DateTime.FromBinary(temp);
    //         }
    //         else
    //         {
    //             var newDateTime = UnbiasedTime.Instance.Now().AddDays(-1);
    //             PlayerPrefs.SetString(StringHelper.LAST_TIME_OPEN_GAME, newDateTime.ToBinary().ToString());
    //             PlayerPrefs.Save();
    //             return newDateTime;
    //         }
    //     }
    //     set
    //     {
    //         PlayerPrefs.SetString(StringHelper.LAST_TIME_OPEN_GAME, value.ToBinary().ToString());
    //         PlayerPrefs.Save();
    //     }
    // }
    //
    //
    // public static bool CanShowRate
    // {
    //     get { return PlayerPrefs.GetInt(StringHelper.CAN_SHOW_RATE, 1) == 1; }
    //     set
    //     {
    //         PlayerPrefs.SetInt(StringHelper.CAN_SHOW_RATE, value ? 1 : 0);
    //         PlayerPrefs.Save();
    //     }
    // }
    //
    // public bool IsTutedReturn
    // {
    //     get { return PlayerPrefs.GetInt(StringHelper.IS_TUTED_RETURN, 0) == 1; }
    //     set
    //     {
    //         PlayerPrefs.SetInt(StringHelper.IS_TUTED_RETURN, value ? 1 : 0);
    //         PlayerPrefs.Save();
    //     }
    // }
    //
    // public int CurrentNumReturn
    // {
    //     get
    //     {
    //         return PlayerPrefs.GetInt(StringHelper.CURRENT_NUM_RETURN,
    //             RemoteConfigController.GetIntConfig(FirebaseConfig.DEFAULT_NUM_RETURN, 2));
    //     }
    //     set
    //     {
    //         PlayerPrefs.SetInt(StringHelper.CURRENT_NUM_RETURN, value);
    //         PlayerPrefs.Save();
    //     }
    // }
    //
    // public bool IsTutedBuyStand
    // {
    //     get { return PlayerPrefs.GetInt(StringHelper.IS_TUTED_BUY_STAND, 0) == 1; }
    //     set
    //     {
    //         PlayerPrefs.SetInt(StringHelper.IS_TUTED_BUY_STAND, value ? 1 : 0);
    //         PlayerPrefs.Save();
    //     }
    // }
    #endregion
}

