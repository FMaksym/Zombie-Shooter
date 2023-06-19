using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAiming : MonoBehaviour
{
    [SerializeField] private float _turnSpeed = 15f;
    Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        float yawCamera = _mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), _turnSpeed * Time.fixedDeltaTime);
    }
}
