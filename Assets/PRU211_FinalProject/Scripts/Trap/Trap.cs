using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public enum TrapType
    {
        Bomb,
        FireAndNormalTrap,
        ShooterSpear,
        FallingBlockWithTrigger,
        MovementUpDownBlockWithTrigger,
        SawTrap,
    }

    public TrapType trapType;
    public int damage = 50;

    [ShowIf("@trapType == TrapType.FallingBlockWithTrigger")]
    public GameObject fallObject;

    [ShowIf("@trapType == TrapType.MovementUpDownBlockWithTrigger")]
    public GameObject upDownObject;

    public bool isPlayerInTrap = false;
    public bool isCoroutineRunning = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            isPlayerInTrap = true;
            HealthMC healthScript = other.collider.GetComponent<HealthMC>();
            if (trapType == TrapType.Bomb)
            {
                // other.collider.gameObject.GetComponent
                GetComponent<Animator>().SetTrigger("Explosion");
                healthScript.TakeDamage(damage);
            }
            else if (trapType == TrapType.FallingBlockWithTrigger)
            {
                healthScript.TakeDamage(damage);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player") && !isCoroutineRunning)
        {
            HealthMC healthScript = other.collider.GetComponent<HealthMC>();
            if (trapType == TrapType.SawTrap || trapType == TrapType.ShooterSpear)
            {
                Debug.LogError("Dap trap " + other.collider.gameObject);
                StartCoroutine(DamageOverTime(healthScript));
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            if (trapType == TrapType.SawTrap)
            {
                isPlayerInTrap = false;
            }

            isCoroutineRunning = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (trapType == TrapType.FallingBlockWithTrigger)
            {
                fallObject.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
            }
            else if (trapType == TrapType.MovementUpDownBlockWithTrigger)
            {
                upDownObject.GetComponent<UpDown>().ContinuousMoving();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") || !isCoroutineRunning)
        {
            HealthMC healthScript = other.GetComponent<HealthMC>();
            if (trapType == TrapType.FireAndNormalTrap)
            {
                StartCoroutine(DamageOverTime(healthScript));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (trapType == TrapType.MovementUpDownBlockWithTrigger)
            {
                upDownObject.GetComponent<UpDown>().PauseMoving();
            }
            else if (trapType == TrapType.FireAndNormalTrap)
            {
                isPlayerInTrap = false;
            }
            isCoroutineRunning = false;
        }
    }

    public void DestroyTrap()
    {
        Destroy(this.gameObject);
    }

    public IEnumerator DamageOverTime(HealthMC healthScript)
    {
        isCoroutineRunning = true;
        while (isPlayerInTrap)
        {
            healthScript.TakeDamage(damage);
            yield return new WaitForSeconds(1f);
        }

        isCoroutineRunning = false;
    }
}