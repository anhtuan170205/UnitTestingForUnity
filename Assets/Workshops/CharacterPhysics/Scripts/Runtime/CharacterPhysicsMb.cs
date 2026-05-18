using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterPhysicsMb : MonoBehaviour
{
    public Rigidbody Rigidbody
    {
        get { return _rigidbody; }
    }

    private Rigidbody _rigidbody;
    public CharacterPhysics CharacterPhysics { get; set; }

    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        if (_rigidbody == null)
        {
            _rigidbody = gameObject.AddComponent<Rigidbody>();
        }
        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = false;
    }

    private void Update()
    {
        CharacterPhysics?.MoveByInput();
    }

    private void OnCollisionEnter(Collision collision)
    {
        CharacterPhysics?.HandleCollision(collision.gameObject);
    }
}

