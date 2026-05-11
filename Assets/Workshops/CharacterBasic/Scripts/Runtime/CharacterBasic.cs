using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterBasic : MonoBehaviour
{
    public float Speed { get { return _speed;}}
    public float RotateSpeed { get { return _rotateSpeed;}}
    private const float _speed = 0.5f;
    private const float _rotateSpeed = 90f;

    public enum MoveType
    {
        Left,
        Right,
        Up,
        Down
    }

    public enum RotateType
    {
        Left,
        Right
    }

    protected void Update()
    {
        MoveByInput();
        RotateByInput();
    }

    public void MoveByInput()
    {
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame ||
            Keyboard.current.aKey.wasPressedThisFrame)
        {
            MoveByKeyCode(MoveType.Left);
        }
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame ||
            Keyboard.current.dKey.wasPressedThisFrame)
        {
            MoveByKeyCode(MoveType.Right);
        }
        if (Keyboard.current.upArrowKey.wasPressedThisFrame ||
            Keyboard.current.wKey.wasPressedThisFrame)
        {
            MoveByKeyCode(MoveType.Up);
        }
        if (Keyboard.current.downArrowKey.wasPressedThisFrame ||
            Keyboard.current.sKey.wasPressedThisFrame)
        {
            MoveByKeyCode(MoveType.Down);
        }
    }

    public void RotateByInput()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            RotateByKeyCode(RotateType.Left);
        }
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            RotateByKeyCode(RotateType.Right);
        }
    }

    public Vector3 MoveByKeyCode(MoveType moveType)
    {
        if (moveType == MoveType.Left)
        {
            MoveBy(new Vector3(-_speed, 0, 0));
        }
        if (moveType == MoveType.Right)
        {
            MoveBy(new Vector3(_speed, 0, 0));
        }
        if (moveType == MoveType.Up)
        {
            MoveBy(new Vector3(0,  _speed, 0));
        }
        if (moveType == MoveType.Down)
        {
            MoveBy(new Vector3(0,  -_speed, 0));
        }

        return transform.position;
    }
    
    public Quaternion RotateByKeyCode(RotateType rotateType)
    {
        if (rotateType == RotateType.Left)
        {
            RotateBy(new Vector3(0, -_rotateSpeed, 0));
        }
        if (rotateType == RotateType.Right)
        {
            RotateBy(new Vector3(0, _rotateSpeed, 0));
        }

        return transform.rotation;
    }

    public Vector3 MoveBy(Vector3 moveBy)
    {
        transform.position += moveBy;
        return transform.position;
    }

    public Vector3 MoveTo(Vector3 position)
    {
        transform.position = position;
        return transform.position;
    }

    public Vector3 RotateBy(Vector3 rotateBy)
    {
        transform.rotation *= Quaternion.Euler(rotateBy);
        return transform.rotation.eulerAngles;
    }
}
