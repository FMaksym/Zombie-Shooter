using UnityEngine;

[CreateAssetMenu(menuName = "Source/Unit/Config", fileName = "UnitConfig", order = 1)]
public sealed class UnitConfig : ScriptableObject
{
    [Header("Name"), Space]

    [SerializeField] private string _name;

    [Header("Overall"), Space]

    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    public string Name => _name;
    public int Health => _health;
    public int Damage => _damage;
    public float Speed => _speed;
}
