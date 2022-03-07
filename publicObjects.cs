using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class publicObjects : MonoBehaviour
{
    public Material[] mat;
    public static int selectMat;
    public static publicObjects instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        selectMat = Random.Range(0, mat.Length);
    }
}
