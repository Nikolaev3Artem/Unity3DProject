using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Food Item", menuName = "Inventory/Items/new Food Item")]
public class FoodItem : ItemScriptableObject
{
    public float healAmount;

    private void Start()
    {
        itemType = ItemType.Food;
    }
}
