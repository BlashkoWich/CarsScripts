using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsInst : MonoBehaviour
{
    [SerializeField] public Material[] materials;

    public static MaterialsInst instance;

    private void Awake()
    {
        instance = this;
    }
}
