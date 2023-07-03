using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMC : MonoBehaviour
{
    public float startingHealth;
    public float currentHealth;
    private Animator anim;
    public MainCharaterBehavior behavior;
    private bool dead;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        behavior = GetComponent<MainCharaterBehavior>();
        anim = GetComponent<Animator>();
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(1);
        }
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            if (behavior.onWall() && !behavior.isGrounded())
            {
                anim.SetTrigger("jump");
                anim.SetBool("grounded", !behavior.isGrounded());
            }
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                behavior.enabled = false;
                GetComponent<MainCharacterAttack>().enabled = false;
                dead = true;
            }
        }
    }
}
