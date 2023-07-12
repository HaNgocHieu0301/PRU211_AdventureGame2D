using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

public class GearMovement : MonoBehaviour
{
    public enum GearType
    {
        None,
        StraightYoyo,
        StraightLeft,
        StraightRight,
        RotateYoyo
    }

    public bool isRotate = true;
    
    public GearType gearType;
    [ShowIf("@gearType == GearType.StraightYoyo")]
    public Transform targetTrans;
    [ShowIf("@gearType == GearType.StraightYoyo")]
    public float duration;
    [ShowIf("@isRotate == true")]
    public float rotationSpeed = 1f;
    [HideIf("@gearType == GearType.StraightYoyo")]
    public float moveSpeed;
    [ShowIf("@isRotate == true")]
    public int rotationDirection = 1;
    
    
    private float targetAngle = 0f;
    private Rigidbody2D _rigid;
    public float amplitude = 1f;     // Độ lớn của đung đưa
    public float frequency = 1f;     // Tần số của đung đưa
    public float angleOffset = 0f;   // Góc pha ban đầu
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        if (gearType == GearType.StraightYoyo)
        {
            YoloMovement();
        }else if (gearType == GearType.StraightLeft)
        {
            _rigid.velocity = Vector2.left * moveSpeed;
        }else if (gearType == GearType.StraightRight)
        {
            _rigid.velocity = Vector2.right * moveSpeed;
        }else if (gearType == GearType.RotateYoyo)
        {
            StartCoroutine(ApplySwingForce());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotate == true)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * rotationDirection * Time.deltaTime);
        }
    }
    private void YoloMovement()
    {
        transform.DOMoveX(targetTrans.position.x, duration)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo)
            .OnStepComplete(() =>
            {
                rotationDirection *= -1;
            });
    }
    private IEnumerator ApplySwingForce()
    {
        while (true)
        {
            // Tính toán góc xoay dựa trên thời gian
            float angle = amplitude * Mathf.Sin(2f * Mathf.PI * frequency * Time.time + angleOffset);

            // Áp dụng góc xoay cho vật
            transform.rotation = Quaternion.Euler(0f, 0f, angle);

            yield return null;
        }
    }
}
