using System;
using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    [SerializeField] private Unit _unit;

    public event Action<int> OnHealthChanged;

    public int MaxHealth { get; private set; }
    public int Health
    {
        get => _health;
        set
        {
            _health = Mathf.Clamp(value, 0, MaxHealth);
            OnHealthChanged?.Invoke(_health);
        }
    }

    private int _health;
    public bool IsAlive => Health > 0;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        MaxHealth = _unit.Config.Health;
        Health = MaxHealth;
        _health = MaxHealth;
    }
}
