using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineCamScript : MonoBehaviour
{
    CinemachineTransposer transp;

    Vector3 standartCamPosition;
    Vector3 backCamPosition = new Vector3(-9, 2.5f, 0);
    Vector3 rightPosition = new Vector3(0, 2, -9);
    public static int selectView;
    private bool readyForSwitch;
    public static bool isVerticalMode = false;
    public static bool isFinish;
    Vector3 startStandart = new Vector3(9, 3, -6);

    private bool isStart = false;
    public static bool start = false;

    void Start()
    {
        
    }

    private void Update()
    {
        if (start)
        {
            isFinish = false;
            readyForSwitch = false;
            standartCamPosition = new Vector3(9, 3, -3 - (3 * (GenerateRoad.countPlayers / 2)));
            rightPosition = new Vector3(0, 2.5f, 0 - (4.5f * (GenerateRoad.countPlayers / 2)));
            backCamPosition = new Vector3(-9 - (1.5f * (GenerateRoad.countPlayers / 2)), 8f, 0);
            var vcam = GetComponent<CinemachineVirtualCamera>();
            if (vcam != null)
                transp = vcam.GetCinemachineComponent<CinemachineTransposer>();
            StartCoroutine(SwitchViewCam());
            transp.m_FollowOffset = backCamPosition;
            isStart = true;
            //selectView = Random.Range(1, 4);
            isStart = true;
            start = false;
        }
    }
    private void FixedUpdate()
    {
        if (!isStart) return;
        if (CameraLookObj.speedCameraLookObj == NewControllerPlayer.maxSpeed)
        {
            isFinish = true;
            RotateDeviceManager.instance.OffAllPlayerCams();
        }
        if (readyForSwitch == true && isVerticalMode == false)
        {
            StartCoroutine(SwitchViewCam());
        }
        if(selectView == 1)
        {
            transp.m_FollowOffset = Vector3.MoveTowards(transp.m_FollowOffset, standartCamPosition, 0.2f);
        }
        if(selectView == 2)
        {
            transp.m_FollowOffset = Vector3.MoveTowards(transp.m_FollowOffset, backCamPosition, 0.2f);
        }
        if(selectView == 3)
        {
            transp.m_FollowOffset = Vector3.MoveTowards(transp.m_FollowOffset, rightPosition, 0.2f);
        }

    }

    IEnumerator SwitchViewCam()
    {
        readyForSwitch = false;
        yield return new WaitForSeconds(5);
        selectView = Random.Range (1, 4);
        readyForSwitch = true;
    }
}
