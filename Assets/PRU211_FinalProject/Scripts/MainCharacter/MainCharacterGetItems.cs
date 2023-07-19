using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterGetItems : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Debug.LogError("An coin 1" + other.gameObject.name);
            Destroy(other.gameObject);
            Debug.LogError("An coin 2" + other.gameObject.name);
            UIGamePlay.Instance.score += 10;
            Debug.LogError("An coin 3" + other.gameObject.name);
            UIGamePlay.Instance.scoreText.text = ("Score: " + UIGamePlay.Instance.score);
            Debug.LogError("An coin 4" + other.gameObject.name);
        }else 
        if (other.CompareTag("Key"))
        {
            PlayerPrefs.SetInt("Key", 1);
            Destroy(other.gameObject);
        }
    }
}
