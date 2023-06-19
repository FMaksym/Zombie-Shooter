using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] private UnitConfig _unitConfig;

    public UnitConfig Config => _unitConfig;
}
