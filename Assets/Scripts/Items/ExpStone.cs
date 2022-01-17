using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/ExpStone")]
public class ExpStone : Item
{
    LevelSystem levelSystem = new LevelSystem();

    private void Awake()
    {

    }
    public override void Use()
    {
        levelSystem.AddExperience(levelSystem.experienceToNextLevel);
        LevelUI.instance.SetLevelSystem(levelSystem);
        Debug.Log("I used " + this + ", I have " + LevelUI.instance.levelSystem.currentExperience);
    }

}
