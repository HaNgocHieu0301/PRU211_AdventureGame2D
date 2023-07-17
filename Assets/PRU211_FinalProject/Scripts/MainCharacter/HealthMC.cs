using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMC : MonoBehaviour
{
    //Max Health
    public float maxHealth;
    public float currentHealth;
    private Animator anim;
    private MainCharaterBehavior behavior;

    private bool dead;
    public AudioSource audio_death;
    public AudioSource audio_main;
    public AudioSource audio_hurt;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
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
        Debug.Log(_damage);
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, maxHealth);
        if (currentHealth > 0)
        {
            audio_hurt.Play();
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
                audio_main.Stop();
                audio_death.Play();
                anim.SetTrigger("die");
                behavior.enabled = false;
                GetComponent<MainCharacterAttack>().enabled = false;
                dead = true;
                UIGamePlay.Instance.losePanel.SetActive(true);
            }
        }
    }
}