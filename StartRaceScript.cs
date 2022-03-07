using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRaceScript : MonoBehaviour
{
    public static List<int> readyPlayer;

    private bool isStart = false;
    private bool isStart1 = true;
    private void Awake()
    {
        readyPlayer = new List<int>();
        isStart = false;
        isStart1 = true;
    }
    // скрипт с активацие startTimer и находится на канвасе

    private void Update()
    {
        if (readyPlayer.Count == GenerateRoad.countPlayers) isStart = true;

        if (readyPlayer.Count == GenerateRoad.countPlayers && isStart1 == true && GenerateRoad.countPlayers != 0 && readyPlayer.Count != 0 && GenerateRoad.countPlayers != 0)
        {
            List<MeshRenderer> renderers = new List<MeshRenderer>();
            renderers.AddRange(GameObject.FindObjectsOfType<MeshRenderer>());
            for (int i = 0; i < renderers.Count; i++)
            {
                for (int y = 0; y < renderers[i].materials.Length; y++)
                {
                    if (renderers[i].materials[y].shader.name == "Standard")
                    {
                        renderers[i].materials[y].shader = Shader.Find("Standard");
                    }
                }
            }
            renderers.Clear();
            Debug.Log("Shader");
            isStart1 = false;
        }
    }
}
