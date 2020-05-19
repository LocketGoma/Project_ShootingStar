using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    [SerializeField] private string[] ItemList;

    Dictionary<string, GameObject> allItemList = new Dictionary<string, GameObject>();      //현존하는 아이템 리스트 전부 Load
    Dictionary<string, GameObject> getItemList = new Dictionary<string, GameObject>();      //먹었던 아이템 리스트


    public void Start() {
        object[] temp = Resources.LoadAll("Prefab/Items");
        ItemList = new string[temp.Length];
        int i = 0;
        foreach (object tp in temp) {
            GameObject tpp = (GameObject)(tp);
            allItemList.Add(tpp.name, tpp);
            ItemList[i++] = tpp.name;
        }

        if (allItemList.Count == 0) {
            Debug.LogError("아이템 리스트 불러오기 실패!!!!");
        }

    }


    public GameObject GetItem(string name) {
        foreach(KeyValuePair<string,GameObject> temp in getItemList) {
            if (temp.Key.Equals(name))
                return temp.Value; 
        }
        foreach (KeyValuePair<string, GameObject> temp in allItemList) {
            if (temp.Key.Equals(name)) {
                getItemList.Add(temp.Key,temp.Value);
                return temp.Value;
            }
        }
        Debug.LogError("잘못된 아이템을 불러오고 있습니다.\nItemManager.GetItem();");
        return null;
    }
}
