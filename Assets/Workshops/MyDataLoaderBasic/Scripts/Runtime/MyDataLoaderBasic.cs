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
}
