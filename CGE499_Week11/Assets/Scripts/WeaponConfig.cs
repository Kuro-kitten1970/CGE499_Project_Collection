using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponConfig", menuName = "Weapon/Config", order = 1)]
public class WeaponConfig : ScriptableObject, IWeapon
{
    [Range(0, 60)]
    [Tooltip("Increase rate of firing per second")]
    [SerializeField] private float rate;

    [Range(0, 50)]
    [Tooltip("Weapon Range")]
    [SerializeField] private float range;

    [Range(0, 100)]
    [Tooltip("Weapon Strength")]
    [SerializeField] private float strength;

    [Range(0, 5)]
    [Tooltip("Weapon Cooldown")]
    [SerializeField] private float cooldown;

    public float Rate
    {
        get => rate;
    }

    public float Range
    {
        get => range;
    }

    public float Strength
    {
        get => strength;
    }

    public float Cooldown
    {
        get => cooldown;
    }
}
