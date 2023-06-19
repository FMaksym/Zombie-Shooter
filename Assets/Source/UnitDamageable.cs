using System;
using UnityEngine;

public class UnitDamageable : MonoBehaviour
{
    [SerializeField] private UnitHealth _unitHealth;
    public void ApplyDamage(int damage){
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        int totalDamage = ProcessedDamage(damage);

        if (totalDamage < 0)
            throw new ArgumentOutOfRangeException(nameof(totalDamage));

        _unitHealth.Health -= totalDamage;
    }

    protected virtual int ProcessedDamage(int damage)
    {
        return damage;
    }
}
