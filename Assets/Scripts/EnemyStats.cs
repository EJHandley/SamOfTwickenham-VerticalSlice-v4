using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    PlayerManager player;
    PlayerStats playerStats;

    public LevelSystem levelSystem;

    public void Start()
    {
        player = PlayerManager.instance;
        playerStats = player.player.GetComponent<PlayerStats>();
    }

    public override void Die()
    {
        base.Die();
        //Death Anim

        if (playerStats.quest.isActive && playerStats.quest.questGoal.goalType == GoalType.Kill) 
        {
            playerStats.quest.questGoal.EnemyKilled();
            if(playerStats.quest.questGoal.IsReached())
            {
                levelSystem.AddExperience(playerStats.quest.experienceReward);
                playerStats.gold.AddModifier(playerStats.quest.goldReward);
                playerStats.quest.Complete();
            }
        }
        Destroy(gameObject);
    }

}
