using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GJam2020.Avatar;

public class TrackingCamera : MonoBehaviour
{
    private Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void Start()
    {
        target = transform.parent.GetComponentInChildren<AvatarGeneralManager>().transform;
    }
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
