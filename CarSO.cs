using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CarConfig", menuName = "Cars/CarConfig ", order = 0)]

public class CarSO : ScriptableObject
{
    [SerializeField] public GameObject modelCar;
    [SerializeField] public float maxSpeed;
    [SerializeField] public float boost;
    [SerializeField] public int rare;
    [SerializeField] public string carName;
    
}
