using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringHelper
{
    public const string ONOFF_SOUND = "ONOFF_SOUND";
    public const string ONOFF_MUSIC = "ONOFF_MUSIC";
    public const string ONOFF_VIBRATION = "ONOFF_VIBRATION";
    public const string FIRST_TIME_INSTALL = "FIRST_TIME_INSTALL";
   
    public const string REMOVE_ADS = "REMOVE_ADS";
    public const string CURRENT_LEVEL = "CURRENT_LEVEL";
    public const string CURRENT_LEVEL_PLAY = "CURRENT_LEVEL_PLAY";
    // public const string PATH_CONFIG_LEVEL = "Levels/Level_{0}";
    // public const string PATH_CONFIG_LEVEL_TEST = "LevelsTest/Level_{0}";

    public const string DAYS_PLAYED = "days_played";
    public const string LEVEL = "level";

    public const string LAST_TIME_OPEN_GAME = "LAST_TIME_OPEN_GAME";
    public const string FIRST_TIME_OPEN_GAME = "FIRST_TIME_OPEN_GAME";
}

public class PathPrefabs
{
    // public const string POPUP_REWARD_BASE = "UI/Popups/PopupRewardBase";
    // public const string CONFIRM_POPUP = "UI/Popups/ConfirmBox";
    // public const string WAITING_BOX = "UI/Popups/WaitingBox";
    // public const string WIN_BOX = "UI/Popups/WinBox";
    // public const string REWARD_IAP_BOX = "UI/RewardIAPBox";
    // public const string SHOP_BOX = "UI/ShopBox";
    // public const string RATE_GAME_BOX = "UI/Popups/RateGameBox";
    // public const string SETTING_BOX = "UI/Popups/SettingBox";
    // public const string LOSE_BOX = "UI/Popups/LoseBox";
}

public class SceneName
{
    // public const string LOADING_SCENE = "LoadingScene";
    // public const string HOME_SCENE = "HomeScene";
    // public const string GAME_PLAY = "GamePlay";
}

public class AudioName
{
    public const string bgMainHome = "Music_BG_MainHome";
    public const string bgGamePlay = "Music_BG_GamePlay";

    //Ingame music
    public const string winMusic = "winMusic";
    public const string spawnerPlayerMusic = "spawnerPlayer";

    //Action Player music
    public const string jumpMusic = "jump";
    public const string jumpEndMusic = "jumpEnd";
    public const string swapMusic = "swap";
    public const string pushRockMusic = "pushRock";
    public const string dieMusic = "die";
    public const string reviveMusic = "revive";
    public const string flyMusic = "fly";

    //Collect music
    public const string collectCoinMusic = "collectCoin";
    public const string collectKeyMusic = "collectKey";
    public const string collectItemSound = "collectItem";

    //Level music
    public const string jumpOnWaterMusic = "jumpOnWater";
    public const string collisionDoorMusic = "collisionDoor";
    public const string doorOpenMusic = "doorOpen";
    public const string doorCloseMusic = "doorClose";
    public const string springMusic = "spring";
    public const string touchSwitchMusic = "touchSwitch";
    public const string bridgeMoveMusic = "bridgeMove";
    public const string bridgeMoveEndMusic = "bridgeMoveEnd";
    public const string iceDropFall = "rock1";
    public const string iceDropExplosion = "bigrock";
    public const string activeDiamond = "crystalactive";
    public const string releaseDiamond = "crystalrelease";
    //UI Music
    public const string buttonClick = "buttonClick";
}

public class KeyPref
{
    public const int MAX_LEVEL = 100;
    public const string CURRENT_LEVEL = "CURRENT_LEVEL";
    public const string HIGHEST_LEVEL = "HIGHEST_LEVEL";
    public const string MONEY_KEY = "MONEY_KEY";
    public const string SERVER_INDEX = "SERVER_INDEX";
}
