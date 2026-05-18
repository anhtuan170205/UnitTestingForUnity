using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CharacterPhysicsPlayModeTest
{
    private GameObject _testGameObject;
    private CharacterPhysics _characterPhysics;

    private const float WaitSeconds = 0.5f;

    [SetUp]
    public void SetUp()
    {
        _testGameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        _testGameObject.name = "TestGameObject";

        CharacterPhysicsMb characterPhysicsMb = _testGameObject.AddComponent<CharacterPhysicsMb>();

        _characterPhysics = new CharacterPhysics(characterPhysicsMb);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_testGameObject);
        _testGameObject = null;
        _characterPhysics = null;
    }

    [UnityTest]
    public IEnumerator MoveByKeyCode_ResultXIsLessThan_WhenMovesLeft()
    {
        Vector3 initialPosition = _testGameObject.transform.position;

        _characterPhysics.MoveByKeyCode(CharacterPhysics.MoveType.Left);

        yield return new WaitForSeconds(WaitSeconds);

        Vector3 result = _characterPhysics.Position;

        Assert.IsTrue(result.x < initialPosition.x);
        Assert.IsTrue(Mathf.Approximately(result.y, initialPosition.y));
        Assert.IsTrue(Mathf.Approximately(result.z, initialPosition.z));
    }

    [UnityTest]
    public IEnumerator MoveByKeyCode_ResultXIsGreaterThan_WhenMovesRight()
    {
        Vector3 initialPosition = _testGameObject.transform.position;

        _characterPhysics.MoveByKeyCode(CharacterPhysics.MoveType.Right);

        yield return new WaitForSeconds(WaitSeconds);

        Vector3 result = _characterPhysics.Position;

        Assert.IsTrue(result.x > initialPosition.x);
        Assert.IsTrue(Mathf.Approximately(result.y, initialPosition.y));
        Assert.IsTrue(Mathf.Approximately(result.z, initialPosition.z));
    }

    [UnityTest]
    public IEnumerator MoveByKeyCode_ResultZIsGreaterThan_WhenMovesUp()
    {
        Vector3 initialPosition = _testGameObject.transform.position;

        _characterPhysics.MoveByKeyCode(CharacterPhysics.MoveType.Up);

        yield return new WaitForSeconds(WaitSeconds);

        Vector3 result = _characterPhysics.Position;

        Assert.IsTrue(result.z > initialPosition.z);
        Assert.IsTrue(Mathf.Approximately(result.x, initialPosition.x));
        Assert.IsTrue(Mathf.Approximately(result.y, initialPosition.y));
    }

    [UnityTest]
    public IEnumerator MoveByKeyCode_ResultZIsLessThan_WhenMovesDown()
    {
        Vector3 initialPosition = _testGameObject.transform.position;

        _characterPhysics.MoveByKeyCode(CharacterPhysics.MoveType.Down);

        yield return new WaitForSeconds(WaitSeconds);

        Vector3 result = _characterPhysics.Position;

        Assert.IsTrue(result.z < initialPosition.z);
        Assert.IsTrue(Mathf.Approximately(result.x, initialPosition.x));
        Assert.IsTrue(Mathf.Approximately(result.y, initialPosition.y));
    }

    [UnityTest]
    public IEnumerator MoveTo_Result10_10_10_WhenInput10_10_10()
    {
        Vector3 newPosition = new Vector3(10, 10, 10);

        _characterPhysics.MoveTo(newPosition);

        yield return new WaitForSeconds(WaitSeconds);

        Vector3 result = _characterPhysics.Position;

        Assert.AreEqual(newPosition, result);
    }

    [UnityTest]
    public IEnumerator Collision_ResultWasHitTrue_WhenHitsWall()
    {
        // Arrange
        GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wall.name = "Wall";
        wall.transform.position = new Vector3(1.5f, 0f, 0f);

        Rigidbody wallRb = wall.AddComponent<Rigidbody>();
        wallRb.isKinematic = true;

        _testGameObject.transform.position = Vector3.zero;

        Rigidbody playerRb = _testGameObject.GetComponent<Rigidbody>();
        playerRb.useGravity = false;
        playerRb.isKinematic = false;
        playerRb.linearVelocity = Vector3.right * 5f;

        // Act
        yield return new WaitForSeconds(1f);

        // Assert
        Assert.IsTrue(_characterPhysics.WasHit);
        Assert.AreEqual(wall, _characterPhysics.LastHitObject);

        Object.DestroyImmediate(wall);
    }
}