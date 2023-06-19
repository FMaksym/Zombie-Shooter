using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutofillerAddHealthParametres : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;

    private void FixedUpdate()
    {
        AutofillPlayerHealth();
    }

    private void AutofillPlayerHealth()
    {
        var addHealth = GetComponentsInChildren<AddHealth>();
        foreach (var health in addHealth)
        {
            if (health.playerHealth == null)
            {
                health.playerHealth = _playerHealth;
            }
        }
    }
}
