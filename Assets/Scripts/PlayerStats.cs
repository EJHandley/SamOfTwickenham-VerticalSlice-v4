using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : CharacterStats
{
    public Quest quest;

    public GameObject gameOver;

    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    void Update()
    {

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

    public override void Die()
    {
        gameOver.SetActive(true);
    }
}
