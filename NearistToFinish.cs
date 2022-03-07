using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearistToFinish : MonoBehaviour
{
    private GameObject[] players;
    [SerializeField] Transform finish;

    public static Vector3 nearestPlayer;

    private float[] distance;
    private float minDistance;
    private bool count;

    private void Start()
    {
        count = false;
       StartCoroutine(afterStart());
    }

    private void FixedUpdate()
    {
        if (!count) return;
        for (int i = 0; i < players.Length; i++)
        {
            //distance[i] = finish.position.x - players[i].transform.position.x;
        }
        minDistance = Mathf.Min(distance);
        for (int i = 0; i < distance.Length; i++)
        {
            if (minDistance == distance[i] && players[i] != null)
            {
                nearestPlayer = players[i].transform.position;
            }

        }
    }

    IEnumerator afterStart()
    {
        yield return new WaitForSeconds(10);
        players = GameObject.FindGameObjectsWithTag("Player");
        distance = new float[GenerateRoad.countPlayers];
        count = true;
    }
}
