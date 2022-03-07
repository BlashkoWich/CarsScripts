using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TablePlayerFinish : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI[] playerName;
    [SerializeField] public TextMeshProUGUI[] verticalPlayerName;
    [SerializeField] public TextMeshProUGUI[] playerTime;
    [SerializeField] public TextMeshProUGUI[] verticalPlayerTime;
    [SerializeField] TextMeshProUGUI[] countPlayers;
    [SerializeField] TextMeshProUGUI[] verticalCountPlayers;
    [SerializeField] LayoutGroup[] LayoutGroups;


    public static TablePlayerFinish instance;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        if (playerName.Length > GenerateRoad.countPlayers)
        {
            for (int i = 0; i < playerName.Length - GenerateRoad.countPlayers; i++)
            {
                Destroy(playerName[20 - 1 - i]);
                Destroy(verticalPlayerName[20 - 1 - i]);
                Destroy(playerTime[20 - 1 - i]);
                Destroy(verticalPlayerTime[20 - 1 - i]);
                Destroy(countPlayers[20 - 1 - i]);
                Destroy(verticalCountPlayers[20 - 1 - i]);
                StartCoroutine(UpdateLayout());
            }

        }
    }

    private void Update()
    {
        /*for (int i = 0; i < GenerateRoad.countPlayers; i++)
        {
            playerName[i].text = ResultFinish.results[i].ToString();
            verticalPlayerName[i].text = ResultFinish.results[i].ToString();
        }*/
    }
    IEnumerator UpdateLayout()
    {
        for (int i = 0; i < LayoutGroups.Length; i++)
        {
            LayoutGroups[i].enabled = false;
        }
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < LayoutGroups.Length; i++)
        {
            LayoutGroups[i].enabled = true;
        }
    }
}
