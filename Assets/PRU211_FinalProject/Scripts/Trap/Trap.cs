using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public enum TrapType {
        Bomb, 
        NormalTrap, 
        Fire, 
        ShooterSpear,         
        FallingBlockWithTrigger,
        MovementUpDownBlockWithTrigger,
        MovementTrap
    }
    public TrapType trapType;
    public int damage = 50;
    [ShowIf("@trapType == TrapType.FallingBlockWithTrigger")]
    public GameObject fallObject;

    [ShowIf("@trapType == TrapType.MovementUpDownBlockWithTrigger")]
    public GameObject upDownObject;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            HealthMC healthScript = other.collider.GetComponent<HealthMC>();
            if (trapType == TrapType.Bomb)
            {
                // other.collider.gameObject.GetComponent
                GetComponent<Animator>().SetTrigger("Explosion");
                healthScript.TakeDamage(damage);
            }else if (trapType == TrapType.Fire)
            {
                
            }   
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            HealthMC healthScript = other.collider.GetComponent<HealthMC>();
            if (trapType == TrapType.NormalTrap)
            {
                healthScript.TakeDamage(damage);
            }
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
        if (other.CompareTag("Player"))
        {
            HealthMC healthScript = other.GetComponent<HealthMC>();
             if (trapType == TrapType.Fire)
            {
                healthScript.TakeDamage(damage);
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
        }
    }

    public void DestroyTrap()
    {
        Destroy(gameObject);
    }
}
