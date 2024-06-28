using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class HeroPinDeck : MonoBehaviour
{
    public static List<PinType> PinDeck = new List<PinType>();
    
    public static List<PinType> GetAllPinDeck() { return PinDeck; }
    public static void AddPinDeck(PinType pin)
    {
        PinDeck.Add(pin);
        Debug.Log("デッキに" + pin + "追加");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i < 3; i++)//初期デッキ(attack*3, block*3)
        {
            AddPinDeck(PinType.attackPin);
            AddPinDeck(PinType.blockPin);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
