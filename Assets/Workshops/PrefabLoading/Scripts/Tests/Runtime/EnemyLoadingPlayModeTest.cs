using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemyLoadingPlayModeTest
{
    private const string EnemyPrefabPath = "Prefabs/Enemy";

    private Enemy _enemy;

    [SetUp]
    public void SetUp()
    {
        var prefab = Resources.Load<GameObject>(EnemyPrefabPath);

        GameObject go = GameObject.Instantiate(prefab, new Vector3(0, 0, 10), new Quaternion(0, 180, 0, 0));
        _enemy = go.GetComponent<Enemy>();
    }

    [TearDown]
    public void TearDown()
    {
        if (_enemy != null)
        {
            Object.DestroyImmediate(_enemy.gameObject);
            _enemy = null;
        }
    }

    [Test]
    public void Enemy_EnemyIsNotNull_WhenPrefabInstantiated()
    {
        // Arrange

        // Act

        // Assert
        Assert.That(_enemy, Is.Not.Null);
    }

    [Test]
    public void Enemy_GameObjectIsNotNull_WhenPrefabInstantiated()
    {
        // Arrange

        // Act

        // Assert
        Assert.That(_enemy.gameObject, Is.Not.Null);
    }

    [Test]
    public void Enemy_RigidBodyIsNotNull_WhenPrefabInstantiated()
    {
        // Arrange

        // Act

        // Assert
        Assert.That(_enemy.Rigidbody, Is.Not.Null);
    }
}
