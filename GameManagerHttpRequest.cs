using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class GameManagerHttpRequest : MonoBehaviour
{
    [SerializeField] private string url;
    public static Response carCfg;

    private void Start()
    {
        StartCoroutine(SendRequestTest());
    }

    private IEnumerator SendRequestTest()
    {
        UnityWebRequest request = UnityWebRequest.Get(this.url);

        //Debug.Log("реквест отправлен");

        yield return request.SendWebRequest();
        //Debug.Log(request.downloadHandler.text);
        //Debug.Log("реквест получен");

        string json = "{\"posts\":" + request.downloadHandler.text + "}";

        carCfg = JsonUtility.FromJson<Response>(json);

        GenerateRoad.countPlayers = carCfg.posts.Length;
        CinemachineCamScript.start = true;
        GenerateRoad.startGenerate = true;
    }
}
