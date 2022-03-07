using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class HttpRequest : MonoBehaviour
{
    [SerializeField] private string url;
    [SerializeField] private int thisPlayer;

    [SerializeField] private LoadScript loadScript;
    [SerializeField] private NewControllerPlayer controllerPlayer;

    [SerializeField] TextMeshPro playerNickName;


    public static Response carCfg;

    private void Start()
    {
        StartCoroutine(SendRequest());
    }

    private IEnumerator SendRequest()
    {
       
        UnityWebRequest request = UnityWebRequest.Get("http://game-dev.ceant.net/race/2");

        //Debug.Log("реквест отправлен");

        yield return request.SendWebRequest();

        //Debug.Log(request.downloadHandler.text);
        //Debug.Log("реквест получен");

        string json = "{\"posts\":" + request.downloadHandler.text + "}";

        carCfg = JsonUtility.FromJson<Response>(json);

       loadScript.thisPlayer = carCfg.posts.Length;

        if (thisPlayer > carCfg.posts.Length - 1) yield break;
        else
        {
            //Debug.Log("CarId: " + carCfg.posts[thisPlayer].car.id);
            loadScript.thisPlayer = thisPlayer;
            loadScript.thisCarId = carCfg.posts[thisPlayer].car.id;
            controllerPlayer.playerPlace = carCfg.posts[thisPlayer].place;
            for (int i = 0; i < carCfg.posts.Length; i++)
            {
                if(carCfg.posts[thisPlayer].place == i)
                {
                    TablePlayerFinish.instance.playerName[i].text = carCfg.posts[thisPlayer].place.ToString();
                    TablePlayerFinish.instance.verticalPlayerName[i].text = carCfg.posts[thisPlayer].place.ToString();
                    
                }
            }
           
            loadScript.graffitiAmt = carCfg.posts[thisPlayer].car.graffitiId;
            loadScript.wheelAmt = carCfg.posts[thisPlayer].car.rimsId;
            loadScript.colorId = carCfg.posts[thisPlayer].car.colorId;

            playerNickName.text = carCfg.posts[thisPlayer].player.name;

            loadScript.startLoad = true;
        }

    }

    private IEnumerator SendRequestTest()
    {
        UnityWebRequest request = UnityWebRequest.Get(this.url);

        //Debug.Log("реквест отправлен");

        yield return request.SendWebRequest();
        Debug.Log(request.downloadHandler.text);
        //Debug.Log("реквест получен");

        string json = "{\"posts\":" + request.downloadHandler.text + "}";

        carCfg = JsonUtility.FromJson<Response>(json);

       Debug.Log("ColorId: " + carCfg.posts[thisPlayer].car.colorId);

    }
}
