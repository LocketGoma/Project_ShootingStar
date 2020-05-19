using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNode {
    int ItemID;
    string ItemName;    

    public string getName() { return ItemName; }

    public ItemNode(int ItemID, string ItemName) {
        this.ItemID = ItemID;
        this.ItemName = ItemName;        
    }
    public ItemNode() {
        ;
    }
}