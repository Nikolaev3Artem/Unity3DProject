using System.Threading;
using UnityEngine;

public class ItemTaker : MonoBehaviour
{
    private Animator animator;
    [SerializeField] Item itemToAdd;
    [SerializeField] Inventory targetInventory;
    [SerializeField] protected bool picking = false;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Picking();
            targetInventory.AddItem(itemToAdd);
        }
    }

    void Picking()
    {
        picking = true;
        animator.SetBool("PickSomething", picking);
    }
}
