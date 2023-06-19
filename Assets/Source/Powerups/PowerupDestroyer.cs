using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupDestroyer : MonoBehaviour
{
    [SerializeField] private float _activeTime;

    private void FixedUpdate()
    {
        if (_activeTime > 0)
        {
            _activeTime -= Time.deltaTime;
            if (_activeTime <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
