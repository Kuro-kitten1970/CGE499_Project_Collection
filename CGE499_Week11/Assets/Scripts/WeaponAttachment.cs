using UnityEngine;

[CreateAssetMenuAttribute(fileName = "NewWeaponAttachment", menuName = "Weapon/Attachment", order = 1)]
public class WeaponAttachment : ScriptableObject, IWeapon
{
    [Range(0, 50)]
    [Tooltip("Increase rate of firing per second")]
    [SerializeField] private float rate;

    [Range(0, 50)]
    [Tooltip("Increase weapon range")]
    [SerializeField] private float range;

    [Range(0, 100)]
    [Tooltip("Increase weapon strength")]
    [SerializeField] private float strength;

    [Range(0, -5)]
    [Tooltip("Increase weapon cooldown")]
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
