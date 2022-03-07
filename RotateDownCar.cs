using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDownCar : MonoBehaviour
{
    private void FixedUpdate()
    {
        Quaternion rotationZ = Quaternion.AngleAxis(0.1f, new Vector3(0, 0, -1));
        transform.rotation *= rotationZ;
    }
}
