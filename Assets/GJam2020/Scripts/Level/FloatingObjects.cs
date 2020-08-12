using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObjects : MonoBehaviour
{
    [SerializeField] private float factor;
    [SerializeField] private float speed;
    [SerializeField] private bool rotate;
    [SerializeField] private float rotateSpeed;
    void Update()
    {
        transform.position += new Vector3(0, Mathf.Sin(Time.time * speed) *0.001f * factor, 0);
        if (rotate)
        {
            transform.eulerAngles += new Vector3(0, rotateSpeed, 0);
        }
    }
}
