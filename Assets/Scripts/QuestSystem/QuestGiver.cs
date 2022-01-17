using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;

    #region Player Ref
    public PlayerManager player;
    public PlayerStats playerStats;
    private void Start()
    {
        player = PlayerManager.instance;
        playerStats = player.player.GetComponent<PlayerStats>();
    }
    #endregion

    public GameObject questWindow;
    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public TMP_Text questSumText;
    public TMP_Text experienceText;
    public TMP_Text goldText;

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        questSumText.text = quest.goal;
        experienceText.text = quest.experienceReward.ToString();
        goldText.text = quest.goldReward.ToString();
    }

    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.isActive = true;
        playerStats.quest = quest;
    }
}
