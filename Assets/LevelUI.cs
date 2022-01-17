using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUI : MonoBehaviour
{
    #region Singleton

    public static LevelUI instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }
    #endregion

    public LevelSystem levelSystem;

    public TMP_Text levelText;
    public Slider experienceBar;

    public void Update()
    {
        experienceBar.maxValue = levelSystem.experienceToNextLevel;
        experienceBar.value = levelSystem.GetCurrentExperience();
        levelText.text = levelSystem.GetCurrentLevel().ToString();
    }

    public void SetCurrentExp(int exp)
    {
        experienceBar.value = exp;
    }

    public void SetLevelNumber(int level)
    {
        levelText.text = level.ToString();
    }

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;

        SetLevelNumber(levelSystem.GetCurrentLevel());
        SetCurrentExp(levelSystem.GetCurrentExperience());
    }

}
