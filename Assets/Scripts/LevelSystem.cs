using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelSystem
{

    public int level;
    public int currentExperience;
    public int experienceToNextLevel;

    public LevelSystem()
    {
        level = 0;
        currentExperience = 0;
        experienceToNextLevel = 100;
    }

    public void AddExperience(int amount)
    {
        experienceToNextLevel += amount;
        if(currentExperience >= experienceToNextLevel)
        {
            level++;
            currentExperience -= experienceToNextLevel;
        }
    }

    public int GetCurrentLevel()
    {
        return level;
    }

    public int GetCurrentExperience()
    {
        return currentExperience;
    }
}
