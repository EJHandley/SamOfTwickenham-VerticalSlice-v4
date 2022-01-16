using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class PlayerStatsUI : MonoBehaviour
{
    public PlayerStats playerStats;

    public TMP_Text dmgText;
    public TMP_Text armourText;
    public TMP_Text maxHPText;
    public TMP_Text maxEnergyText;

    void Start()
    {
        
    }

    void Update()
    {
        dmgText.text = playerStats.baseDamage.GetValue().ToString();
        armourText.text = playerStats.armour.GetValue().ToString();
        maxHPText.text = playerStats.maxHealth.GetValue().ToString();
        maxEnergyText.text = playerStats.maxEnergy.GetValue().ToString();
    }
}
