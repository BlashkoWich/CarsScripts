using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectUpgradeCar : MonoBehaviour
{
    [SerializeField] Sprite[] graffiti;
    [SerializeField] MeshFilter[] wheel;

    public static int selectWheel = -1;
    public static Sprite selectGraffiti;

    public static bool selectGraffitiEnabled = false;

    public static SelectUpgradeCar instance;


    public void SelectGraffiti(int value)
    {
        selectGraffitiEnabled = true;
        for (int i = 0; i < graffiti.Length; i++)
        {
            if(value == i)
            {
                selectGraffiti = graffiti[i];
            }
        }
    }
    public void SelectWheel(int value)
    {
        selectWheel = value;
    }
}
