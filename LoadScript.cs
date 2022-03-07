using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadScript : MonoBehaviour
{
    string bundleURL = $"https://game-dev.website/cars_race_assets/{0}";

    public NewControllerPlayer newControllerPlayer;

    public int thisPlayer;

    public int thisCarId;

    public bool startLoad = false;

    private int version = 0;

    public int graffitiAmt;
    public int wheelAmt;
    public string colorId;

    private void Update()
    {
        if (startLoad == true)
        {
            StartCoroutine(GetAssetBundle());
            startLoad = false;
        }
    }

    IEnumerator GetAssetBundle()
    {
        bundleURL = $"http://game-dev.website/cars_race_assets/{thisCarId}";
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(bundleURL);
        yield return www.SendWebRequest();

        /* if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }*/


        AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
        string carAssetName = $"{carName.carsName[thisCarId]}.prefab";
        var assetBundleGO = bundle.LoadAssetAsync(carAssetName);
        bundle.Unload(false);
        newControllerPlayer.InstantiateCar(assetBundleGO.asset as GameObject);
        ChangeCarUpgrade children = gameObject.GetComponentInChildren<ChangeCarUpgrade>();
        children.graffitiAmt = graffitiAmt;
        children.colorId = colorId;
        children.wheelAmt = wheelAmt;
        children.SwipeUpgrade();
        StartRaceScript.readyPlayer.Add(1);

    }

    IEnumerator DownloadAndCache()
    {

        bundleURL = $"https://game-dev.website/cars_race_assets/{thisCarId}";
        //Debug.Log(bundleURL);
        while (!Caching.ready) yield return null;
        var www = WWW.LoadFromCacheOrDownload(bundleURL, version);
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
            yield break;
        }
        var assetBundle = www.assetBundle;

        string carAssetName = $"{carName.carsName[thisCarId]}.prefab";

        var carRequest = assetBundle.LoadAssetAsync(carAssetName, typeof(GameObject));
        GameObject assetCar = carRequest.asset as GameObject;
        //assetCar.transform.rotation = Quaternion.Euler


        newControllerPlayer.InstantiateCar(assetCar);

        List<MeshRenderer> renderers = new List<MeshRenderer>();
        renderers.AddRange(GameObject.FindObjectsOfType<MeshRenderer>());
        for (int i = 0; i < renderers.Count; i++)
        {
            for (int y = 0; y < renderers[i].materials.Length; y++)
            {
                renderers[i].materials[y].shader = Shader.Find("Standard");
            }
        }
        renderers.Clear();

        assetBundle.Unload(false);
        //ChangeCarUpgrade carUpgrade;

        ChangeCarUpgrade children = gameObject.GetComponentInChildren<ChangeCarUpgrade>();
        children.graffitiAmt = graffitiAmt;
        children.colorId = colorId;
        children.wheelAmt = wheelAmt;
        StartRaceScript.readyPlayer.Add(1);
        children.SwipeUpgrade();

        //assetCar.GetComponent<ChangeCarUpgrade>().graffitiAmt = graffitiAmt;
        //assetCar.GetComponent<ChangeCarUpgrade>().colorId = colorId; 
        //assetCar.GetComponent<ChangeCarUpgrade>().wheelAmt = wheelAmt; 
        //assetCar.GetComponent<ChangeCarUpgrade>().SwipeUpgrade();

    }
}