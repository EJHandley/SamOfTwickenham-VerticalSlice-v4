using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public bool greenApple;
    public PlayerStats playerStats;

    public override void Interact()
    {
        base.Interact();

        Pickup();
    }

    void Pickup()
    {
        Debug.Log("Picking Up" + item.name);

        bool wasPickedUp = Inventory.instance.Add(item);

        if(greenApple)
        {
            playerStats.quest.questGoal.ItemGathered();
        }

        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }

}
