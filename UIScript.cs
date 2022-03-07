using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField] Slider distanceToFinishSlider;
    [SerializeField] Slider distanceToFinishVerticalSlider;
    [SerializeField] Transform cameraLookObj;
    [SerializeField] Transform finish;

    [SerializeField] GameObject MainPanel;
    [SerializeField] GameObject verticalMainPanel;
    [SerializeField] GameObject ReplayPanel;
    [SerializeField] GameObject ResultPanel;
    [SerializeField] GameObject verticalResultPanel;

    public static bool activateResult = false;
    private void Start()
    {
        distanceToFinishSlider.maxValue = 0;
        distanceToFinishSlider.minValue = -(finish.position.x - cameraLookObj.position.x);
        distanceToFinishVerticalSlider.maxValue = 0;
        distanceToFinishVerticalSlider.minValue = -(finish.position.x - cameraLookObj.position.x);
    }
    private void FixedUpdate()
    {
        if (RotateDeviceManager.isVertical == false)
        {
            MainPanel.SetActive(true);
            verticalMainPanel.SetActive(false);
        }
        else
        {
            MainPanel.SetActive(false);
            verticalMainPanel.SetActive(true);
        }
        distanceToFinishSlider.value = -(finish.position.x - cameraLookObj.position.x);
        distanceToFinishVerticalSlider.value = -(finish.position.x - cameraLookObj.position.x);
        ActivateReplay();
        if (activateResult)
        {
            ActivateResult();
        }
    }

    private void ActivateReplay()
    {
        if (ActionReplay.activateReplay == true)
        {
            verticalMainPanel.SetActive(false);
            MainPanel.SetActive(false);
            ReplayPanel.SetActive(true);
        }
    }
    private void ActivateResult()
    {
        ReplayPanel.SetActive(false);
        if (RotateDeviceManager.isVertical == false)
        {
            ResultPanel.SetActive(true);
            verticalResultPanel.SetActive(false);
        }
        else
        {
            ResultPanel.SetActive(false);
            verticalResultPanel.SetActive(true);
        }
    }
}
