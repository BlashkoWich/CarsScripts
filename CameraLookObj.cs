using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookObj : MonoBehaviour
{
    [SerializeField] GameObject Cam5Players;
    [SerializeField] GameObject CamFinish;

    float countToReplay = 0;

    public static float speedCameraLookObj;
   public static float expectedSpeedCameraLookObj;

    public static bool isStart = false;

    private Rigidbody rb;

    private float positionZ;

    public static Vector3 thisPosition;

    private void Start()
    {
        speedCameraLookObj = 0;
        rb = GetComponent<Rigidbody>();
       
    }
    private void Update()
    {
        if (isStart == false) return;

        positionZ = (GenerateRoad.firstPlayerPosition.z + GenerateRoad.lastPlayerPosition.z) / 2;
        gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, positionZ);
        thisPosition = this.transform.position;

        isStart = false;
    }
    private void FixedUpdate()
    {
        if (StartTimer.readyToPlay == false) return;
        speedCameraLookObj = (NewControllerPlayer.minSpeed + NewControllerPlayer.maxSpeed) / 2;
        expectedSpeedCameraLookObj = Mathf.MoveTowards(expectedSpeedCameraLookObj, speedCameraLookObj, NewControllerPlayer.towardSpeed);
        rb.velocity = new Vector3(expectedSpeedCameraLookObj, 0, 0);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("FinishWay"))
        {
            Cam5Players.SetActive(false);
            CamFinish.SetActive(true);
            countToReplay += Time.deltaTime;
            if (countToReplay > 15)
            {
                ActionReplay.activateRecordTransform = true;
            }
            /*if (countToReplay > 27)
            {
                ActionReplay.activateReplay = true;
            }*/
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinishWay"))
        {
            transform.position = Vector3.MoveTowards(transform.position, NearistToFinish.nearestPlayer, 10000f);
            
        }
    }
    private void OnTriggerExit(Collider other)
    {

    }
}
