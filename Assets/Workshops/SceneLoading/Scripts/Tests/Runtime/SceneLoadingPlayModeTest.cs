using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using System.Linq;

#if UNITY_EDITOR
using UnityEditor;
#endif //UNITY_EDITOR

public class SceneLoadingPlayModeTest : IPrebuildSetup, IPostBuildCleanup
{
    private const float DelayForSetupTime = 1f;
    private EditorBuildSettingsScene[] _editorBuildSettingsSceneBackup;

    private string[] _sceneNamesToAdd = new[]
    {
        $"Assets//Workshops/SceneLoading/Scenes/{SceneLoadingPlayModeTest.Scene01_Hero}.unity",
        $"Assets/Workshops/SceneLoading/Scenes/{SceneLoadingPlayModeTest.Scene02_House}.unity",
    };

    private const string HeroPrefabPath = "Prefabs/Hero";
    private const string HousePrefabPath = "Prefabs/House";

    public void Setup()
    {
        _editorBuildSettingsSceneBackup = EditorBuildSettings.scenes;

        for (int i = 0; i < _sceneNamesToAdd.Length; i++)
        {
            var newScene = new EditorBuildSettingsScene(_sceneNamesToAdd[i], true);
            var newScenes = EditorBuildSettings.scenes.Append(newScene).ToArray();
            EditorBuildSettings.scenes = newScenes;
            Debug.Log($"Adding EditorBuildSettings.Scenes. Count = {EditorBuildSettings.scenes.Length}");
        }
    }

    public void Cleanup()
    {
        EditorBuildSettings.scenes = _editorBuildSettingsSceneBackup;
        Debug.Log($"Removing EditorBuildSettings.Scenes. Count = {EditorBuildSettings.scenes.Length}");
    }

    private bool _isSceneLoaded = false;
    public static readonly string Scene01_Hero = "Scene01_Hero";
    public static readonly string Scene02_House = "Scene02_House";

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _isSceneLoaded = false;
    }

    [UnityTest]
    public IEnumerator Scene01_Hero_HeroIsNotNull_WhenSceneLoaded()
    {
        // Arrange
        SceneManager.sceneLoaded += (scene, mode) => { _isSceneLoaded = true; };
        SceneManager.LoadScene(Scene01_Hero, LoadSceneMode.Single);
        
        // Await
        yield return new WaitForSeconds(1f);

        // Assert
        GameObject go = Resources.Load<GameObject>(HeroPrefabPath);
        var hero = go.GetComponent<Hero>();

        // Assert
        Assert.That(hero, Is.Not.Null);
    }

    [UnityTest]
    public IEnumerator Scene01_Hero_ThrowsNoException_WhenSceneLoadedFor05Seconds()
    {
        // Arrange
        SceneManager.sceneLoaded += (scene, mode) => { _isSceneLoaded = true; };
        
        // Act
        Assert.DoesNotThrow(() =>
        {
            SceneManager.LoadScene(Scene01_Hero, LoadSceneMode.Single);
            while (!_isSceneLoaded && Time.realtimeSinceStartup < DelayForSetupTime)
            {
                // Wait for scene to load
            }
        });

        yield return null;
    }

    [UnityTest]
    public IEnumerator Scene02_House_HouseIsNotNull_WhenSceneLoaded()
    {
        // Arrange
        SceneManager.sceneLoaded += (scene, mode) => { _isSceneLoaded = true; };
        SceneManager.LoadScene(Scene02_House, LoadSceneMode.Single);

        // Await
        yield return new WaitForSeconds(1f);

        // Assert
        GameObject go = Resources.Load<GameObject>(HousePrefabPath);
        var house = go.GetComponent<House>();

        // Assert
        Assert.That(house, Is.Not.Null);
    }

    [UnityTest]
    public IEnumerator Scene02_House_SceneIsNotNull_WhenSceneLoaded()
    {
        // Arrange
        SceneManager.sceneLoaded += (scene, mode) => { _isSceneLoaded = true; };
        SceneManager.LoadScene(Scene02_House, LoadSceneMode.Single);

        // Act 
        yield return new WaitForSeconds(1f);

        // Assert
        Scene scene = SceneManager.GetSceneByName(Scene02_House);
        Assert.That(scene, Is.Not.Null);
    }

    [UnityTest]
    public IEnumerator Scene02_House_HouseRigidBodyIsNotNull_WhenSceneLoaded()
    {
        // Arrange
        SceneManager.sceneLoaded += (scene, mode) => { _isSceneLoaded = true; };
        SceneManager.LoadScene(Scene02_House, LoadSceneMode.Single);

        // Act
        GameObject go = Resources.Load<GameObject>(HousePrefabPath);
        var house = go.GetComponent<House>();
        var rigidbody = house.GetComponent<Rigidbody>();

        // Assert
        Assert.That(rigidbody, Is.Not.Null);

        yield return null;
    }
}
