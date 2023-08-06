using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManage : MonoBehaviour
{
    public static InventoryManage Instance;

    [SerializeField] private List<Item> _items = new List<Item>();

    [SerializeField] private Transform ItemContent;
    [SerializeField] private GameObject InventoryItem;
    public void Awake()
    {
        Instance = this;
    }
    public void AddToList(Item item)
    {
        _items.Add(item);
    }

    public void RemoveFromList(Item item)
    {
        _items.Remove(item);
    }

    public void ListItems(Item item)
    {


        GameObject invenroyItem = Instantiate(InventoryItem, ItemContent);
        var itemName = invenroyItem.GetComponentInChildren<TMP_Text>();
        Image itemIcon = invenroyItem.GetComponentsInChildren<Image>()[1];

        itemName.text = item.Name;
        itemIcon.sprite = item.Icon;

    }
}
