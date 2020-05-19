﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonManager : MonoBehaviour
{
    public static SingletonManager instance;

    [SerializeField] ItemManager itemManager = null;
    [SerializeField] RoomManager roomManager = null;



    private void Awake() {
        instance = this;

        ItemManager.instance = itemManager;
        RoomManager.instance = roomManager;

    }


}
