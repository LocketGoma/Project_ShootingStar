using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBlock : MonoBehaviour {
    [SerializeField] private Image itemImage;
    [SerializeField] private Text itemCountText;
    [SerializeField] private int itemNo;
    [SerializeField] private int itemCount;
    [SerializeField] private bool isUsing = false;
    [SerializeField] private Sprite OriginalitemImage;

    public int ItemNo { get { return itemNo; } set { itemNo = value; } }

    private void Start() {
        OriginalitemImage = itemImage.sprite;
    }
    public void ImageUpdate(Sprite input) {
        itemImage.sprite = input;        
    }
    
    public void ItemCount (int input) {
        isUsing = true;
        itemCount = input;
        itemCountText.text = input.ToString();
    }

    private void Update() {
        if (itemCount == 0 && isUsing) {
            itemImage.sprite = OriginalitemImage;
            itemCountText.text = "";
            isUsing = false;
        }
    }


}
