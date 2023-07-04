using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    [SerializeField]
    private float attackCooldown;
    [SerializeField]
    private float range;
    [SerializeField]
    private float colliderDistance;
    [SerializeField]
    private int damge;
    [SerializeField]
    private BoxCollider2D boxCollider;
    [SerializeField]
    private LayerMask playerLayer;
    private float cooldownTimer = 0;
    private Animator anim;
    private HealthEnemy playerHealth;
    private EnemyPatrol enemyPatrol;

    [SerializeField]
    private Transform firepoint;
    [SerializeField]
    private GameObject[] fireballs;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("RangedAttack");
            }
        }

        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }
    }
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);
        //if (hit.collider != null)
        //    playerHealth = hit.transform.GetComponent<Health>();
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
    private void RangedAttack()
    {
        cooldownTimer = 0;
        fireballs[FindFireBal()].transform.position = firepoint.position;
        fireballs[FindFireBal()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }
    private int FindFireBal()
    {
        for(int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }    
}
