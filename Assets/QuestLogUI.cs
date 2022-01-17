using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestLogUI : MonoBehaviour
{
    #region Singleton
    PlayerManager player;
    PlayerStats playerStats;

    public void Start()
    {
        player = PlayerManager.instance;
        playerStats = player.player.GetComponent<PlayerStats>();
    }
    #endregion

    public TMP_Text currentQuestName;
    public TMP_Text currentQuestText;
    public TMP_Text currentQuestGoal;
    public TMP_Text currentQuestGoldReward;
    public TMP_Text currentQuestExpReward;

    public void ListQuest()
    {
        currentQuestName.text = playerStats.quest.title;
        currentQuestText.text = playerStats.quest.description;
        currentQuestGoal.text = playerStats.quest.goal;
        currentQuestGoldReward.text = playerStats.quest.goldReward.ToString();
        currentQuestExpReward.text = playerStats.quest.experienceReward.ToString();
    }
}
