using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 3);
    }
    private void Update()
    {
        if(ActionReplay.activateReplay == true) Destroy(gameObject);
    }

}
