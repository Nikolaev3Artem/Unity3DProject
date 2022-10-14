using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTaker : MonoBehaviour
{
    [SerializeField] Item itemToAdd;
    [SerializeField] Inventory targetInventory;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            targetInventory.AddItem(itemToAdd);
        }
    }
}
