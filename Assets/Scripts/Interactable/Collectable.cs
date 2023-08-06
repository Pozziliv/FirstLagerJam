using UnityEngine;

public class Collectable : MonoBehaviour, IInteractable
{

    public Item _Item;
    public InventoryManage manager;
    public void Interact()
    {
        Debug.Log("Interact");

        Pickip();
    }

    private void Pickip()
    {
        manager.AddToList(_Item);

        manager.ListItems(_Item);
        Destroy(gameObject);
    }
}
