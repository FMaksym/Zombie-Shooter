using System;
using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    [SerializeField] private Unit _unit;
    private int _damage;

    public event Action<float> OnDamageChanged;

    public int Damage{
        get => _damage;
        set{
            _damage = Math.Clamp(value, 0, int.MaxValue);
            OnDamageChanged?.Invoke(_damage);
        }
    }

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        Damage = _unit.Config.Damage;
    }

    public void PerformAttack(UnitDamageable recepientUnitDamageable)
    {
        recepientUnitDamageable.ApplyDamage(_damage);
    }
}
