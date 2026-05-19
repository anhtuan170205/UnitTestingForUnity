using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HouseLoadingPlayModeTest
{
    private const string HousePrefabPath = "Prefabs/House";

    private House _house;

    [SetUp]
    public void SetUp()
    {
        var prefab = Resources.Load<GameObject>(HousePrefabPath);

        GameObject go = GameObject.Instantiate(prefab, new Vector3(0, 0, 10), new Quaternion(0, 180, 0, 0));
        _house = go.GetComponent<House>();
    }

    [TearDown]
    public void TearDown()
    {
        if (_house != null)
        {
            Object.DestroyImmediate(_house.gameObject);
            _house = null;
        }
    }

    [Test]
    public void House_HouseIsNotNull_WhenPrefabInstantiated()
    {
        // Arrange

        // Act

        // Assert
        Assert.That(_house, Is.Not.Null);
    }

    [Test]
    public void House_GameObjectIsNotNull_WhenPrefabInstantiated()
    {
        // Arrange

        // Act

        // Assert
        Assert.That(_house.gameObject, Is.Not.Null);
    }

    [Test]
    public void House_NameIsSet_WhenPrefabInstantiated()
    {
        // Arrange

        // Act

        // Assert
        Assert.That(_house.Name, Is.EqualTo("House"));
    }

    [Test]
    public void House_NumberOfRoomsIsSet_WhenPrefabInstantiated()
    {
        // Arrange

        // Act

        // Assert
        Assert.That(_house.NumberOfRooms, Is.EqualTo(3));
    }

    [Test]
    public void House_RigidBodyIsNotNull_WhenPrefabInstantiated()
    {
        // Arrange

        // Act

        // Assert
        Assert.That(_house.Rigidbody, Is.Not.Null);
    }

    [Test]
    public void House_BoxColliderIsNotNull_WhenPrefabInstantiated()
    {
        // Arrange

        // Act

        // Assert
        Assert.That(_house.BoxCollider, Is.Not.Null);
    }
}
