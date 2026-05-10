using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Threading.Tasks;

public class MyDataLoaderBasicTest
{
    private const string _url = "https://anhtuan-dev.vercel.app";
    private const string _imgUrl = "https://i.ibb.co/RpHxPhQL/homelanderisinnocent.jpg";

    [Test]
    public async Task LoadAsync_ResultContainsDOCTYPE_WhenIsLoaded()
    {
        // Arrange
        string expectedResult = "DOCTYPE";
        GameObject gameObject = new GameObject();
        MyDataLoaderBasic myDataLoader = gameObject.AddComponent<MyDataLoaderBasic>();

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

    [Test]
    public async Task LoadImage_ResultIsTexture2D_WhenIsLoaded()
    {
        // Arrange
        GameObject gameObject = new GameObject();
        MyDataLoaderBasic myDataLoader = gameObject.AddComponent<MyDataLoaderBasic>();

        string result = "";

        myDataLoader.OnLoaded.AddListener((string data) =>
        {
            result = data;
        });

        // Act
        await myDataLoader.LoadImage(_imgUrl);

        // Assert
        Assert.That(result.Contains("Texture2D"), Is.True);
    }
}
