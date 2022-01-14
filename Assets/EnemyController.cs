using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyAI enemyAI;

    public GameObject target;

    public float aggroRange;
    public float attackRange;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        enemyAI = gameObject.GetComponent<EnemyAI>();
    }


    void Update()
    {

    }

    void UpdateTarget()
    {
        float distanceToTarget = Vector2.Distance(transform.position, target.transform.position);

        if (distanceToTarget <= aggroRange && gameObject.layer == target.layer)
        {
            enemyAI.enabled = true;
            InvokeRepeating("DistanceToSpawn", 0f, 0.5f);
        }
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
