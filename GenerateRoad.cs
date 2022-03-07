using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRoad : MonoBehaviour
{
    public static int countPlayers;

    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject[] player;
    [SerializeField] private GameObject leftBoard;

    public static Vector3 lastPlayerPosition;
    public static Vector3 firstPlayerPosition;

    public static bool startGenerate;
    private void Start()
    {

    }

    private void Update()
    {
        if (startGenerate)
        {
            List<GameObject> playerList = new List<GameObject>(player.Length);
            for (int i = 0; i < player.Length; i++)
            {
                playerList.Add(player[i]);
            }

            for (int i = 0; i < countPlayers; i++)
            {
                //int randomPlayer = Random.Range(0, playerList.Count);
                Instantiate(playerList[i], spawnPoints[i].transform, false);
                //playerList.RemoveAt(randomPlayer);
                if (i == countPlayers - 1)
                {
                    Instantiate(leftBoard, spawnPoints[i].transform.position - new Vector3(10, 8.4f, -10.6f), Quaternion.Euler(0, 270, 0));
                    lastPlayerPosition = spawnPoints[i].transform.position;
                }
                if (i == 0) firstPlayerPosition = spawnPoints[i].transform.position;
                CameraLookObj.isStart = true;
            }
            startGenerate = false;
        }

    }
}
