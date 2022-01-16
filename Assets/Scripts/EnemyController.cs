using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyAI enemyAI;

    Transform target;
    CharacterCombat combat;

    private float aggroRange = 5;
    private float attackRange = 2;

    void Start()
    {
        target = PlayerManager.instance.player.transform;

        enemyAI = gameObject.GetComponent<EnemyAI>();

        combat = GetComponent<CharacterCombat>();
    }


    public void Update()
    {
        float distanceToTarget = Vector2.Distance(target.position, transform.position);

        if (distanceToTarget <= aggroRange && gameObject.layer == target.gameObject.layer)
        {
            enemyAI.enabled = true;
        }

        if (distanceToTarget <= attackRange)
        {
            CharacterStats targetStats = target.GetComponent<CharacterStats>();
            if (targetStats != null)
            {
                combat.BasicAttack(targetStats);
                Debug.Log("Hit Player");
            }
        }
    }

    void UpdateTarget()
    {

    }

    void DistanceToSpawn()
    {

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
