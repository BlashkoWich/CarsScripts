using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] GameObject[] redTrafickLight;
    [SerializeField] GameObject[] greenTrafickLight;
    [SerializeField] GameObject TrafickLightBackgroundHorizontal;
    [SerializeField] GameObject TrafickLightBackgroundVertical;
    private float timerTime = 3;
    public static bool readyToPlay;

    private void Start()
    {
        readyToPlay = false;
    }

    private void FixedUpdate()
    {
        if (StartRaceScript.readyPlayer.Count != GenerateRoad.countPlayers) return;
        if (readyToPlay) return;
        timerTime -= Time.deltaTime;
        timer.text = Mathf.Round(timerTime).ToString();
        if (timerTime < 3)
        {
            redTrafickLight[0].SetActive(false);
           greenTrafickLight[0].SetActive(true);
        }
        if(timerTime < 2)
        {
            redTrafickLight[1].SetActive(false);
            greenTrafickLight[1].SetActive(true);
        }
        if (timerTime < 0.3f)
        {
            redTrafickLight[2].SetActive(false);
            greenTrafickLight[2].SetActive(true);
        }
        if (timerTime < 0)
        {
            for (int i = 0; i < redTrafickLight.Length; i++)
            {
                redTrafickLight[i].SetActive(false);
                greenTrafickLight[i].SetActive(false);
            }
            TrafickLightBackgroundHorizontal.SetActive(false);
            TrafickLightBackgroundVertical.SetActive(false);
            timer.enabled = false;
            readyToPlay = true;
        }
    }
}
