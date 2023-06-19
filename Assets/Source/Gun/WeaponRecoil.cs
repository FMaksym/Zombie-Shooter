using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WeaponRecoil : MonoBehaviour
{
    public CinemachineVirtualCamera _cameraPlayer;
    [HideInInspector] public CinemachineImpulseSource cameraShake;

    private void Start()
    {
        _cameraPlayer = GetComponent<CinemachineVirtualCamera>(); 
        cameraShake = GetComponent<CinemachineImpulseSource>();
    }

    public void GenerateRecoil()
    {
        cameraShake.GenerateImpulse(Camera.main.transform.forward);
    }
}
