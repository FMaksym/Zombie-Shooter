using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDamage : MonoBehaviour
{
    [Header("Active Time")]
    [SerializeField] private float _doubleDamageActiveTime;
    [Header("Status")]
    public bool IsActive;

    public void DoubleDamageActive()
    {
        IsActive = true;
        StartCoroutine(Wait(_doubleDamageActiveTime));
        IsActive = false;
    }

    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
