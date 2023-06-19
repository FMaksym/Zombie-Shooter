using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using StarterAssets;

public class ThirdPersonShooterController : MonoBehaviour
{
    public CinemachineVirtualCamera playerCamera;
    public GameObject AudioObject;
    [SerializeField] private CinemachineVirtualCamera _aimVirtualCamera;
    [SerializeField] private float _normalSensitivity;
    [SerializeField] private float _aimSensitivity;
    [SerializeField] private LayerMask _aimColliderLayerMask;
    //[SerializeField] private Transform _debugTransform;
    //[SerializeField] private Transform _pfBulletProjectile;
    [SerializeField] private Transform _spawnBulletPosition;

    private Camera _mainCamera;
    private StarterAssetsInputs _starterAssetsInputs;
    private ThirdPersonController _thirdPersonController;
    private ShootController _shootController;
    private CreateGunSetParam createGun;
    private WeaponRecoil weapon;

    private void Awake()
    {
        _starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        _thirdPersonController = GetComponent<ThirdPersonController>();
        createGun = GetComponent<CreateGunSetParam>();
    }

    private void Start()
    {
        _shootController = GetComponentInChildren<ShootController>();
        weapon = GetComponentInChildren<WeaponRecoil>();
        _mainCamera = Camera.main;
        if (_shootController._raycastDestination == null)
        {
            _shootController._raycastDestination = createGun.CroshairTarget;
        }
        _shootController._panelWeapon = createGun._panelWeapon;
        weapon._cameraPlayer = playerCamera;
    }

    private void FixedUpdate()
    {
        Vector3 mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = _mainCamera.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, _aimColliderLayerMask))
        {
            //_debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }

        if (_starterAssetsInputs.aim)
        {
            _aimVirtualCamera.gameObject.SetActive(true);
            _thirdPersonController.SetSensitivity(_aimSensitivity);
            _thirdPersonController.SetRotateOnMove(false);

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }
        else
        {
            _aimVirtualCamera.gameObject.SetActive(false);
            _thirdPersonController.SetSensitivity(_normalSensitivity);
            _thirdPersonController.SetRotateOnMove(false);
        }

        //if (Input.GetButtonDown("Fire1"))
        //{
        //    _shootController.StartShoot();
        //}

        if (_starterAssetsInputs.shoot)
        {
            _shootController.StartShoot();
        }

        if (_shootController._isShoot)
        {
            _shootController.UpdateFiring(Time.deltaTime);
        }

        _shootController.UpdateBullet(Time.deltaTime);

        //if (Input.GetButtonUp("Fire1"))
        //{
        //    _shootController.StopShoot();
        //}

        if (!_starterAssetsInputs.shoot)
        {
            _shootController.StopShoot();
        }

        if (Input.GetKeyDown(KeyCode.R) || _starterAssetsInputs.reload)
        {
            _shootController.Reload();
        }
    }
}
