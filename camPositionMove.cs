using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camPositionMove : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(CameraLookObj.expectedSpeedCameraLookObj, 0, 0);
    }
}
