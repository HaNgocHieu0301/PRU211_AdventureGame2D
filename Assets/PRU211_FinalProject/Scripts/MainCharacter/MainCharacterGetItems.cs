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
            Debug.LogError("An coin" + other.gameObject.name);
            Destroy(other.gameObject);
            UIGamePlay.Instance.score += 10;
            UIGamePlay.Instance.scoreText.text = ("Score: " + UIGamePlay.Instance.score);
        }
    }
}
