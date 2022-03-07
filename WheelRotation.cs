using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{

    private void FixedUpdate() 
    {
        Quaternion rotationX = Quaternion.AngleAxis(8f, new Vector3(1, 0, 0));
        transform.rotation *= rotationX;
    }

}
