using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterAttack : MonoBehaviour
{
    //public bool pressMouse;
    [SerializeField] private float attackCoolDown;
    [SerializeField] private float shootCoolDown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    private Animator anim;
    private MainCharaterBehavior mainCharaterBehavior;
    public float coolDownTimer = Mathf.Infinity;
    private float shootCoolDownTimer = Mathf.Infinity;

    [SerializeField]
    private BoxCollider2D boxCollider;
    [SerializeField]
    private float range;
    [SerializeField]
    private LayerMask playerLayer;
    private HealthEnemy enemyHealth;
    [SerializeField]
    private int damge;
    [SerializeField]
    private float colliderDistance;
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

        if (Input.GetKeyDown(KeyCode.X) && shootCoolDownTimer >= shootCoolDown && mainCharaterBehavior.canAttack())
        {
            Shoot();
        }
        coolDownTimer += Time.deltaTime;
        shootCoolDownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        coolDownTimer = 0;
    }

    private void Shoot()
    {
        anim.SetTrigger("shoot");
        shootCoolDownTimer = 0;
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

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);
        if (hit.collider != null)
            enemyHealth = hit.transform.GetComponent<HealthEnemy>();
        return hit.collider != null;
    }

    private void DamgagePlayer()
    {
        if (PlayerInSight())
        {
            enemyHealth.TakeDamage(damge);
        }
    }
}
