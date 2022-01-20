using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public bool isPlayer;

    bool basicAttack = false;
    bool secondAttack = false;

    CharacterStats myStats;
    PlayerStats playerStats;
    CharacterController myController;

    public float attackRange = 1.5f;
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;

    public int secondaryEnergyCost = 25;

    public void Start()
    {
        myStats = GetComponent<CharacterStats>();
        playerStats = GetComponent<PlayerStats>();
        myController = GetComponent<CharacterController>();
    }
    public void Update()
    {
        attackCooldown -= Time.deltaTime;

        if (!isPlayer)
            return;

        if (Input.GetKeyDown(KeyCode.Mouse0) && myController.myTarget != null)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, myController.myTarget.transform.position);

            if (myController.myTarget != null && distanceToEnemy <= myStats.basicRange.GetValue())
            {
                Debug.Log(myController.myTarget + " is in range.");
                
                myController.myTarget.GetComponent<Enemy>().Interact();
                basicAttack = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            playerStats.UseEnergy(30);
            myStats.energyCheck = false;
        }
    }

    public void BasicAttack(CharacterStats targetStats)
    {
        if (!basicAttack && isPlayer)
            return;

        if(attackCooldown <= 0f)
        {
            targetStats.TakeDamage(myStats.baseDamage.GetValue());
            attackCooldown = 0.5f / attackSpeed;
            print("Attack for " + myStats.baseDamage.GetValue());

            if (isPlayer)
            {
                myStats.energyCheck = false;
            }
        }
    }

    public void SecondaryAttack()
    {
        if (!secondAttack && isPlayer)
            return;

        if (isPlayer && attackCooldown <= 0f)
        {

            playerStats.UseEnergy(secondaryEnergyCost);
            if (myStats.energyCheck == true)
            {
                Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, attackRange);
                foreach (Collider2D target in targets)
                {
                    if(target.GetComponent<CharacterStats>())
                    {
                        Debug.Log("HIT " + target.name);
                        target.GetComponent<CharacterStats>().TakeDamage(myStats.baseDamage.GetValue());
                    }

                }
                attackCooldown = 2f / attackSpeed;
                print("Attack for " + myStats.baseDamage.GetValue());

                if (isPlayer)
                {
                    myStats.energyCheck = false;
                    basicAttack = false;
                }
            }
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
