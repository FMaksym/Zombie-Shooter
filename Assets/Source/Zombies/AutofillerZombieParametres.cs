using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutofillerZombieParametres : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private ScoreInGame _scorePlayer;
    [SerializeField] private DoubleDamage _doubleDamage;

    private void Update()
    {
        AutofillZombieDealth();
        AutofillZombieAttack();
    }

    private void AutofillZombieDealth()
    {
        var zombieDealth = GetComponentsInChildren<ZombieDeath>();
        foreach (var zombie in zombieDealth)
        {
            if (zombie._scorePlayer == null)
            {
                zombie._scorePlayer = _scorePlayer;
            }
        }
    }

    private void AutofillZombieAttack()
    {
        var zombieAttack = GetComponentsInChildren<AttackZombie>();
        foreach (var zombie in zombieAttack)
        {
            if (zombie._playerHealth == null)
            {
                zombie._playerHealth = _playerHealth;
            }
        }
    }
}
