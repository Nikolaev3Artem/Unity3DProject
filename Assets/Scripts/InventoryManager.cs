
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject UIPanel;
    public Transform inventoryPanel;
    public List<InventorySlot> slots = new List<InventorySlot>();
    public bool isOpened;
    public float reachDistance = 3;
    private Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
        for(int i = 0; i < inventoryPanel.childCount; i++)
        {
            if(inventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null )
            {
                slots.Add(inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
        UIPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            isOpened = !isOpened;
            if (isOpened)
            {
                UIPanel.SetActive(true);
            }
            else
            {
                UIPanel.SetActive(false);
            }
        }

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, reachDistance))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.collider.gameObject.GetComponent<Item>() != null)
                {
                    AddItem(hit.collider.gameObject.GetComponent<Item>().item, hit.collider.gameObject.GetComponent<Item>().amount);
                    Destroy(hit.collider.gameObject);
                }
            }
            Debug.DrawRay(ray.origin , ray.direction*reachDistance, Color.green );
            

        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * reachDistance, Color.red);
        }
    }

    private void AddItem(ItemScriptableObject _item, int _amount)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == _item)
            {
                slot.amount += _amount;
                return;
            }
        }

        foreach (InventorySlot slot in slots)
        {
            if(slot.isEmpty == true)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon);
                break;
            }
        }
    }
}
