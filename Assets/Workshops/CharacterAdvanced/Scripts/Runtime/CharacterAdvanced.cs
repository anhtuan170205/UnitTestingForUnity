using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAdvanced
{
    private const float _speed = 0.5f;
    public float Speed { get { return _speed; }}

    private readonly ICharacterTransform _characterTransform;
    private readonly ICharacterInput _characterInput;

    public CharacterAdvanced(ICharacterTransform characterTransform, ICharacterInput characterInput)
    {
        _characterTransform = characterTransform;
        _characterInput = characterInput;
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
        if (_characterInput.MoveLeftPressed())
        {
            MoveByKeyCode(MoveType.Left);
        }
        if (_characterInput.MoveRightPressed())
        {
            MoveByKeyCode(MoveType.Right);
        }
        if (_characterInput.MoveUpPressed())
        {
            MoveByKeyCode(MoveType.Up);
        }
        if (_characterInput.MoveDownPressed())
        {
            MoveByKeyCode(MoveType.Down);
        }
    }

    public Vector3 MoveByKeyCode(MoveType moveType)
    {
        switch (moveType)
        {
            case MoveType.Left:
                MoveBy(new Vector3(-_speed, 0, 0));
                break;
            case MoveType.Right:
                MoveBy(new Vector3(_speed, 0, 0));
                break;
            case MoveType.Up:
                MoveBy(new Vector3(0, _speed, 0));
                break;
            case MoveType.Down:
                MoveBy(new Vector3(0, -_speed, 0));
                break;
        }
        return _characterTransform.Position;
    }

    public Vector3 MoveTo(Vector3 position)
    {
        _characterTransform.Position = position;
        return _characterTransform.Position;
    }

    public Vector3 MoveBy(Vector3 moveBy)
    {
        _characterTransform.Position += moveBy;
        return _characterTransform.Position;
    }
}
