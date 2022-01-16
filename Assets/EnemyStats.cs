using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    PlayerManager player;
    PlayerStats playerStats;

    public void Start()
    {
        player = PlayerManager.instance;
        playerStats = player.GetComponent<PlayerStats>();
    }

    public override void Die()
    {
        base.Die();
        //Death Anim

        if (playerStats.quest.isActive && playerStats.quest.goal.goalType == GoalType.Kill) 
        {
            playerStats.quest.goal.EnemyKilled();
            if(playerStats.quest.goal.IsReached())
            {
                playerStats.experience.AddModifier(playerStats.quest.experienceReward);
                playerStats.gold.AddModifier(playerStats.quest.goldReward);
                playerStats.quest.Complete();
            }
        }
        Destroy(gameObject);
    }

}
