using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterPhysics
{
    public float Speed => _speed;
    public Vector3 Position => _characterPhysicsMb.transform.position;

    public bool WasHit { get; private set; }
    public GameObject LastHitObject { get; private set; }

    private const float _speed = 50f;
    private readonly CharacterPhysicsMb _characterPhysicsMb;

    public CharacterPhysics(CharacterPhysicsMb characterPhysicsMb)
    {
        _characterPhysicsMb = characterPhysicsMb;
        _characterPhysicsMb.CharacterPhysics = this;
    }

    public enum MoveType
    {
        Left,
        Right,
        Up,
        Down
    }

    public void MoveByInput()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.aKey.isPressed)
        {
            MoveByKeyCode(MoveType.Left);
        }

        if (Keyboard.current.dKey.isPressed)
        {
            MoveByKeyCode(MoveType.Right);
        }

        if (Keyboard.current.wKey.isPressed)
        {
            MoveByKeyCode(MoveType.Up);
        }

        if (Keyboard.current.sKey.isPressed)
        {
            MoveByKeyCode(MoveType.Down);
        }
    }

    public void MoveByKeyCode(MoveType moveType)
    {
        Vector3 direction = GetDirection(moveType);
        _characterPhysicsMb.Rigidbody.AddForce(direction * Speed);
    }

    public Vector3 MoveTo(Vector3 position)
    {
        _characterPhysicsMb.Rigidbody.MovePosition(position);
        return _characterPhysicsMb.transform.position;
    }

    public Vector3 AddForce(Vector3 force)
    {
        _characterPhysicsMb.Rigidbody.AddForce(force);
        return _characterPhysicsMb.transform.position;
    }

    public void HandleCollision(GameObject hitObject)
    {
        WasHit = true;
        LastHitObject = hitObject;
    }

    public void ResetHit()
    {
        WasHit = false;
        LastHitObject = null;
    }

    private Vector3 GetDirection(MoveType moveType)
    {
        switch (moveType)
        {
            case MoveType.Left:
                return Vector3.left;

            case MoveType.Right:
                return Vector3.right;

            case MoveType.Up:
                return Vector3.forward;

            case MoveType.Down:
                return Vector3.back;

            default:
                return Vector3.zero;
        }
    }
}