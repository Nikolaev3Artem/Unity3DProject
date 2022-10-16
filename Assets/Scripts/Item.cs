using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Items/item")]
public class Item : ScriptableObject
{
    public string Name = "Item";
    public Sprite Icon;
    public int price = 500;
}
