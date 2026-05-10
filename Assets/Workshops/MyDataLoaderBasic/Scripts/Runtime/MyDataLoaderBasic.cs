using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using System.Threading.Tasks;

public class StringUnityEvent : UnityEvent<string>{}
public class MyDataLoaderBasic : MonoBehaviour
{
    public StringUnityEvent OnLoaded = new StringUnityEvent();

    public string Result { get; private set; }
    public bool IsLoaded { get { return Result != string.Empty ; }}

    public MyDataLoaderBasic()
    {
        Result = string.Empty;
    }

    public async Task LoadAsync(string url)
    {
        if (string.IsNullOrEmpty(url))
        {
            throw new ArgumentException();
        }
        Result = string.Empty;
        UnityWebRequest www = UnityWebRequest.Get(url);
        await www.SendWebRequest();
        Result = www.downloadHandler.text;
        OnLoaded.Invoke(Result);
    }

    public async Task LoadImage(string url)
    {
        if (string.IsNullOrEmpty(url))
        {
            throw new ArgumentException();
        }

        Result = string.Empty;

        UnityWebRequest www = UnityWebRequest.Get(url);
        www.SetRequestHeader("User-Agent", "Mozilla/5.0");

        await www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            throw new Exception($"Request failed: {www.error}");
        }

        Texture2D texture = new Texture2D(2, 2);
        bool loaded = texture.LoadImage(www.downloadHandler.data);

        if (!loaded)
        {
            throw new Exception("Downloaded data is not a valid JPG/PNG image.");
        }

        Result = texture.GetType().Name;
        OnLoaded.Invoke(Result);
    }
}
