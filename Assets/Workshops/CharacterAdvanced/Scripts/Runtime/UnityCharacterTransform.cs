using UnityEngine;

public class UnityCharacterTransform : ICharacterTransform
{
    private readonly Transform _transform;

	public UnityCharacterTransform(Transform transform)
	{
		_transform = transform;
	}

	public Vector3 Position
	{
		get => _transform.position;
		set => _transform.position = value;
	}
}
