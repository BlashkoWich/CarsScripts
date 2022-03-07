using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultFinish : MonoBehaviour
{
    public static int[] results;
    private List<int> distribution;
    private void Start()
    {
        results = new int[GenerateRoad.countPlayers];
        distribution = new List<int>();
        for (int i = 0; i < results.Length; i++)
        {
            distribution.Add(i + 1);
        }
      
        for (int i = 0; i < results.Length; i++)
        {
            int deleteEl = 0;
            if (distribution.Count > 1) deleteEl = Random.Range(distribution[0], distribution.Count);
            else if(distribution.Count <= 1) deleteEl = 0;
            results[i] = distribution[deleteEl];
            distribution.RemoveAt(deleteEl);
        }
       
    }
}
