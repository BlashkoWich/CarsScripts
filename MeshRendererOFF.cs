using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshRendererOFF : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }
}
