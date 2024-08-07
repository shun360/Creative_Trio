using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour,IPointerClickHandler
{
    private Item item;
    [SerializeField]
    private int atk;

    [SerializeField]

    public int MyAtk
    {
        get
        {
            Armor armor = MyItem as Armor;

            int itemAtk = 0;
            if (armor != null) itemAtk = armor.MyAtk;
            return atk + itemAtk;
        }
    }

    public Item MyItem { get => item; set => item = value; }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("攻撃力は" + MyAtk + "です");
    }

    public void SetItem(Item item)
    {
        MyItem = item;
        Debug.Log("装備アイテムは" + MyItem.MyItemName + "です");
    }
}
