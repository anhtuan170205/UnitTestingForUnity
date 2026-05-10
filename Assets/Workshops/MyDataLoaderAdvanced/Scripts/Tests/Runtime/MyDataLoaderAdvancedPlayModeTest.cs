using System.Collections;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MyDataLoaderAdvancedPlayModeTest
{
    private const string _url = "https://anhtuan-dev.vercel.app";

    [UnityTest]
    public IEnumerator LoadAsync_ResultContainsDOCTYPE_WhenIsLoaded()
    {
        async Task Run()
        {
            // Arrange
            string expectedResult = "DOCTYPE";

            UnityWebRequestNetworkService networkService = new UnityWebRequestNetworkService();
            MyDataLoaderAdvanced myDataLoader = new MyDataLoaderAdvanced();
            myDataLoader.Initialize(networkService);

            string result = "";

            myDataLoader.OnLoaded.AddListener((string data) =>
            {
                result = data;
            });

            // Act
            await myDataLoader.LoadAsync(_url);

            // Assert
            Assert.That(result.Contains(expectedResult), Is.True);
        }

        yield return Run().AsCoroutine();
    }
}