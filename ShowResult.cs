using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowResult : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] Places;


    private void Start()
    {
        for (int i = 0; i < ResultFinish.results.Length; i++)
        {
            Places[i].text = ResultFinish.results[i].ToString();
        }
        if(Places.Length > ResultFinish.results.Length)
        {
            int count = Places.Length - ResultFinish.results.Length;
            for (int i = Places.Length; i < count && i > 0; i--)
            {
                Destroy(Places[i]);
                Debug.Log("destroy");
            }
        }
    }
}
