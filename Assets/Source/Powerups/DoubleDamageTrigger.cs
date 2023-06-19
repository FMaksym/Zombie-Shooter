using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDamageTrigger : MonoBehaviour
{
    public DoubleDamage doubleDamage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ThirdPersonShooterController>())
        {
            doubleDamage.DoubleDamageActive();
            Destroy(gameObject);
        }
    }
}
