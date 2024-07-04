using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour,IBeginDragHandler,IDragHandler,IDropHandler,IEndDragHandler
{
    private Item item;

    [SerializeField]
    private Image itemImage;

    private GameObject draggingObj;

    [SerializeField]
    private GameObject itemImageObj;

    private Transform canvasTransform;

    private Hand hand;

    public Item MyItem { get => item; private set => item = value; }

    protected virtual void Start()
    {
        canvasTransform = FindObjectOfType<Canvas>().transform;

        hand = FindObjectOfType<Hand>();

        if (MyItem == null) itemImage.color = new Color(0, 0, 0, 0);

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (MyItem == null) return;


        //アイテムのイメージを複製
        draggingObj = Instantiate(itemImageObj, canvasTransform);

        //複製を最前面に配置
        draggingObj.transform.SetAsLastSibling();

        //複製元の色を暗くする
        itemImage.color = Color.gray;

        //仲介人にアイテムを渡す
        hand.SetGrabbingItem(MyItem);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (MyItem == null) return;

        //複製がポインターを追従するようにする
        draggingObj.transform.position 
            = hand.transform.position + new Vector3(10,10,0);
    }

    public void SetItem(Item item)
    {
        MyItem = item;

        if (item != null)
        {
            itemImage.color = new Color(1, 1, 1, 1);
            itemImage.sprite = item.MyItemImage;
        }
        else
        {
            itemImage.color = new Color(0, 0, 0, 0);
        }

    }

    public virtual void OnDrop(PointerEventData eventData)
    {
        //仲介人がアイテムを持っていなかったら早期return
        if (!hand.IsHavingItem()) return;

        //仲介人からアイテムを受け取る
        Item gotItem = hand.GetGrabbingItem();

        //もともと持っていたアイテムを仲介人に渡す
        hand.SetGrabbingItem(MyItem);

        SetItem(gotItem);
    }

    //OnDropが先に呼ばれる
    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(draggingObj);

        //仲介人からアイテムを受け取る

        Item gotItem = hand.GetGrabbingItem();
        SetItem(gotItem);
    }
}
