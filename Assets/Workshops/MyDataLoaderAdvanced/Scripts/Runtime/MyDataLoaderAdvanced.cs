using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using System.Threading.Tasks;

public class StringUnityEvent : UnityEvent<string> {}

public interface INetworkService
{
    Task<string> LoadAsync(string url);
}

public class UnityWebRequestNetworkService : INetworkService
{
    public async Task<string> LoadAsync(string url)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        await www.SendWebRequest();
        return www.downloadHandler.text;
    }
}

public class MyDataLoaderAdvanced : MonoBehaviour
{
    private INetworkService _networkService;

    public StringUnityEvent OnLoaded = new StringUnityEvent();

    public bool IsLoaded
    {
        get { return Result != string.Empty; }
    }

    public string Result { get; private set; } = string.Empty;

    private void Awake()
    {
        if (_networkService == null)
        {
            _networkService = new UnityWebRequestNetworkService();
        }
    }

    public void Initialize(INetworkService networkService)
    {
        Result = string.Empty;
        _networkService = networkService;
    }

    public async Task LoadAsync(string url)
    {
        if (string.IsNullOrEmpty(url))
        {
            throw new ArgumentException("Invalid URL");
        }

        Result = string.Empty;
        Result = await _networkService.LoadAsync(url);
        OnLoaded.Invoke(Result);
    }
}