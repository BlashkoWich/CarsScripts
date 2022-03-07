using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    private int speed = 0;
    private int handicapSpeedBoost = 0;
    private int handicapSpeedBrake = 0;
    private int minSpeed = 7;
    private int maxSpeed = 40;
    private float timeSpeedAmt = 15f;
    private bool changeSpeed;
    
    private Rigidbody rb;

    private void Start()
    {
        changeSpeed = true;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(changeSpeed == true) StartCoroutine(SpeedAmt());
        rb.velocity = new Vector3(speed, 0, 0);
    }

    IEnumerator SpeedAmt()
    {
        changeSpeed = false;
        speed = Random.Range(20, 30);
        speed += handicapSpeedBoost;
        speed -= handicapSpeedBrake;
        speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
        yield return new WaitForSeconds(timeSpeedAmt);
        changeSpeed = true;
    }

    public void HandicapSpeedBrake()
    {
        handicapSpeedBrake = 0;
        handicapSpeedBrake = Random.Range(10, 15);
    }
    public void HandicapSpeedBoost()
    {
        handicapSpeedBrake = 0;
        handicapSpeedBoost = Random.Range(10, 15);
    }
}
