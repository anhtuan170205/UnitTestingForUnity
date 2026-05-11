using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CharacterBasicTest
{
    private GameObject _testGameObject;
    private CharacterBasic _characterBasic;

    [SetUp]
    public void SetUp()
    {
        _testGameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        _characterBasic = _testGameObject.AddComponent<CharacterBasic>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_testGameObject);
    }

    [Test]
    public void MoveTo_Result123_When123()
    {
        // Arrange
        Vector3 expectedPosition = new Vector3(1, 2, 3);

        // Act
        Vector3 actualPosition = _characterBasic.MoveTo(expectedPosition);

        // Assert
        Assert.AreEqual(expectedPosition, actualPosition);
    }

    [Test]
    public void MoveBy_Result111_WhenInput111()
    {
        // Arrange
        Vector3 offset = new Vector3(1, 1, 1);
        Vector3 expectedPosition = _testGameObject.transform.position + offset;

        // Act
        Vector3 actualPosition = _characterBasic.MoveBy(offset);

        // Assert
        Assert.AreEqual(expectedPosition, actualPosition);
    }

    [Test]
    public void MoveByKeyCode_ResultMovesLeft_WhenMoveLeft()
    {
        // Arrange
        Vector3 expectedPosition = _testGameObject.transform.position + new Vector3(-_characterBasic.Speed, 0, 0);

        // Act
        Vector3 actualPosition = _characterBasic.MoveByKeyCode(CharacterBasic.MoveType.Left);

        // Assert
        Assert.AreEqual(expectedPosition, actualPosition);
    }

    [Test]
    public void MoveByKeyCode_ResultMovesRight_WhenMoveRight()
    {
        // Arrange
        Vector3 expectedPosition = _testGameObject.transform.position + new Vector3(_characterBasic.Speed, 0, 0);

        // Act
        Vector3 actualPosition = _characterBasic.MoveByKeyCode(CharacterBasic.MoveType.Right);

        // Assert
        Assert.AreEqual(expectedPosition, actualPosition);
    }

    [Test]
    public void MoveByKeyCode_ResultMovesUp_WhenMoveUp()
    {
        // Arrange
        Vector3 expectedPosition = _testGameObject.transform.position + new Vector3(0, _characterBasic.Speed, 0);

        // Act
        Vector3 actualPosition = _characterBasic.MoveByKeyCode(CharacterBasic.MoveType.Up);

        // Assert
        Assert.AreEqual(expectedPosition, actualPosition);
    }

    [Test]
    public void MoveByKeyCode_ResultMovesDown_WhenMoveDown()
    {
        // Arrange
        Vector3 expectedPosition = _testGameObject.transform.position + new Vector3(0, -_characterBasic.Speed, 0);

        // Act
        Vector3 actualPosition = _characterBasic.MoveByKeyCode(CharacterBasic.MoveType.Down);

        // Assert
        Assert.AreEqual(expectedPosition, actualPosition);
    }

    [Test]
    public void RotateBy_ResultRotates90Degrees_WhenRotate90Degrees()
    {
        // Arrange
        Vector3 rotateBy = new Vector3(0, 90, 0);
        Quaternion expectedRotation = Quaternion.Euler(rotateBy);

        // Act
        Vector3 actualRotation = _characterBasic.RotateBy(rotateBy);

        // Assert
        Assert.AreEqual(expectedRotation.eulerAngles, actualRotation);
    }

    [Test]
    public void RotateByKeyCode_ResultRotatesRight_WhenRotateRight()
    {
        // Arrange
        Quaternion expectedRotation = _testGameObject.transform.rotation * Quaternion.Euler(0, _characterBasic.RotateSpeed, 0);

        // Act
        Quaternion actualRotation = _characterBasic.RotateByKeyCode(CharacterBasic.RotateType.Right);

        // Assert
        Assert.That(Quaternion.Angle(expectedRotation, actualRotation), Is.LessThan(0.01f));
    }

    [Test]
    public void RotateByKeyCode_ResultRotatesLeft_WhenRotateLeft()
    {
        // Arrange
        Quaternion expectedRotation = _testGameObject.transform.rotation * Quaternion.Euler(0, -_characterBasic.RotateSpeed, 0);

        // Act
        Quaternion actualRotation = _characterBasic.RotateByKeyCode(CharacterBasic.RotateType.Left);

        // Assert
        Assert.That(Quaternion.Angle(expectedRotation, actualRotation), Is.LessThan(0.01f));
    }
}