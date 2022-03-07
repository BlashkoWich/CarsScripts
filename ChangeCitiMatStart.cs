using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCitiMatStart : MonoBehaviour
{
    private bool isReady = false;
    private void Update()
    {
        if (isReady == true) return;
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if(meshRenderer.materials.Length == 3)
        meshRenderer.materials[1].CopyPropertiesFromMaterial(publicObjects.instance.mat[publicObjects.selectMat]);
        else if(meshRenderer.materials.Length == 2)
            meshRenderer.materials[0].CopyPropertiesFromMaterial(publicObjects.instance.mat[publicObjects.selectMat]);
        isReady = true;

    }

}

