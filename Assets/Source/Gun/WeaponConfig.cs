using UnityEngine;

[CreateAssetMenu(menuName = "Source/Gun/Config", fileName = "WeaponConfig", order = 0)]
public sealed class WeaponConfig : ScriptableObject
{
    [Header("Name")]
    [SerializeField] private string _weaponName;

    [Header("Type")]
    [SerializeField, Tooltip("Type of Gun : Pistol, Rifle, Shotgun, Submachine, Sniper")] private string _weaponType;

    [Header("Common")]
    [Header("Price")]
    [SerializeField] private int _price;
    [Header("Bullet Amount")]
    [SerializeField] private int _bulletAmount;
    [Header("Max Bullet Amount")]
    [SerializeField] private int _bulletAmountMax;
    [Header("Amount Shoot Bullet")]
    [SerializeField, Min(1)] private int _shootBullet;
    [Header("Shoot Range"),Tooltip("Amount of bullet per second. EXAMPLE 3 bullet = 1s / 3 = 0.33")]
    [SerializeField, Min(0)] private float _shootRange;
    [Header("Reload Time")]
    [SerializeField, Min(1)] private float _reloadTime;
    [Header("Bullet Damage")]
    [SerializeField, Min(1)] private float _damage; 

    [Header("Recoil")]
    [Header("positiveY")]
    [SerializeField] private float _positiveYRecoil;
    [Header("negativeY")]
    [SerializeField] private float _negativeYRecoil;
    [Header("positiveZ")]
    [SerializeField] private float _positiveZRecoil;
    [Header("negativeZ")]
    [SerializeField] private float _negativeZRecoil;

    [Header("Shoot Sound")]
    [SerializeField] private AudioClip _shootSound;

    [Header("Reload Sound")]
    [SerializeField] private AudioClip _reloadSound;

    public string Name => _weaponName;
    public string Type => _weaponType;
    public int Price => _price;
    public int BulletAmount => _bulletAmount;
    public int BulletAmountMax => _bulletAmountMax;
    public int AmountShootBullet => _shootBullet;
    public float ShootRange => _shootRange;
    public float ReloadTime => _reloadTime;
    public float Damage => _damage;
    public float PositiveYRecoil => _positiveYRecoil;
    public float NegativeYRecoil => _negativeYRecoil;
    public float PositiveZRecoil => _positiveZRecoil;
    public float NegativeZRecoil => _negativeZRecoil;
    public AudioClip ShootSound => _shootSound;
    public AudioClip ReloadSound => _reloadSound;
}
