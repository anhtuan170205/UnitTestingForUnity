using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MyDataLoaderBasicTest
{
    private const string _url = "https://anhtuan-dev.vercel.app";

    [Test]
    public void LoadAsync_ResultContainsDOCTYPE_WhenIsLoaded()
    {
        // Arrange
        string expectedResult = "DOCTYPE";
        GameObject gameObject = new GameObject();
        MyDataLoaderBasic myDataLoader = gameObject.AddComponent<MyDataLoaderBasic>();

        myDataLoader.OnLoaded.AddListener((string result) =>
        {
            // Assert
            Assert.That(result.Contains(expectedResult), Is.True);
        });

        // Act
        myDataLoader.LoadAsync(_url);
    }
}
