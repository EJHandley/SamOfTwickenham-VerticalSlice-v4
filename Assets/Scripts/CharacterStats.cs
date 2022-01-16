using UnityEngine;

[System.Serializable]
public class CharacterStats: MonoBehaviour
{
    public Stat maxHealth;
    public Stat healthRegenRate;

    public int currentHealth { get; private set; }

    public Stat maxEnergy;
    public Stat energyRegenRate;

    public int currentEnergy { get; private set; }

    public Stat armour;

    public Stat baseDamage;
    public Stat basicRange;

    public Stat gold;
    public int currentGold { get; private set; }

    public Stat experience;
    public int currentExperience { get; private set; }

    private void Awake()
    {
        currentHealth = maxHealth.GetValue();
        currentEnergy = maxEnergy.GetValue();
    }

    public void TakeDamage (int dmg)
    {
        dmg -= armour.GetValue();
        dmg = Mathf.Clamp(dmg, 0, int.MaxValue);

        currentHealth -= dmg;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void UseEnergy (int energy)
    {
        energy = Mathf.Clamp(energy, 0, int.MaxValue);

        currentEnergy -= energy;
    }

    public virtual void Die()
    { 
        //This method is meant to be overwritten
    }
}