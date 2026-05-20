using UnityEngine;
using System.Diagnostics.CodeAnalysis;

public class Scene02_House : MonoBehaviour
{
    [SerializeField] private House _house;

    [ExcludeFromCodeCoverage]
    protected void Awake ()
    {
        Debug.Log($"Instructions: This Scene has no UI. See Unity Console.");
        Debug.Log($"Result = {_house.name}");
    }
}
