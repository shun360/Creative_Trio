using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class HeroPinDeck : MonoBehaviour
{
    public static List<CommandType> PinDeck = new List<CommandType>();
    
    public static List<CommandType> GetAllPinDeck() { return PinDeck; }
    public static void AddPinDeck(CommandType pin)
    {
        PinDeck.Add(pin);
        Debug.Log("�f�b�L��" + pin + "�ǉ�");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i < 3; i++)//�����f�b�L(attack*3, block*3)
        {
            AddPinDeck(CommandType.Attack);
            AddPinDeck(CommandType.Block);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
