using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInventory : MonoBehaviour
{
    #region Singleton
    
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public static ChestInventory instance;

    public int space = 8;

    public List<Item> chestItems = new List<Item>();

    public void Remove(Item chestItem)
    {
        chestItems.Remove(chestItem);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

}
