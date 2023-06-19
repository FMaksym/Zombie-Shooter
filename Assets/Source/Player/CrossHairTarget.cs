using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairTarget : MonoBehaviour
{
    Camera _mainCamera;
    Ray _ray;
    RaycastHit _hitInfo;

    void Start()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        _ray.origin = _mainCamera.transform.position;
        _ray.direction = _mainCamera.transform.forward;
        if (Physics.Raycast(_ray, out _hitInfo))
        {
            transform.position = _hitInfo.point;
        }
        else
        {
            transform.position = _ray.origin + _ray.direction * 1000.0f;
        }
    }
}
