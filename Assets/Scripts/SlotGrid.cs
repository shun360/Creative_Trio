using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SlotGrid : MonoBehaviour
{
    [SerializeField]
    private GameObject slotPrehab;

    private int slotNumber = 20;

    [SerializeField]
    private Item[] allItems;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < slotNumber; i++)
        {
            GameObject slotObj = Instantiate(slotPrehab, this.transform);

            Slot slot = slotObj.GetComponent<Slot>();

            //スロットにアイテムをセットしたい
            if (i < allItems.Length)
            {
                slot.SetItem(allItems[i]);
            }
            else
            {
                slot.SetItem(null);
            }
        }
    }

}
