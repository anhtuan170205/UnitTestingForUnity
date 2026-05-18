using NUnit.Framework;
using UnityEngine;

public class CharacterPhysicsTest
{
    [Test]
    public void HandleCollision_ResultWasHitTrue_WhenHitObject()
    {
        GameObject player = new GameObject("Player");
        CharacterPhysicsMb characterPhysicsMb =
            player.AddComponent<CharacterPhysicsMb>();

        CharacterPhysics characterPhysics =
            new CharacterPhysics(characterPhysicsMb);

        GameObject enemy = new GameObject("Enemy");

        characterPhysics.HandleCollision(enemy);

        Assert.IsTrue(characterPhysics.WasHit);
        Assert.AreEqual(enemy, characterPhysics.LastHitObject);

        Object.DestroyImmediate(enemy);
        Object.DestroyImmediate(player);
    }

    [Test]
    public void ResetHit_ResultWasHitFalse_WhenAlreadyHit()
    {
        GameObject player = new GameObject("Player");
        CharacterPhysicsMb characterPhysicsMb =
            player.AddComponent<CharacterPhysicsMb>();

        CharacterPhysics characterPhysics =
            new CharacterPhysics(characterPhysicsMb);

        GameObject enemy = new GameObject("Enemy");

        characterPhysics.HandleCollision(enemy);
        characterPhysics.ResetHit();

        Assert.IsFalse(characterPhysics.WasHit);
        Assert.IsNull(characterPhysics.LastHitObject);

        Object.DestroyImmediate(enemy);
        Object.DestroyImmediate(player);
    }
}