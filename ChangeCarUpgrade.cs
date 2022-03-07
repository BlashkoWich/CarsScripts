using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCarUpgrade : MonoBehaviour
{
    [SerializeField] GameObject[] LeftUpperWheels;
    [SerializeField] GameObject[] LeftDownWheels;
    [SerializeField] GameObject[] RightUpperWheels;
    [SerializeField] GameObject[] RightDownWheels;

    [SerializeField] SpriteRenderer[] graffiti;
    [SerializeField] Material[] graffitiFullMaterial;

    [SerializeField] GameObject ForLittleGraffiti;
    [SerializeField] MeshRenderer MeshNoGraffiti;
    [SerializeField] GameObject ForFullGraffiti;
    [SerializeField] MeshRenderer MeshFullGraffiti;

    private int littleGraffitiLength;

    public int wheelAmt;
    public int graffitiAmt;
    public int colorAmt;

    public string colorId;

    public bool swap = false;
    private void Start()
    {

        
    }

    public void SwipeUpgrade()
    {
        GraffitiSwap();
        ColorSwap();
        WheelSwap();
    }
    private void Update()
    {

    }
    private void GraffitiSwap()
    {
        for (int i = 0; i < graffiti.Length; i++)
        {

            if(i == graffitiAmt)
            {
                graffiti[i].enabled = true;
                    if (i <= 4)
                    {
                        ForFullGraffiti.SetActive(false);
                        ForLittleGraffiti.SetActive(true);
                    }
                    else
                    {

                        ForLittleGraffiti.SetActive(false);
                        ForFullGraffiti.SetActive(true);
                        for (int y = 0; y < MeshFullGraffiti.materials.Length; y++)
                        {
                        littleGraffitiLength = graffiti.Length - graffitiFullMaterial.Length;
                        MeshFullGraffiti.materials[y].CopyPropertiesFromMaterial(graffitiFullMaterial[i - littleGraffitiLength]);

                        }
                    }
                
            }
            else
            {
                graffiti[i].enabled = false;
            }

        }
    }

    private void WheelSwap()
    {

            for (int i = 0; i < LeftUpperWheels.Length; i++)
            {
                if (i == wheelAmt)
                {

                    LeftUpperWheels[i].SetActive(true);
                    LeftDownWheels[i].SetActive(true);
                    RightDownWheels[i].SetActive(true);
                    RightUpperWheels[i].SetActive(true);
                }
                else 
                {

                    LeftUpperWheels[i].SetActive(false);
                    LeftDownWheels[i].SetActive(false);
                    RightDownWheels[i].SetActive(false);
                    RightUpperWheels[i].SetActive(false);
                }
            }
    }

    private void ColorSwap()
    {
        for (int i = 0; i < MeshNoGraffiti.materials.Length; i++)
        {
            Color color1 = new Color();
            ColorUtility.TryParseHtmlString(colorId, out color1);
            MeshNoGraffiti.materials[i].color = color1;
        }
    }
}
