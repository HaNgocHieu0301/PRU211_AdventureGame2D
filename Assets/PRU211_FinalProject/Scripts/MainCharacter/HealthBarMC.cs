using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarMC : MonoBehaviour
{
    [SerializeField] private HealthMC playerHealth;
    [SerializeField] private Image totalHealthbar;
    [SerializeField] private Image currentHealthbar;
    // Start is called before the first frame update
    void Start()
    {
        totalHealthbar.fillAmount = playerHealth.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthbar.fillAmount = playerHealth.currentHealth / playerHealth.maxHealth;
    }
}
