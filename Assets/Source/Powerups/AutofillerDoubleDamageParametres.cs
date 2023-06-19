using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutofillerDoubleDamageParametres : MonoBehaviour
{
    [SerializeField] private DoubleDamage _doubleDamage;

    private void FixedUpdate()
    {
        var doubleDamageTrigger = GetComponentsInChildren<DoubleDamageTrigger>();

        foreach (var damageTrigger in doubleDamageTrigger)
        {
            if (damageTrigger.doubleDamage == null)
            {
                damageTrigger.doubleDamage = _doubleDamage;
            }
        }
    }
}
