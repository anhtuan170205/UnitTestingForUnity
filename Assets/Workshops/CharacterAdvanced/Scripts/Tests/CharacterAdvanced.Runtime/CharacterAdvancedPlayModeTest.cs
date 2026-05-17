using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CharacterAdvancedPlayModeTest
{
    private GameObject _testGameObject;
    private CharacterAdvanced _characterAdvanced;

    private class MockCharacterInput : ICharacterInput
    {
        public bool Left;
        public bool Right;
        public bool Up;
        public bool Down;
        public bool MoveLeftPressed() => Left;
        public bool MoveRightPressed() => Right;
        public bool MoveUpPressed() => Up;
        public bool MoveDownPressed() => Down;
    }

    private MockCharacterInput _mockInput;

    [SetUp]
    public void SetUp()
    {
        _testGameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        _testGameObject.name = "TestGameObject";
        ICharacterTransform characterTransform = new UnityCharacterTransform(_testGameObject.transform);
        _mockInput = new MockCharacterInput();
        _characterAdvanced = new CharacterAdvanced(characterTransform, _mockInput);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_testGameObject);
        _testGameObject = null;
        _characterAdvanced = null;
        _mockInput = null;
    }

    [Test]
    public void MoveByKeyCode_ResultMovesLeft_WhenMovesLeft()
    {
        // Arrange
        Vector3 initialPosition = _testGameObject.transform.position;
        Vector3 expectedPosition = initialPosition + new Vector3(-_characterAdvanced.Speed, 0, 0);

        // Act
        Vector3 newPosition = _characterAdvanced.MoveByKeyCode(CharacterAdvanced.MoveType.Left);

        // Assert
        Assert.AreEqual(expectedPosition, newPosition);
    }

    [Test]
    public void MoveByKeyCode_ResultMovesRight_WhenMovesRight()
    {
        // Arrange
        Vector3 initialPosition = _testGameObject.transform.position;
        Vector3 expectedPosition = initialPosition + new Vector3(_characterAdvanced.Speed, 0, 0);

        // Act
        Vector3 newPosition = _characterAdvanced.MoveByKeyCode(CharacterAdvanced.MoveType.Right);

        // Assert
        Assert.AreEqual(expectedPosition, newPosition);
    }

    [Test]
    public void MoveByKeyCode_ResultMovesUp_WhenMovesUp()
    {
        // Arrange
        Vector3 initialPosition = _testGameObject.transform.position;
        Vector3 expectedPosition = initialPosition + new Vector3(0, _characterAdvanced.Speed, 0);

        // Act
        Vector3 newPosition = _characterAdvanced.MoveByKeyCode(CharacterAdvanced.MoveType.Up);

        // Assert
        Assert.AreEqual(expectedPosition, newPosition);
    }

    [Test]
    public void MoveByKeyCode_ResultMovesDown_WhenMovesDown()
    {
        // Arrange
        Vector3 initialPosition = _testGameObject.transform.position;
        Vector3 expectedPosition = initialPosition + new Vector3(0, -_characterAdvanced.Speed, 0);

        // Act
        Vector3 newPosition = _characterAdvanced.MoveByKeyCode(CharacterAdvanced.MoveType.Down);

        // Assert
        Assert.AreEqual(expectedPosition, newPosition);
    }

    [Test]
    public void MoveBy_Result10_10_10_WhenInput10_10_10()
    {
        // Arrange
        Vector3 offset = new Vector3(10, 10, 10);
        Vector3 initialPosition = _testGameObject.transform.position;
        Vector3 expectedPosition = initialPosition + offset;

        // Act
        Vector3 returnedPosition = _characterAdvanced.MoveBy(offset);

        // Assert
        Assert.AreEqual(expectedPosition, returnedPosition);
    }

    [Test]
    public void MoveByInput_ResultMovesLeft_WhenMoveLeftPressed()
    {
        // Arrange
        Vector3 initialPosition = _testGameObject.transform.position;
        Vector3 expectedPosition = initialPosition + new Vector3(-_characterAdvanced.Speed, 0, 0);
        _mockInput.Left = true;

        // Act
        _characterAdvanced.MoveByInput();
        Vector3 newPosition = _testGameObject.transform.position;

        // Assert
        Assert.AreEqual(expectedPosition, newPosition);
    }
}
