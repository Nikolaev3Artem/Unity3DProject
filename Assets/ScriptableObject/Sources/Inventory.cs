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

    public GameObject obj;
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
        InventoryItems.Add(item);
        onItemAdded?.Invoke(item);
    }

    public void OpenCloseInv()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            if (TF == true)
            {
                obj.SetActive(false);
                TF = false;
            }
            else if(TF == false)
            {
                obj.SetActive(true);
                TF = true;
            }
        }
    }
}
