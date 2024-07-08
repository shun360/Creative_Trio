using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public class PinDeck : MonoBehaviour
{
    public static List<CommandType> Deck = new List<CommandType>();
    public static List<CommandType> GetAllPinDeck() { return Deck; }
    public static void AddPinDeck(CommandType pin)
    {
        Deck.Add(pin);
        Debug.Log("デッキに" + pin + "追加");
    }
    public static void Shuffle()
    {
        for(int i = Deck.Count - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            CommandType tmp = Deck[i];
            Deck[i] = Deck[j];
            Deck[j] = tmp;
        }
        Debug.Log("デッキをシャッフル");
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i < 3; i++)//初期デッキ(attack*3, block*3)
        {
            AddPinDeck(CommandType.Attack);
            AddPinDeck(CommandType.Block);
        }
        Shuffle();
    }
}
