using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    [SerializeField] public CarSO[] carConfig;
    [SerializeField] GameObject spawnPoint;
    //[SerializeField] GameObject mirrorSpawnPoint;


    private GameObject thisCarModel;
    private GameObject mirrorCarModel;
    public static int thisCarAmt;

    public static playerScript instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        spawnPoint.SetActive(false);
        thisCarAmt = Random.Range(0, carConfig.Length);
        InstantiateCar();
    
    }
    private void FixedUpdate()
    {
        Quaternion rotationPlayer = Quaternion.AngleAxis(0.03f, new Vector3(0, 0, 1));
        Quaternion rotationMirrorPlayer = Quaternion.AngleAxis(0.03f, new Vector3(0, 0, -1));
        thisCarModel.transform.rotation *= rotationPlayer;
        //mirrorCarModel.transform.rotation = Quaternion.Euler(-270, 0, thisCarModel.transform.rotation.z);
        //mirrorCarModel.transform.rotation *= rotationMirrorPlayer;
    }
    public void ActivateNextCar()
    {
        if(thisCarAmt != carConfig.Length - 1)
        {
            Destroy(thisCarModel);
            Destroy(mirrorCarModel);
            thisCarAmt += 1;
            InstantiateCar();

        }
        else if(thisCarAmt >= carConfig.Length - 1)
        {
            Destroy(thisCarModel);
            Destroy(mirrorCarModel);
            thisCarAmt = 0;
            InstantiateCar();

        }
    }

    public void ActivatePreviousCar()
    {
        if (thisCarAmt != 0)
        {
            Destroy(thisCarModel);
            Destroy(mirrorCarModel);
            thisCarAmt -= 1;
            InstantiateCar();

        }
        else if(thisCarAmt == 0)
        {
            Destroy (thisCarModel);
            Destroy(mirrorCarModel);
            thisCarAmt = carConfig.Length - 1;
            InstantiateCar();

        }
    }

    private void InstantiateCar()
    {
        thisCarModel = Instantiate(carConfig[thisCarAmt].modelCar, spawnPoint.transform.position, carConfig[thisCarAmt].modelCar.transform.rotation);
        //mirrorCarModel = Instantiate(carConfig[thisCarAmt].modelCar, mirrorSpawnPoint.transform.position, Quaternion.Euler(-270, 0 , -thisCarModel.transform.rotation.z - 180));
    }    
}
