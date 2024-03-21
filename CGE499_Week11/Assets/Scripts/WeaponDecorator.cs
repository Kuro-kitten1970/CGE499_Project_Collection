using UnityEngine;

public class WeaponDecorator : IWeapon
{
    private readonly IWeapon _decoratedWeapon;
    private readonly WeaponAttachment _attachment;

    public WeaponDecorator(IWeapon weapon, WeaponAttachment attachment)
    {
        _attachment = attachment;
        _decoratedWeapon = weapon;
    }

    public float Rate
    {
        get => _decoratedWeapon.Rate + _attachment.Rate;
    }

    public float Range
    {
        get => _decoratedWeapon.Range + _attachment.Range;
    }

    public float Strength
    {
        get => _decoratedWeapon.Strength + _attachment.Strength;
    }

    public float Cooldown
    {
        get => _decoratedWeapon.Cooldown + _attachment.Cooldown;
    }
}
