using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance;
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] inventoryBlocks;       //인벤토리 한칸한칸
    [SerializeField]
    private GameObject invenBlockSample;
    [SerializeField]
    private Sprite[] ItemImages;
    private int inventorySize;

    void Start() {
        inventorySize = ItemManager.instance.ItemListCount;
        inventoryBlocks = new GameObject[inventorySize];

        for (int i = 0; i < inventorySize; i++) {
            Instantiate(invenBlockSample).transform.parent = gameObject.transform;
            inventoryBlocks[i] = transform.GetChild(i).gameObject;            
        }
    }
    public void ItemListUpdate(Dictionary<int, int> itemCargo) {
       int i = 0;
       foreach (KeyValuePair<int,int> temp in itemCargo) { 
        //for (int i = 0; i < itemCargo.Count; i++) {
            var block = inventoryBlocks[i].GetComponent<InventoryBlock>();
            Debug.Log(ItemImages.Length);
            block.ImageUpdate(ItemImages[temp.Key-1]);
            block.ItemCount(temp.Value);
            block.ItemNo = temp.Key;
            i++;
        }
        ItemClear(itemCargo.Count);
    }
    public void ItemClear(int cargoSize) {
        for(int i = cargoSize; i < inventoryBlocks.Length; i++) {
            inventoryBlocks[i].GetComponent<InventoryBlock>().ItemCount(0);
        }

    }
    
    public void ItemCountUpdate(int itemID, int itemCount) {
        foreach (GameObject blocks in inventoryBlocks) {
            if (blocks.GetComponent<InventoryBlock>().ItemNo == itemID) {
                blocks.GetComponent<InventoryBlock>().ItemCount(itemCount);
                break;
            }
        }
    }
}
