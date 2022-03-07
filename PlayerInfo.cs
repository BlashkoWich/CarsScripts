using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "ScriptableObject/PlayerInfo ", order = 0)]
public class PlayerInfo : ScriptableObject
{
    [SerializeField] public string playerName;
    public GameObject modelCar;
}
