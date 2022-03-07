using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelRotationY : MonoBehaviour
{
    private void FixedUpdate()
    {
        Quaternion rotationY = Quaternion.AngleAxis(8f, new Vector3(0, 1, 0));
        transform.rotation *= rotationY;
    }
}
