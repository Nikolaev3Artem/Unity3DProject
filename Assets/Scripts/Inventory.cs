using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Action<Item> onItemAdded;
    [SerializeField] List<Item> StartItems = new List<Item>();

    public bool TF = true;
    public int InventorySize = 70;

    public GameObject invOpener;
    public List<Item> InventoryItems { get; private set; }


    void Awake()
    {
        InventoryItems = new List<Item>();

        for (var i = 0; i < StartItems.Count; i++)
        {
            AddItem(StartItems[i]);
        }
    }

    private void Update()
    {
        OpenCloseInv();
    }


    public void AddItem(Item item)
    {
        if (InventoryItems.Count < InventorySize)
        {
            InventoryItems.Add(item);
            onItemAdded?.Invoke(item);
        }

    }

    public void OpenCloseInv()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (TF == true)
            {
                invOpener.SetActive(false);
                TF = false;
            }
            else
            {
                invOpener.SetActive(true);
                TF = true;
            }
        }
    }
}
