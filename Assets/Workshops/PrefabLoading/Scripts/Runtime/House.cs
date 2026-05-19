using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class House : MonoBehaviour
{
    [SerializeField] public string Name = "House";
    [SerializeField] public int NumberOfRooms = 3;

    public Rigidbody Rigidbody;
    public BoxCollider BoxCollider;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        BoxCollider = GetComponent<BoxCollider>();
    }
}
