using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://www.bsidesoft.com/215
public class Inventory : MonoBehaviour
{    
    [Header("Inventroy Cargo")]
    [Range(-1, 100)] //-1 = 무한대
    public int itemCargoSize = 10;
    [SerializeField]
    private int nowCargoSize = 0;

    Dictionary<int, int> ItemCargo = new Dictionary<int, int>();      //아이템 개수 <key:ItemID,Value:Itemcount>
    Dictionary<int, ItemNode> ItemData = new Dictionary<int, ItemNode>();   //아이템 정보 (아이템 ID를 받으면 아이템 정보를 넘겨줌)


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) {
            string ans = "";
            foreach (KeyValuePair<int, int> temp in ItemCargo) {
                ans += "Item [" + ItemData[temp.Key].getName() + "] are [" + temp.Value + "]in cargo \n";
            }
            Debug.Log(ans + "\n Weight : " + nowCargoSize + "/" + itemCargoSize);       // (ItemCargoSize == -1 ? "∞" : ItemCargoSize)
        }
    }
    public void OnGUI() {
        Event e = Event.current;
        if (e.isKey && Input.anyKey) {
            UseItem(e.keyCode);
        }
    }
    public void UseItem(KeyCode keyInput)          //되~게 비효율적인 방법같은데
    {
        int input = NumKeyReturn(keyInput);
        int i = 0;
        foreach (KeyValuePair<int, int> temp in ItemCargo) {
            i++;
            if (i == input) {
                Debug.Log("Using " + ItemData[temp.Key].getName() + ", left : " + (temp.Value - 1));
                Instantiate(ItemManager.instance.GetItem(ItemData[temp.Key].getName()));

                break;
            }
        }
    }
    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Item") Debug.Log("touch");

        
        if (other.gameObject.tag == "Item") {
            ItemNode tempNode = other.GetComponent<ItemNode>();

            
            int ItemID = tempNode.ItemID;
            if (nowCargoSize!=0&&ItemCargo.ContainsKey(ItemID) == true) {
                ItemCargo[ItemID]++;
            }
            else {
                ItemCargo.Add(ItemID, 1);
                ItemNode inputNode = tempNode;
                ItemData.Add(ItemID, inputNode);
            }
            nowCargoSize++;
            Destroy(other.gameObject);
        }        
        
    }

    private int NumKeyReturn(KeyCode keyInput) {

        switch (keyInput) {
            case KeyCode.Alpha1: {
                    return 1;
                }
            case KeyCode.Keypad1: {
                    return 1;
                }
            case KeyCode.Alpha2: {
                    return 2;
                }
            case KeyCode.Keypad2: {
                    return 2;
                }
            case KeyCode.Alpha3: {
                    return 3;
                }
            case KeyCode.Keypad3: {
                    return 3;
                }
            case KeyCode.Alpha4: {
                    return 4;
                }
            case KeyCode.Keypad4: {
                    return 4;
                }
            case KeyCode.Alpha5: {
                    return 5;
                }
            case KeyCode.Keypad5: {
                    return 5;
                }
            case KeyCode.Alpha6: {
                    return 6;
                }
            case KeyCode.Keypad7: {
                    return 7;
                }
            case KeyCode.Alpha8: {
                    return 8;
                }
            case KeyCode.Keypad9: {
                    return 9;
                }
            case KeyCode.Alpha0: {
                    return 0;
                }
            default: {
                    return 0;
                }
        }
    }

}
