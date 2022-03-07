using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPlayer : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    private GameObject thisCarModel;
    private void Start()
    {
        //Instantiate(playerScript.carConfig[], thisCarModel.transform.position, new Quaternion(-360, Quaternion.identity.y, -360, 0));
    }
}
