using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Action<Item> onItemAdded;
    [SerializeField] List<Item> StartItems = new List<Item>();

    public List<Item> InventoryItems { get; private set; }


    void Awake()
    {
        InventoryItems = new List<Item>();

        for (var i = 0; i < StartItems.Count; i++)
        {
            AddItem(StartItems[i]);
        }
    }


    void AddItem(Item item)
    {
        InventoryItems.Add(item);
        onItemAdded?.Invoke(item);
    }
}
