using UnityEngine;
using System.Diagnostics.CodeAnalysis;

public class Scene01_Hero : MonoBehaviour
{
    [SerializeField] private Hero _hero;

    [ExcludeFromCodeCoverage]
    protected void Awake ()
    {
        Debug.Log($"Instructions: This Scene has no UI. See Unity Console.");
        Debug.Log($"Result = {_hero.name}");
    }
}
