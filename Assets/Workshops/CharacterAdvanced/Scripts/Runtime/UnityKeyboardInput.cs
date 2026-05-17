using UnityEngine;
using UnityEngine.InputSystem;

public class UnityKeyboardInput : ICharacterInput
{
	public bool MoveLeftPressed()
	{
		return Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed;
	}

	public bool MoveRightPressed()
	{
		return Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed;
	}

	public bool MoveUpPressed()
	{
		return Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed;
	}

	public bool MoveDownPressed()
	{
		return Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed;
	}
}
