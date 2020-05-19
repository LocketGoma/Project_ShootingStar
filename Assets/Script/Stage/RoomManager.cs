using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager instance;

    [SerializeField] private LoadData loadData;
    [SerializeField] private GameObject[] RoomList;     //Room List
    [SerializeField] private GameObject RoomSample;     //Room Sample Prefab
    [SerializeField] private int roomCount;
    public JsonParser jsonParser;
    public int RoomCount { get { return roomCount; } set { roomCount = value; } }


    // Start is called before the first frame update
    void Start()
    {
        jsonParser.Init();
        loadData = jsonParser.LoadData;

        if (loadData != null && RoomSample != null) {
            roomCount = loadData.RoomCount;
            Debug.Log(loadData.RoomCount);
            RoomList = new GameObject[loadData.RoomCount];


            for (int i = 0; i < roomCount; i++) {
                Instantiate(RoomSample).transform.parent = gameObject.transform; ;
                RoomList[i] = transform.GetChild(i).gameObject;
                RoomList[i].GetComponent<Room>().Initialized(loadData.Room[i]);
            }
        } else {
            Debug.LogError("Error : Can not make Room");
        }
    }


}
