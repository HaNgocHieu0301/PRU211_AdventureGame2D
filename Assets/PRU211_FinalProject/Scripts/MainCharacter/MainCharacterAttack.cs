using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterAttack : MonoBehaviour
{
    //public bool pressMouse;
    [SerializeField] private float attackCoolDown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    private Animator anim;
    private MainCharaterBehavior mainCharaterBehavior;
    private float coolDownTimer = Mathf.Infinity;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        mainCharaterBehavior = GetComponent<MainCharaterBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && coolDownTimer >= attackCoolDown && mainCharaterBehavior.canAttack())
        {
            Attack();
        }
        //coolDownTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.X) && coolDownTimer >= attackCoolDown && mainCharaterBehavior.canAttack())
        {
            Shoot();
        }
        coolDownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
    }

    private void Shoot()
    {
        anim.SetTrigger("shoot");
        coolDownTimer = 0;

        //int num = FindFireBall();
        fireballs[FindFireBall()].transform.position = firePoint.position;
        fireballs[FindFireBall()].GetComponent<FireBall>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindFireBall()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
