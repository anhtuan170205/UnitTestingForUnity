using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CharacterAdvancedTest
{
    private class MockCharacterTransform : ICharacterTransform
    {
        public Vector3 Position { get; set; }
    }

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

    [Test]
    public void MoveTo_Result123_When123()
    {
        // Arrange
        MockCharacterTransform fakeTransform = new MockCharacterTransform();
        MockCharacterInput fakeInput = new MockCharacterInput();
        CharacterAdvanced characterAdvanced = new CharacterAdvanced(fakeTransform, fakeInput);

        Vector3 expectedPosition = new Vector3(1, 2, 3);

        // Act
        Vector3 result = characterAdvanced.MoveTo(expectedPosition);

        // Assert
        Assert.AreEqual(expectedPosition, result);
        Assert.AreEqual(expectedPosition, fakeTransform.Position);
    }
}
