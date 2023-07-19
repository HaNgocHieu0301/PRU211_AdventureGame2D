using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    private float currentHealth;
    private Animator anim;
    private bool dead = false;

    public HealthBarEnemy HealthBar;

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
                if (GetComponentInParent<EnemyPatrol>() != null)
                    GetComponentInParent<EnemyPatrol>().enabled = false;
                if(GetComponent<MeleeEnemy>() != null)
                    GetComponent<MeleeEnemy>().enabled = false;
                dead = true;
                if (gameObject.name == "GolemEnemy")
                {
                    //StartCoroutine("WinGame");
                    UIGamePlay.Instance.Win();
                    SceneManager.LoadScene("EndGame");
                }
            }
        }
    }

    public IEnumerator WinGame()
    {
        Debug.LogError("Win Game");
        yield return new WaitForSeconds(2f);
        //Enemy
        if (GetComponentInParent<EnemyPatrol>() != null)
            GetComponentInParent<EnemyPatrol>().enabled = false;
        if(GetComponent<MeleeEnemy>() != null)
            GetComponent<MeleeEnemy>().enabled = false;
        dead = true;
        yield return new WaitForSeconds(2f);
        UIGamePlay.Instance.Win();
        SceneManager.LoadScene("EndGame");
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
