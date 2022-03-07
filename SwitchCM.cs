using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCM : MonoBehaviour
{
    [SerializeField] GameObject Cam5Players;
    [SerializeField] GameObject CamFinish;

    private void Start()
    {
        CamFinish.SetActive(false);
    }
    private void FixedUpdate()
    {

    }

    public void SwitchCam()
    {
        Cam5Players.SetActive(false);
        CamFinish.SetActive(true);
    }
}
