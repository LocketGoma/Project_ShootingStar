using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

//https://202psj.tistory.com/1261
public class JsonParser : MonoBehaviour
{
    //중요한 파일 포인터니까 CC 대문자로
    private TextAsset LoadJson = null;
    
    private LoadData loadData = null;
    public LoadData LoadData { get { return loadData; } }
    private bool LoadDataState = true;

    
    public void Init()
    {
        LoadJson = (TextAsset)Resources.Load("result", typeof(TextAsset));
        LoadDataState = LoadJson != null;
        if (LoadDataState == true) {
            loadData = JsonUtility.FromJson<LoadData>(LoadJson.ToString());


        } else {
            Debug.LogError("Json 파일 읽기 실패");
        }
    }

}
