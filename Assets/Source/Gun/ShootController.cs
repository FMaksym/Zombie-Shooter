using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    class Bullet{
        public float time;
        public Vector3 inintialPosition;
        public Vector3 inintialVelocity;
        public TrailRenderer tracer;
    }

    public bool _isShoot;
    public bool _mainGunEquiped;
    public bool _pistolEquiped;

    [SerializeField] private float _bulletSpeed = 1000.0f;
    [SerializeField] private float _bulletDrop;
    public float _bulletDamage;
    public int _ammoCount;

    [SerializeField] private ParticleSystem[] _muzzleFlashParticle;
    [SerializeField] private ParticleSystem _hitParticle;
    [SerializeField] private ParticleSystem _hitParticleMetal;
    [SerializeField] private ParticleSystem _hitParticleWood;
    [SerializeField] private ParticleSystem _hitParticleStone;
    [SerializeField] private ParticleSystem _hitParticleZombie;
    [SerializeField] private TrailRenderer _tracerEffect;
    [SerializeField] private Transform _raycastOrigin;
    [SerializeField] private Transform _soundPoint;
    [Range(0, 1)] public float WeaponAudioVolume = 1f;
    public GameObject _raycastDestination;
    
    public WeaponPanel _panelWeapon;

    private WeaponData weaponData;
    private WeaponRecoil recoil;

    private Ray _ray;
    private RaycastHit _hitInfo;
    private float _acumulateTime;
    private List<Bullet> bullets = new();
    private float maxLifeTime = 2.0f;
    private bool _isReload = false;
    private int _bulletCount = 1;    

    private void Awake()
    {
        recoil = GetComponent<WeaponRecoil>();
        weaponData = GetComponent<WeaponData>();
        _panelWeapon = GetComponent<WeaponPanel>();
        _bulletDamage = weaponData.WeaponConfig.Damage;
        _isReload = false;
    }

    private void Start()
    {
        _ammoCount = weaponData.WeaponConfig.BulletAmount;
        _panelWeapon.RefreshAmountBulletText(weaponData.WeaponConfig.BulletAmount);
        _panelWeapon.SetClipSizeText(weaponData.WeaponConfig.BulletAmountMax);
        _panelWeapon.SetNameOfGunText(weaponData.WeaponConfig.Name);
    }

    private Vector3 GetPosition(Bullet bullet) {
        Vector3 gravity = Vector3.down * _bulletDrop;
        return (bullet.inintialPosition) + (bullet.inintialVelocity * bullet.time) + (0.5f * gravity * bullet.time * bullet.time);
        //p + v*t + 0.5*g*t*t
    }

    Bullet CreateBullet(Vector3 position, Vector3 velocity) {
        Bullet bullet = new ();
        bullet.inintialPosition = position;
        bullet.inintialVelocity = velocity;
        bullet.time = 0.0f;
        bullet.tracer = Instantiate(_tracerEffect, position, Quaternion.identity);
        bullet.tracer.AddPosition(position);
        return bullet;
    }

    public void StartShoot() {
        if (!_isShoot)
        {
            _isShoot = true;
            _acumulateTime = 0.0f;
            Shoot();
        }
    }

    public void UpdateFiring(float deltaTime) {
        _acumulateTime += deltaTime;
        float fireInterval = 1.0f / weaponData.WeaponConfig.ShootRange;

        while (_acumulateTime >= 0.0f){
            Shoot();
            _acumulateTime -= fireInterval;
        }
    }

    public void UpdateBullet(float deltaTime)
    {
        SimulateBullet(deltaTime);
        DestroyBulets(); 
    }

    private void DestroyBulets()
    {
        bullets.RemoveAll(bullet => bullet.time >= maxLifeTime);
    }

    private void SimulateBullet(float deltaTime)
    {
        bullets.ForEach(bullet => {
            Vector3 p0 = GetPosition(bullet);
            bullet.time += deltaTime;
            Vector3 p1 = GetPosition(bullet);
            RaycastSegment(p0, p1, bullet);
        });
    }

    private void RaycastSegment(Vector3 start, Vector3 end, Bullet bullet)
    {
        Vector3 direction = end - start;
        float distance = direction.magnitude;
        _ray.origin = start;
        _ray.direction = direction;

        if (Physics.Raycast(_ray, out _hitInfo, distance))
        {
            if (_hitInfo.collider.gameObject.GetComponent<StoneObject>() != null)
            {
                _hitParticle = _hitParticleStone;
            }
            else if (_hitInfo.collider.gameObject.GetComponent<WoodObject>() != null)
            {
                _hitParticle = _hitParticleWood;
            }
            else if (_hitInfo.collider.gameObject.GetComponentInChildren<ZombieTarget>() != null)
            {
                _hitParticle = _hitParticleZombie;
            }
            else
            {
                _hitParticle = _hitParticleMetal;
            }

            _hitParticle.transform.position = _hitInfo.point;
            _hitParticle.transform.forward = _hitInfo.normal;
            _hitParticle.Emit(1);

            bullet.tracer.transform.position = _hitInfo.point;
            bullet.time = maxLifeTime;

            var Rb2D = _hitInfo.collider.GetComponent<Rigidbody>();
            if (Rb2D)
            {
                Rb2D.AddForceAtPosition(_ray.direction * 20, _hitInfo.point, ForceMode.Impulse);
            }

            var hitBox = _hitInfo.collider.GetComponent<HitBox>();
            if (hitBox)
            {
                hitBox.OnRaycastHit(this, _ray.direction);
            }
        }
        else
        {
            bullet.tracer.transform.position = end;
        }
    }

    private void Shoot(){
        if (!_isReload && _isShoot)
        {
            if (_ammoCount <= 0)
            {
                Reload();
                return;
            }
            
            AudioSource.PlayClipAtPoint(weaponData.WeaponConfig.ShootSound, _soundPoint.transform.position, WeaponAudioVolume);

            --_ammoCount;
            _panelWeapon.RefreshAmountBulletText(_ammoCount);

            foreach (var particle in _muzzleFlashParticle){
                particle.Emit(1);
            }

            for (_bulletCount = 1; _bulletCount <= weaponData.WeaponConfig.AmountShootBullet; _bulletCount++)
            {
                //var randomPosition = new Vector3(0,Random.Range(-0.1f, 0.2f), Random.Range(-0.1f, 0.1f));

                var randomPosition = new Vector3(0,
                    Random.Range(weaponData.WeaponConfig.NegativeYRecoil, weaponData.WeaponConfig.PositiveYRecoil), 
                    Random.Range(weaponData.WeaponConfig.NegativeZRecoil, weaponData.WeaponConfig.PositiveZRecoil));

                Vector3 velocity = ((_raycastDestination.transform.position + randomPosition) - _raycastOrigin.position).normalized * _bulletSpeed;

                var bullet = CreateBullet(_raycastOrigin.position, velocity);
                bullets.Add(bullet);
            }
            recoil.GenerateRecoil();
        }
    }

    public void StopShoot(){

        StartCoroutine(StopShoot(_acumulateTime)); 
    }

    IEnumerator ReloadWait(float time)
    {
        if (!_isReload)
        {
            _isReload = true;
            AudioSource.PlayClipAtPoint(weaponData.WeaponConfig.ReloadSound, _soundPoint.transform.position, WeaponAudioVolume);
            yield return new WaitForSecondsRealtime(time);
            _ammoCount = weaponData.WeaponConfig.BulletAmountMax;
            _panelWeapon.RefreshAmountBulletText(weaponData.WeaponConfig.BulletAmountMax);
            _isReload = false;
        }
    }

    public void Reload()
    {
        if (_ammoCount < weaponData.WeaponConfig.BulletAmountMax)
        {
            StartCoroutine(ReloadWait(weaponData.WeaponConfig.ReloadTime));
        }
    }

    IEnumerator StopShoot(float time)
    {
        yield return new WaitForSeconds(time);
        _isShoot = false;
    }
}
