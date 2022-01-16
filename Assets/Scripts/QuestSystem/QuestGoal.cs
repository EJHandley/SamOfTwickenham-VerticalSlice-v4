using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void EnemyKilled()
    {
        if(goalType == GoalType.Kill)
            currentAmount++;
    }

    public void ItemGathered()
    {
        if (goalType == GoalType.Gather)
            currentAmount++;
    }
}

public enum GoalType
{
    Kill,
    Gather,
    Get,
}
