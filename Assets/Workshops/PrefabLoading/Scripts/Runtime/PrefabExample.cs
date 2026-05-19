using UnityEngine;
using System.Diagnostics.CodeAnalysis;

public class PrefabExample : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private House _house;

    [ExcludeFromCodeCoverage]
    private void Awake()
    {
        Debug.Log($"Enemy Name = {_enemy.name}");
        Debug.Log($"House Name = {_house.Name}");
        Debug.Log($"House Number of Rooms = {_house.NumberOfRooms}");
    }
}
