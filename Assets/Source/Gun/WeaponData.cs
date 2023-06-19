using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : MonoBehaviour
{
    [Space,Header("Weapon Config"), Tooltip("Config containing all information about the Weapon")]
    [SerializeField] private WeaponConfig _weaponConfig;

    [Space,Header("Weapon Status")]
    public bool IsBuy;
    public bool IsEquiped;

    [Space, Header("Model weapon for equip")]
    public GameObject ModelForSelect;

    public WeaponConfig WeaponConfig => _weaponConfig;


}
