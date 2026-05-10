using System;
using System.Collections;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public static class TaskExtensions
{
    public static IEnumerator AsIEnumerator(this Task task)
    {
        while (!task.IsCompleted) yield return null;
        task.GetAwaiter().GetResult();
    }
}

public class FakeNetworkService : INetworkService
{
    private readonly string _result;
    private readonly Exception _exception;

    public FakeNetworkService(string result)
    {
        _result = result;
    }

    public FakeNetworkService(Exception exception)
    {
        _exception = exception;
    }

    public Task<string> LoadAsync(string url)
    {
        if (_exception != null)
            return Task.FromException<string>(_exception);

        return Task.FromResult(_result);
    }
}

public class MyDataLoaderAdvancedTest
{
    private const string _url = "https://anhtuan-dev.vercel.app";
    private const string _urlInvalid = "";

    [UnityTest]
    public IEnumerator MockLoadAsync_ResultContainsMockedData_WhenIsLoaded()
    {
        // Arrange
        string expectedResult = "MockedData";

        var networkService = new FakeNetworkService(expectedResult);
        GameObject gameObject = new GameObject();
        var myDataLoader = gameObject.AddComponent<MyDataLoaderAdvanced>();

        myDataLoader.Initialize(networkService);

        bool eventCalled = false;

        myDataLoader.OnLoaded.AddListener((string result) =>
        {
            eventCalled = true;
            Assert.That(result.Contains(expectedResult), Is.True);
        });

        // Act
        yield return myDataLoader.LoadAsync(_url).AsIEnumerator();

        // Assert
        Assert.That(eventCalled, Is.True);
    }

    [UnityTest]
    public IEnumerator MockLoadAsync_ThrowsError_WhenUrlIsInvalid()
    {
        // Arrange
        var networkService = new FakeNetworkService(
            new Exception("Invalid URL")
        );

        GameObject gameObject = new GameObject();
        var myDataLoader = gameObject.AddComponent<MyDataLoaderAdvanced>();

        // Act
        var task = myDataLoader.LoadAsync(_urlInvalid);

        while (!task.IsCompleted)
            yield return null;

        // Assert
        Assert.That(task.IsFaulted, Is.True);
    }
}