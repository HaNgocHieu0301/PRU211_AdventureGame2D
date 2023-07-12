using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_CameraFollow : MonoBehaviour
{
    public Transform target; // Đối tượng để camera theo dõi
    public float smoothSpeed = 0.125f; // Tốc độ di chuyển của camera
    public Vector3 offset; // Vị trí tương đối của camera so với target

    private Vector3 initialPosition; // Vị trí ban đầu của camera

    public bool Init()
    {
        GameObject player = FindObjectOfType<MainCharaterBehavior>().gameObject;
        target = player.transform;
        initialPosition = transform.position;
        return true;
    }

    private void LateUpdate()
    {
        if (Init())
        {
            Vector3 desiredPosition = target.position + offset;
            desiredPosition.z = initialPosition.z; // Giữ nguyên giá trị trục Z của camera
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;   
        }
    }
}
