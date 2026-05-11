using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CharacterBasicPlayModeTest
{
    private GameObject _testGameObject;
    private CharacterBasic _characterBasic;

    [SetUp]
    public void SetUp()
    {
        _testGameObject = new GameObject();
        _characterBasic = _testGameObject.AddComponent<CharacterBasic>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_testGameObject);
        _testGameObject = null;
        _characterBasic = null;
    }

    [Test]
    public void MoveByKeyCode_ResultMovesLeft_WhenMovesLeft()
    {
        // Arrange
        Vector3 initialPosition = _testGameObject.transform.position;
        Vector3 expectedPosition = initialPosition + new Vector3(-_characterBasic.Speed, 0, 0);

        // Act
        Vector3 newPosition = _characterBasic.MoveByKeyCode(CharacterBasic.MoveType.Left);

        // Assert
        Assert.AreEqual(expectedPosition, newPosition);
    }

    [Test]
    public void MoveByKeyCode_ResultMovesRight_WhenMovesRight()
    {
        // Arrange
        Vector3 initialPosition = _testGameObject.transform.position;
        Vector3 expectedPosition = initialPosition + new Vector3(_characterBasic.Speed, 0, 0);

        // Act
        Vector3 newPosition = _characterBasic.MoveByKeyCode(CharacterBasic.MoveType.Right);

        // Assert
        Assert.AreEqual(expectedPosition, newPosition);
    }

    [Test]
    public void MoveByKeyCode_ResultMovesUp_WhenMovesUp()
    {
        // Arrange
        Vector3 initialPosition = _testGameObject.transform.position;
        Vector3 expectedPosition = initialPosition + new Vector3(0, _characterBasic.Speed, 0);

        // Act
        Vector3 newPosition = _characterBasic.MoveByKeyCode(CharacterBasic.MoveType.Up);

        // Assert
        Assert.AreEqual(expectedPosition, newPosition);
    }

    [Test]
    public void MoveByKeyCode_ResultMovesDown_WhenMovesDown()
    {
        // Arrange
        Vector3 initialPosition = _testGameObject.transform.position;
        Vector3 expectedPosition = initialPosition + new Vector3(0, -_characterBasic.Speed, 0);

        // Act
        Vector3 newPosition = _characterBasic.MoveByKeyCode(CharacterBasic.MoveType.Down);

        // Assert
        Assert.AreEqual(expectedPosition, newPosition);
    }


    [Test]
    public void RotateByKeyCode_ResultRotatesLeft_WhenRotatesLeft()
    {
        // Arrange
        Quaternion initialRotation = _testGameObject.transform.rotation;
        Quaternion expectedRotation = initialRotation * Quaternion.Euler(0, -_characterBasic.RotateSpeed, 0);

        // Act
        Quaternion newRotation = _characterBasic.RotateByKeyCode(CharacterBasic.RotateType.Left);

        // Assert
        Assert.That(Quaternion.Angle(expectedRotation, newRotation), Is.LessThan(0.01f));
    }

    [Test]
    public void RotateByKeyCode_ResultRotatesRight_WhenRotatesRight()
    {
        // Arrange
        Quaternion initialRotation = _testGameObject.transform.rotation;
        Quaternion expectedRotation = initialRotation * Quaternion.Euler(0, _characterBasic.RotateSpeed, 0);

        // Act
        Quaternion newRotation = _characterBasic.RotateByKeyCode(CharacterBasic.RotateType.Right);

        // Assert
        Assert.That(Quaternion.Angle(expectedRotation, newRotation), Is.LessThan(0.01f));
    }
}
