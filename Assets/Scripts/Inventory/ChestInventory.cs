using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInventory : MonoBehaviour
{
    #region Singleton

    public static ChestInventory instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 8;

    public List<Item> chestItems = new List<Item>();

    public void Remove(Item chestItem)
    {
        chestItems.Remove(chestItem);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

}
