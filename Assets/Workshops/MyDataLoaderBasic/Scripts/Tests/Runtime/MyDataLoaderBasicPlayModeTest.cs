using System.Collections;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MyDataLoaderBasicPlayModeTest
{
    private const string _url = "https://anhtuan-dev.vercel.app";
    private const string _imgUrl = "https://i.ibb.co/RpHxPhQL/homelanderisinnocent.jpg";

    [UnityTest]
    public IEnumerator LoadAsync_ResultContainsDOCTYPE_WhenIsLoaded()
    {
        yield return Run().AsCoroutine();

        async Task Run() 
        {
            // Arrange
            string expectedResult = "DOCTYPE";
            GameObject gameObject = new GameObject();
            MyDataLoaderBasic myDataLoader = gameObject.AddComponent<MyDataLoaderBasic>();

            string result = "";

            // Act
            myDataLoader.OnLoaded.AddListener((string data) => { result = data; });

            // Await
            await myDataLoader.LoadAsync(_url);

            // Assert
            Assert.That(result.Contains(expectedResult), Is.True);
        }
    }

    [UnityTest]
    public IEnumerator LoadImage_ResultIsImage_WhenIsLoaded()
    {
        yield return Run().AsCoroutine();

        async Task Run() 
        {
            // Arrange
            string expectedResult = "Texture2D";
            GameObject gameObject = new GameObject();
            MyDataLoaderBasic myDataLoader = gameObject.AddComponent<MyDataLoaderBasic>();

            string result = "";

            // Act
            myDataLoader.OnLoaded.AddListener((string data) => { result = data; });

            // Await
            await myDataLoader.LoadImage(_imgUrl);

            // Assert
            Assert.That(result.Contains(expectedResult), Is.True);
        }
    }
}
