using System;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.1f;
    public Vector3 offset;
    private Vector3 velocity;
    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position,desiredPosition + offset,ref velocity, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
