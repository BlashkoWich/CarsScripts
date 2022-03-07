using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionReplay : MonoBehaviour
{
    private bool isInReplayMode;
    private Rigidbody rb;
    public List<Vector3> actionReplayRecords = new List<Vector3>();
    private float currentReplayIndex;
    public static bool activateReplay = false;
    public static bool activateRecordTransform = false;
    private bool dontActivateReplay = false;

    private float timerActivateResult = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (activateReplay == true && dontActivateReplay == false || Input.GetKeyDown(KeyCode.R))
        {
            dontActivateReplay = true;
            if (isInReplayMode)
            {

                rb.isKinematic = true;
            }
            else
            {

                rb.isKinematic = false;
            }
        }

    }

    private void FixedUpdate()
    {
        if (activateRecordTransform == true && activateReplay == false)
        {
            actionReplayRecords.Add(transform.position);
            currentReplayIndex = 0;
        }
        else if(activateReplay == true)
        {
            Time.timeScale = 0.3f;
            currentReplayIndex++;
            transform.position = actionReplayRecords[(int)currentReplayIndex];
            timerActivateResult += Time.fixedDeltaTime;
            Debug.Log(timerActivateResult);
            if (timerActivateResult > 2)
            {
                UIScript.activateResult = true;
            }
        }
    }
}
