using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
    public Quest quest;

    public GameObject gameOver;

    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
        StartCoroutine(EnergyRegen());
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            armour.AddModifier(newItem.armourModifier);
            baseDamage.AddModifier(newItem.damageModifier);
        }

        if (oldItem != null)
        {
            armour.RemoveModifier(oldItem.armourModifier);
            baseDamage.RemoveModifier(oldItem.damageModifier);
        }
    }
    public void UseEnergy(int energy)
    {
        if (currentEnergy >= energy)
        {
            SetEnergy(energy);
        }
        else
        {
            Debug.Log("Not Enough Energy");
        }
    }

    IEnumerator EnergyRegen()
    {
        while (true)
        { 
            if(currentEnergy < maxEnergy.GetValue())
            {
                currentEnergy += 1;
                Debug.Log("Added 1 Energy");
                energyBar.value = currentEnergy;

                yield return new WaitForSeconds(energyRegenRate);
            } else
            {
                yield return null;
            }

        }
    }

    public override void Die()
    {
        SceneManager.LoadScene(2);
    }
}
