using UnityEngine;
using System.Diagnostics.CodeAnalysis;

public class CharacterAdvancedMb : MonoBehaviour
{
	public CharacterAdvanced CharacterAdvanced { set; private get; }

	private void Awake()
	{
		ICharacterTransform characterTransform = new UnityCharacterTransform(transform);
		ICharacterInput characterInput = new UnityKeyboardInput();
		CharacterAdvanced = new CharacterAdvanced(characterTransform, characterInput);
	}

	private void Update()
	{
		CharacterAdvanced.MoveByInput();
	}
}
