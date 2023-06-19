using UnityEngine;

public class HitBox : MonoBehaviour
{
    public ZombieHealth zombieHealth;

    public void OnRaycastHit(ShootController shoot, Vector3 direction)
    {
        zombieHealth.TakeDamage(shoot._bulletDamage, direction);

    }
}
