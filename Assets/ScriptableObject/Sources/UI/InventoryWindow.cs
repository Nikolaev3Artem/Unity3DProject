using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour
{
    [SerializeField] Inventory targetInventory;
    [SerializeField] RectTransform itemsPanel;

    List<GameObject> drawIcons = new List<GameObject>();
    void Start()
    {
        targetInventory.onItemAdded += OnItemAdded;
        Redraw();
    }

    void OnItemAdded(Item obj) => Redraw();

    void Redraw()
    {
        ClearDrawn();

        for (var i = 0; i < targetInventory.InventoryItems.Count; i++)
        {
            var item = targetInventory.InventoryItems[i];

            var icon = new GameObject("Icon");
            icon.AddComponent<Image>().sprite = item.Icon;

            icon.transform.SetParent(itemsPanel);

            icon.transform.SetParent(itemsPanel);

            drawIcons.Add(icon);
        }
    }

    void ClearDrawn()
    {
        for (var i = 0; i<drawIcons.Count; i++)
        {
            Destroy(drawIcons[i]);
            
        }
        drawIcons.Clear();
    }
}
