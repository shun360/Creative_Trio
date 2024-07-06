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


        //�A�C�e���̃C���[�W�𕡐�
        draggingObj = Instantiate(itemImageObj, canvasTransform);

        //�������őO�ʂɔz�u
        draggingObj.transform.SetAsLastSibling();

        //�������̐F���Â�����
        itemImage.color = Color.gray;

        //����l�ɃA�C�e����n��
        hand.SetGrabbingItem(MyItem);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (MyItem == null) return;

        //�������|�C���^�[��Ǐ]����悤�ɂ���
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
        //����l���A�C�e���������Ă��Ȃ������瑁��return
        if (!hand.IsHavingItem()) return;

        //����l����A�C�e�����󂯎��
        Item gotItem = hand.GetGrabbingItem();

        //���Ƃ��Ǝ����Ă����A�C�e���𒇉�l�ɓn��
        hand.SetGrabbingItem(MyItem);

        SetItem(gotItem);
    }

    //OnDrop����ɌĂ΂��
    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(draggingObj);

        //����l����A�C�e�����󂯎��

        Item gotItem = hand.GetGrabbingItem();
        SetItem(gotItem);
    }
}
