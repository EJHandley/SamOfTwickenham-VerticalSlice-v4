using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    ChestInventory chestInventory;

    ChestInventorySlot[] chestSlots;

    void Start()
    {
        chestInventory = ChestInventory.instance;
        chestInventory.onItemChangedCallback += UpdateUI;

        chestSlots = itemsParent.GetComponentsInChildren<ChestInventorySlot>();
    }

    void Update()
    {

    }

    void UpdateUI()
    {
        for (int i = 0; i < chestSlots.Length; i++)
        {
            if (i < chestInventory.chestItems.Count)
            {
                chestSlots[i].AddItem(chestInventory.chestItems[i]);
            }
            else
            {
                chestSlots[i].ClearSlot();
            }
        }
    }
}
