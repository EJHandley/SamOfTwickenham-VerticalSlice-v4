using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeSlot : MonoBehaviour
{

    public Skill skill;

    public Image skillSlotImg;
    public Button skillButton;

    public void Awake()
    {
        skillSlotImg.sprite = skill.icon;
        Color temp = skillSlotImg.color;
        temp.a = 1f;
        skillSlotImg.color = temp;
    }

    public void ChooseSkill()
    {
        skill.Select();
        skillButton.enabled = false;
    }
}
