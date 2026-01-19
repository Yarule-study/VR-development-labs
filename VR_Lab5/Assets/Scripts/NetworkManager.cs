using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class CatData
{
    public string id;
    public string url;
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        string newJson = "{ \"items\": " + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.items;
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] items;
    }
}

public class NetworkManager : MonoBehaviour
{
    [Header("UI Output")]
    public RawImage catImageDisplay;
    public TextMeshProUGUI statusText;

    private string url = "https://api.thecatapi.com/v1/images/search?mime_types=jpg,png";
    private string apiKey = "live_bo7436O0NHdWlcKWiiye4gJd5uol20C94kGGueSW4dworuquwIrMYlXwgxmfM354";

    public void GetRandomCat()
    {
        StartCoroutine(FetchCatData());
    }

    IEnumerator FetchCatData()
    {
        statusText.text = "Запит до сервера...";
        
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            request.SetRequestHeader("x-api-key", apiKey);
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                statusText.text = "Помилка API: " + request.error;
            }
            else
            {
                CatData[] cats = JsonHelper.FromJson<CatData>(request.downloadHandler.text);
                if (cats.Length > 0)
                {
                    StartCoroutine(DownloadImage(cats[0].url));
                }
            }
        }
    }

    IEnumerator DownloadImage(string imageUrl)
    {
        statusText.text = "Завантаження картинки...";
        
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageUrl))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                statusText.text = "Помилка фото: " + request.error;
            }
            else
            {
                catImageDisplay.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
                statusText.text = "Кота отримано!";
            }
        }
    }
}