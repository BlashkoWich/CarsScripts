using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Rigidbody rb;
    private float speed;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (CameraLookObj.expectedSpeedCameraLookObj != 0)
        {
            speed = Mathf.MoveTowards(speed, CameraLookObj.expectedSpeedCameraLookObj - 1, NewControllerPlayer.towardSpeed);

            rb.velocity = new Vector3(speed, 0, 0);
        }
    }
}
