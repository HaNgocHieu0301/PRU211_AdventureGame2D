using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities.Editor;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource audio_main;
    public AudioSource audio_player_death;
    public AudioSource audio_player_hurt;
    public AudioSource audio_player_attack;
    public AudioSource audio_player_shoot;
    public AudioSource audio_player_jump;
    public AudioSource audio_player_run;
    public AudioSource audio_enemy_sword;
    public AudioSource audio_enemy_fireball;
    public AudioSource audio_win;
    public AudioSource audio_lose;
    public AudioSource audio_decide;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
}
