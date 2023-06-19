using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ZombieHealth : MonoBehaviour
{
    public ZombieDeath _zombieDeath;
    public DoubleDamage DoubleDamage;

    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;

    private Ragdoll ragdoll;
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        ragdoll = GetComponent<Ragdoll>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        DoubleDamage = GetComponent<DoubleDamage>();
    }

    void Start()
    {
        _currentHealth = _maxHealth;

        var rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (var rigidbody in rigidbodies)
        {
            HitBox hitBox = rigidbody.gameObject.AddComponent<HitBox>();
            hitBox.zombieHealth = this;
        }
    }

    public void TakeDamage(float amount, Vector3 direction)
    {
        _currentHealth -= amount;
    }

    void FixedUpdate()
    {
        if (_currentHealth <= 0.0f)
            _zombieDeath.Die(ragdoll, navMeshAgent);
    }
}
