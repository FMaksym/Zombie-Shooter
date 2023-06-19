using UnityEngine;
using Cinemachine;

public class CreateGunSetParam : MonoBehaviour
{
    public GameObject ModelOfGun;
    public Transform HandPlayerForGun;
    public GameObject CroshairTarget;
    public WeaponPanel _panelWeapon;

    public bool Pistol;
    public bool Shotgun;
    public bool Submachine;
    public bool Rifle;
    public bool Sniper;

    private void Awake()
    {
        ModelOfGun = GetGunOfMenu.GunForPlayer;

        Pistol = GetGunOfMenu.Pistol;
        Shotgun = GetGunOfMenu.Shotgun;
        Submachine = GetGunOfMenu.Submachine;
        Rifle = GetGunOfMenu.Rifle;
        Sniper = GetGunOfMenu.Sniper;

        Instantiate(ModelOfGun, HandPlayerForGun);
    }
}
