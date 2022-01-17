using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "SkillTree/Skill")]
public class Skill : ScriptableObject
{
    new public string name = "New Skill";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Select()
    {
        Debug.Log("I selected " + name);
    }
}
