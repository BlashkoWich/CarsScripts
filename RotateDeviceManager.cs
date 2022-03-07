using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDeviceManager : MonoBehaviour
{
    [SerializeField] GameObject[] cameras;
    private List<GameObject> camerasList = new List<GameObject>();
    private int thisCam;

    [SerializeField] GameObject horizontalPanel;
    [SerializeField] GameObject verticalPanel;

    public static bool isHorizontal;
    public static bool isVertical;

    public static RotateDeviceManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].SetActive(false);
            if (i > GenerateRoad.countPlayers)
            {
                Destroy(cameras[i]);
            }
            if (i <= GenerateRoad.countPlayers) camerasList.Add(cameras[i]);
        }
        cameras[0].SetActive(true);
        thisCam = 0;
    }

    private void Update()
    {
        if (Screen.width < Screen.height)
        {
            horizontalPanel.SetActive(false);
            verticalPanel.SetActive(true);
            CinemachineCamScript.isVerticalMode = true;
            CinemachineCamScript.selectView = 3;
            isHorizontal = false;
            isVertical = true;
        }
        else
        {
            isVertical = true;
            isHorizontal = false;
            if(CinemachineCamScript.isFinish == false)
            {
                CinemachineCamScript.isVerticalMode = false;
                horizontalPanel.SetActive(true);
                verticalPanel.SetActive(false);
                thisCam = 0;
                for (int i = 0; i < camerasList.Count; i++)
                {
                    if (i == thisCam)
                        camerasList[i].SetActive(true);
                    else camerasList[i].SetActive(false);
                }
            }
        }
    }
    public void NextCam()
    {
        if (thisCam == camerasList.Count - 1) thisCam = 0;
        else thisCam++;
        for (int i = 0; i < camerasList.Count; i++)
        {
            if (i == thisCam)
                camerasList[i].SetActive(true);
            else camerasList[i].SetActive(false);
        }
    }
    public void PreviousCam()
    {
        if (thisCam == 0) thisCam = camerasList.Count - 1;
        else thisCam--;
        for (int i = 0; i < camerasList.Count; i++)
        {
            if (i == thisCam)
                camerasList[i].SetActive(true);
            else camerasList[i].SetActive(false);
        }
    }

    public void OffAllPlayerCams()
    {
        for (int i = 0; i < camerasList.Count; i++)
        {
            camerasList[i].SetActive(false);
        }
    }
}
