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
    CharacterController myController;

    public float attackRange = 1.5f;
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;

    public void Start()
    {
        myStats = GetComponent<CharacterStats>();
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
            
        }
    }

    public void BasicAttack(CharacterStats targetStats)
    {
        if (!basicAttack && isPlayer)
            return;

        if(attackCooldown <= 0f)
        {
            targetStats.TakeDamage(myStats.baseDamage.GetValue());
            attackCooldown = 1f / attackSpeed;
            print("Attack for " + myStats.baseDamage.GetValue());

            if(isPlayer)
            {
                basicAttack = false;
            }

        }
    }

    public void SecondaryAttack(CharacterStats targetStats)
    {
        if (!secondAttack && isPlayer)
            return;

        targetStats.TakeDamage(myStats.baseDamage.GetValue());
        print("Attack for " + myStats.baseDamage.GetValue());
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
