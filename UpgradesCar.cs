using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradesCar : MonoBehaviour
{
    [SerializeField] GameObject[] horizontalGraffiti;
    [SerializeField] GameObject[] verticalGraffiti;
    [SerializeField] GameObject[] horizontalWheel;
    [SerializeField] GameObject[] verticalWheel;
    [SerializeField] TextMeshProUGUI horizontalEngineTxt;
    [SerializeField] TextMeshProUGUI horizontalTransmissionTxt;
    [SerializeField] TextMeshProUGUI horizontalGearboxTxt;
    [SerializeField] TextMeshProUGUI verticalEngineTxt;
    [SerializeField] TextMeshProUGUI verticalTransmissionTxt;
    [SerializeField] TextMeshProUGUI verticalGearboxTxt;

    int back;
    string backStr;
    private void Start()
    {
        for (int i = 0; i < horizontalGraffiti.Length; i++)
        {
            if (i == back)
            {
                horizontalGraffiti[i].SetActive(true);
                verticalGraffiti[i].SetActive(true);
            }
            else
            {
                horizontalGraffiti[i].SetActive(false);
                verticalGraffiti[i].SetActive(false);
            }
        }
        for (int i = 0; i < horizontalWheel.Length; i++)
        {
            if (i == back)
            {
                horizontalWheel[i].SetActive(true);
                verticalWheel[i].SetActive(true);
            }
            else
            {
                horizontalWheel[i].SetActive(false);
                verticalWheel[i].SetActive(false);
            }
        }
        verticalGearboxTxt.text = backStr;
        horizontalGearboxTxt.text = backStr;
        verticalTransmissionTxt.text = backStr;
        horizontalTransmissionTxt.text = backStr;
        verticalEngineTxt.text = backStr;
        horizontalEngineTxt.text = backStr;
    }
}
