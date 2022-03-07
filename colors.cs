using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colors : MonoBehaviour
{
    [SerializeField] public Material[] materials;

    public static colors instance;

    private void Awake()
    {
        instance = this;
    }
}
