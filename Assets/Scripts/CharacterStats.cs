using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CharacterStats: MonoBehaviour
{
    public bool isPlayer;
    public bool energyCheck = false;

    public GameObject healthCanvas;
    public Slider healthBar;
    public Slider energyBar;

    public Stat maxHealth;
    public Stat healthRegenRate;

    public int currentHealth { get; private set; }

    public Stat maxEnergy;
    public float energyRegenRate = 0.5f;

    public int currentEnergy;

    public Stat armour;

    public Stat baseDamage;
    public Stat basicRange;

    public Stat gold;
    public int currentGold { get; private set; }

    private void Awake()
    {
        currentHealth = maxHealth.GetValue();
        healthBar.maxValue = maxHealth.GetValue();

        if(isPlayer)
        {
            currentEnergy = maxEnergy.GetValue();
            energyBar.maxValue = maxEnergy.GetValue();
            currentGold = gold.GetValue();
        }

        if(!isPlayer)
        {
            healthCanvas.SetActive(false);
        }
    }

    public void Update()
    {
        if(!isPlayer)
        {
            if(currentHealth < maxHealth.GetValue())
            {
                healthCanvas.SetActive(true);
            }
        }
    }

    public void TakeDamage (int dmg)
    {
        dmg -= armour.GetValue();
        dmg = Mathf.Clamp(dmg, 0, int.MaxValue);

        currentHealth -= dmg;
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void SetEnergy(int energy)
    {
        energy = Mathf.Clamp(energy, 0, int.MaxValue);

        currentEnergy -= energy;
        energyBar.value = currentEnergy;

        energyCheck = true;
    }

    public void Heal(int hp)
    {
        currentHealth += hp;
        healthBar.value = currentHealth;
    }    


    public virtual void Die()
    { 
        //This method is meant to be overwritten
    }
}