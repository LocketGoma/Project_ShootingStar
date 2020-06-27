using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ItemNode : MonoBehaviour {
    [SerializeField] private int itemID;
    [SerializeField] private string itemName;
    [SerializeField] private ItemType itemType;

    public int ItemID { get { return itemID; } }
    public string ItemName { get { return itemName; } }
    public ItemType GetItemType() { return itemType; }
    public string getName() { return ItemName; }   
    
}