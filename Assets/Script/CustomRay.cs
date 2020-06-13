using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://github.com/Unity-Technologies/UnityCsReference/blob/master/Runtime/Export/Geometry/Ray.cs
public class CustomRay
{
    private Vector3 _Origin;     //기본값
    private Vector3 _Direction;  //좌표값?

    public Vector3 Origin { get { return _Origin; } set { _Origin = value; } }
    public Vector3 Direction { get { return _Direction; } set { _Direction = value; } }
    public CustomRay(Vector3 origin, Vector3 direction) {
        _Origin = origin;
        _Direction = direction.normalized;      //벡터 정규화 (방향만 살리고 크기를 1.0으로 조절)
    }

}
