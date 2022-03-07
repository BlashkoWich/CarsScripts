using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotationZ : MonoBehaviour
{
    private void FixedUpdate()
    {
        Quaternion rotationZ = Quaternion.AngleAxis(8f, new Vector3(0, 0, 1));
        transform.rotation *= rotationZ;
    }
}
