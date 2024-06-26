using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp", menuName ="PowerUp")]
public class PowerUp : ScriptableObject, IVisitor
{
    public string powerUpName;
    public GameObject powerUpPrefab;
    public string powerUpDescript;

    [Tooltip("Fully heal shield")]
    public bool healSheild;

    [Range(0.0f, 50f)]
    [Tooltip("Boost turbo setting up to increments of 50/mph")]
    public float turboBoost;

    [Range(0.0f, 25f)]
    [Tooltip("Boost weapon range in increments of up to 25 units")]
    public int weaponRange;

    [Range(0.0f, 50f)]
    [Tooltip("Boost turbo strength up to increments of 50/mph")]
    public float weaponStrength;

    public void Visit(BikeShield bikeShield)
    {
        if (healSheild)
        {
            bikeShield.health = 100.0f;
        }
    }

    public void Visit(BikeWeapon bikeWeapon)
    {
        int range = bikeWeapon.range += weaponRange;

        if (range >= bikeWeapon.maxRange)
            bikeWeapon.range = bikeWeapon.maxRange;
        else
            bikeWeapon.range = range;

        float strength = bikeWeapon.strength += Mathf.Round(bikeWeapon.strength * weaponStrength / 100);

        if (strength >= bikeWeapon.maxStrength)
            bikeWeapon.strength = bikeWeapon.maxStrength;
        else
            bikeWeapon.strength = strength;
    }

    public void Visit(BikeEngine bikeEngine)
    {
        float boost = bikeEngine.turboBoost += turboBoost;

        if (boost < 0.0f)
            bikeEngine.turboBoost = 0.0f;
        if (boost >= bikeEngine.maxTurboBoost)
            bikeEngine.turboBoost = bikeEngine.maxTurboBoost;
    }
}
