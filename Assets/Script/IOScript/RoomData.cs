using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

//방&필드 정보
[Serializable]
public class RoomData {
    [SerializeField] public int RoomNo;   //방 번호
    [SerializeField] public int Axis_LX;
    [SerializeField] public int Axis_LY;
    [SerializeField] public int Axis_RX;
    [SerializeField] public int Axis_RY;
}
