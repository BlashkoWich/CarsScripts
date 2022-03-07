using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewControllerPlayer : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject backTraceSpawnPoint;
    [SerializeField] private GameObject backTraceGO;

    [SerializeField] GameObject backfire;
    private bool bacfireActivate;

    private float expectedSpeed;
    private float speed;

    private int handicapBoost;
    private int handicapBrake;

    private bool changeSpeedActivate;
    private bool isFinishWay;

    private float timeRace;

    private bool dontChangeSpeed;

    public static int minSpeed = 34;
    public static int maxSpeed = 42;

    public static float minSpeedStart = 30;
    public static float maxSpeedStart = 35;

    public static float towardSpeed = 0.2f;

    float timerForBoostEffect = 0;
    float timerLimitForBoostEffect;

    public int playerPlace;

    private Rigidbody rb;
    public PlayerInfo player;
    private MeshRenderer meshRenderer;
    private void Start()
    {
        timerLimitForBoostEffect = Random.Range(3f, 6f);
        dontChangeSpeed = false;
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
        //Instantiate(player.modelCar, spawnPoint.transform);

        isFinishWay = false;
        expectedSpeed = Random.Range(minSpeed, maxSpeed);
        rb = GetComponent<Rigidbody>();
        changeSpeedActivate = true;
    }

    private void FixedUpdate()
    {


        ActivateBackFire();
        
        if (StartTimer.readyToPlay == false) return;

        timeRace += Time.fixedDeltaTime;
        

        if (isFinishWay == false)expectedSpeed = Random.Range(minSpeed, maxSpeed);
        speed = Mathf.MoveTowards(speed, expectedSpeed, towardSpeed);
        rb.velocity = new Vector3(speed, 0, 0);

        if (expectedSpeed == CameraLookObj.speedCameraLookObj && changeSpeedActivate == true && isFinishWay == false && dontChangeSpeed == false) StartCoroutine(ChangeSpeed());
    }

    public void InstantiateCar(GameObject car)
    {
        Instantiate(car, spawnPoint.transform.position, Quaternion.Euler(-90, 90, 0), this.gameObject.transform);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Middle") && isFinishWay == false && dontChangeSpeed == false)
        {
            expectedSpeed = Random.Range(minSpeed, maxSpeed);
            handicapBoost = 0;
            handicapBrake = 0;
            StartCoroutine(DontChangeSpeed());
        }
        if (other.CompareTag("Finish"))
        {
            Debug.Log(player.playerName);
            if (playerPlace == GenerateRoad.countPlayers - 1)
            {
                Debug.Log("replay");
                ActionReplay.activateReplay = true;
            }
            for (int i = 0; i < TablePlayerFinish.instance.playerTime.Length; i++)
            {
                if(TablePlayerFinish.instance.playerTime[i].text == "X")
                {
                    TablePlayerFinish.instance.playerTime[i].text = timeRace.ToString();
                    TablePlayerFinish.instance.verticalPlayerTime[i].text = timeRace.ToString();
                    return;
                }
            }
            
        }

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Low") && isFinishWay == false && dontChangeSpeed == false)
        {
            handicapBoost = Random.Range(3, 5);
            handicapBrake = 0;
            expectedSpeed += handicapBoost;
            StartCoroutine(DontChangeSpeed());
            
        }
        if (other.CompareTag("Middle") && isFinishWay == false && dontChangeSpeed == false)
        {
            expectedSpeed = Random.Range(minSpeed, maxSpeed);
            handicapBoost = 0;
            handicapBrake = 0;
            StartCoroutine(DontChangeSpeed());
        }
        if (other.CompareTag("Highest") && isFinishWay == false && dontChangeSpeed == false)
        {
            handicapBoost = 0;
            handicapBrake = Random.Range(3, 5);
            expectedSpeed -= handicapBrake;
            StartCoroutine(DontChangeSpeed());
        }
        if (other.CompareTag("HighestNoWay") && isFinishWay == false && dontChangeSpeed == false)
        {
            handicapBrake = 0;
            handicapBoost = 0;
            expectedSpeed = minSpeed;
            StartCoroutine(DontChangeSpeed());
        }
        if (other.CompareTag("LowestNoWay") && isFinishWay == false && dontChangeSpeed == false)
        {
            handicapBoost = 0;
            handicapBrake = 0;
            expectedSpeed = maxSpeed;
            StartCoroutine(DontChangeSpeed());

        }
        if (other.CompareTag("FinishWay"))
        {
            isFinishWay = true;
            towardSpeed = 100;
            bacfireActivate = true;
            for (int i = 0; i < GenerateRoad.countPlayers; i++)
            {
                if(playerPlace == i)
                {
                    expectedSpeed = maxSpeed - i * 2;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
    }
    IEnumerator ChangeSpeed()
    {
        changeSpeedActivate = false;
        expectedSpeed = Random.Range(minSpeed, maxSpeed);
        yield return new WaitForSeconds(2);
        changeSpeedActivate = true;
    }
    IEnumerator DontChangeSpeed()
    {
        dontChangeSpeed = true;
        yield return new WaitForSeconds(3);
        if(isFinishWay == false) expectedSpeed = CameraLookObj.expectedSpeedCameraLookObj;
        yield return new WaitForSeconds(2);
        dontChangeSpeed = false;
    }    

    private void ActivateBackFire()
    {
        if (bacfireActivate == false && timerForBoostEffect > timerLimitForBoostEffect)
        {
            bacfireActivate = true;
            backfire.SetActive(true);
            timerForBoostEffect = 0;
        }
        else if (bacfireActivate == true && timerForBoostEffect > timerLimitForBoostEffect / 2)
        {
            bacfireActivate = false;
            backfire.SetActive(false);
            timerForBoostEffect = 0;
        }
        timerForBoostEffect += Time.deltaTime;
    }
}
