using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    public CharacterStats characterStats;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            BasicAttack();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SecondaryAttack();
        }
    }

    public void BasicAttack()
    {
        int damage = characterStats.basicDmg.GetValue();

        characterStats.TakeDamage(damage);
        print("Attack for" + damage);
    }

    public void SecondaryAttack()
    {
        int damage = characterStats.secondDmg.GetValue();

        characterStats.TakeDamage(damage);
        print("Attack for" + damage);
    }
}
