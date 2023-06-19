using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZombie : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private ZombiesSounds _zombiesSounds;

    public PlayerHealth _playerHealth;

    public void ZombieAttack()
    {
        _playerHealth.TakingDamage(_damage);
        AudioSource.PlayClipAtPoint(_zombiesSounds._zombiesAttackSound, gameObject.transform.position, 60);
    }
}
