using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class HeroPinDeck : MonoBehaviour
{
    public static List<PinTypes.PinType> PinDeck = new List<PinTypes.PinType>();
    
    public static List<PinTypes.PinType> GetAllPinDeck() { return PinDeck; }
    public static void AddPinDeck(PinTypes.PinType pin)
    {
        PinDeck.Add(pin);
        Debug.Log("ƒfƒbƒL‚É" + pin + "’Ç‰Á");
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
