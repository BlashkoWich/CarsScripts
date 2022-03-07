using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDevice : MonoBehaviour
{
    [SerializeField] private GameObject vertical;
    [SerializeField] private GameObject horizontal;

    public static bool isVerticalMode;


    void Update()
    {
        if (Screen.width < Screen.height)
        {
            horizontal.SetActive(false);
            vertical.SetActive(true);
            isVerticalMode = true;
        }
        else
        {
            horizontal.SetActive(true);
            vertical.SetActive(false);
            isVerticalMode = false;
        }
              
    }
}
