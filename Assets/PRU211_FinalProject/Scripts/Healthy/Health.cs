using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    public HealthBar HealthBar;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        HealthBar.SetHealth(currentHealth, startingHealth);
        TakeDamage(1);
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
                    GetComponent<MeleeEnemy>().enabled = true;
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
    }
}
