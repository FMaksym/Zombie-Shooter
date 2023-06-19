using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesSounds : MonoBehaviour
{
    public AudioClip _zombiesAttackSound;
    public AudioClip _zombieChaseSound;
    public AudioClip _zombieDeathSound;

    public void ZombieChase()
    {
        AudioSource.PlayClipAtPoint(_zombieChaseSound, gameObject.transform.position, 50);
    }
}
