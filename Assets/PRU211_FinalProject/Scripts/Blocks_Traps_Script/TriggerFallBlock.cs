using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class TriggerFallBlock : MonoBehaviour
{
    public enum TriggerType
    {
        FallingBlock,
        MovementUpDownBlock
    }

    public TriggerType typeBlock;

    [ShowIf("@typeBlock == TriggerType.FallingBlock")]
    public GameObject fallObject;

    [ShowIf("@typeBlock == TriggerType.MovementUpDownBlock")]
    public GameObject upDownObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (typeBlock == TriggerType.FallingBlock)
        {
            if (other.CompareTag("Player"))
            {
                fallObject.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
            }
        }
        else if (typeBlock == TriggerType.MovementUpDownBlock)
        {
            if (other.CompareTag("Player"))
            {
                upDownObject.GetComponent<UpDown>().ContinuousMoving();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (typeBlock == TriggerType.MovementUpDownBlock)
        {
            if (other.CompareTag("Player"))
            {
                upDownObject.GetComponent<UpDown>().PauseMoving();
            }
        }
    }
}