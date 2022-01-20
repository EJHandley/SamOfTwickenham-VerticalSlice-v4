using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : Interactable
{
    public ChestInventory chestInventory;

    public GameObject playerInventoryUI;
    public GameObject chestUI;

    public SpriteRenderer chestSprite;

    public Sprite chestOpen;
    public Sprite chestClosed;

    bool chestIsOpen = false;

    public override void Interact()
    {
        base.Interact();

        if(Input.GetKeyDown(KeyCode.E))
        {
            if (!chestIsOpen)
            {
                OpenChest();
                chestInventory.onItemChangedCallback.Invoke();
            }
            else if (chestIsOpen)
            {
                CloseChest();
            }
        }

        if(!chestInRange && chestIsOpen)
        {
            CloseChest();
        }
    }

    public void OpenChest()
    {
        playerInventoryUI.SetActive(true);
        chestUI.SetActive(true);
        chestSprite.sprite = chestOpen;
        chestIsOpen = true;
    }

    public void CloseChest()
    {
        playerInventoryUI.SetActive(false);
        chestUI.SetActive(false);
        chestSprite.sprite = chestClosed;
        chestIsOpen = false;
    }
}
