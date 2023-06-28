using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    private float currentHealth;
    private Animator anim;
    private bool dead = false;

    public HealthBar HealthBar;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        HealthBar.SetHealth(currentHealth, startingHealth);  
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        HealthBar.SetHealth(currentHealth, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
            //iframes
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("Die");
                //Player
                //GetComponent<PlayerMovement>().enabled = false;

                //Enemy
                if (GetComponentInParent<EnemyPatrol>() != null)
                    GetComponentInParent<EnemyPatrol>().enabled = false;
                if(GetComponent<MeleeEnemy>() != null)
                    GetComponent<MeleeEnemy>().enabled = false;
                dead = true;
            }
        }
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) {
            TakeDamage(1);
        }
    }
    public void DeactiveEnemy()
    {
        gameObject.SetActive(false);
    }
}
