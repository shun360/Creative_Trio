using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerSlot : Slot
{
    private Player player;

    public Player MyPlayer { get => player; private set => player = value; }



    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        MyPlayer = FindObjectOfType<Player>();
    }
    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);
        player.SetItem(MyItem);
    }

}
