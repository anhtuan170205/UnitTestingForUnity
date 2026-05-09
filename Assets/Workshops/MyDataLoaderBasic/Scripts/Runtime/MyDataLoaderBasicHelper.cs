using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;

public class MyDataLoaderBasicHelper : INotifyCompletion
{
    private UnityWebRequestAsyncOperation asyncOp;
    private Action continuation;

    public MyDataLoaderBasicHelper(UnityWebRequestAsyncOperation asyncOp)
    {
        this.asyncOp = asyncOp;
        asyncOp.completed += OnRequestCompleted;
    }

    public bool IsCompleted
    {
        get { return asyncOp.isDone; }
    }

    public void GetResult()
    {
    }

    public void OnCompleted(Action continuation)
    {
        this.continuation = continuation;
    }

    private void OnRequestCompleted(AsyncOperation obj)
    {
        continuation();
    }
}

public static class ExtensionMethods
{
    public static MyDataLoaderBasicHelper GetAwaiter(this UnityWebRequestAsyncOperation asyncOp)
    {
        return new MyDataLoaderBasicHelper(asyncOp);
    }
}