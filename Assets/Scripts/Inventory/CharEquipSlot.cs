using UnityEngine;
using UnityEngine.UI;

public class CharEquipSlot : MonoBehaviour
{
    EquipmentManager equipmentManager;

    Equipment equipment;
    public Image icon;

    public int enumNumber;

    public void Start()
    {
        equipmentManager = EquipmentManager.instance;
    }

    public void Update()
    {
        equipment = equipmentManager.currentEquipment[enumNumber];

        if (equipment != null)
        {
            icon.sprite = equipment.icon;
            icon.enabled = true;
        }
        else
        {
            icon.enabled = false;
        }
    }

}
