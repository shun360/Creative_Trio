using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using CommandType;


public class PinDeck : MonoBehaviour
{
    public static List<ct> Deck = new List<ct>();
    public static List<ct> GetAllPinDeck() { return Deck; }
    public static void AddPinDeck(ct pin)
    {
        Deck.Add(pin);
        Debug.Log("�f�b�L��" + pin + "�ǉ�");
    }
    public static void Shuffle()
    {
        for(int i = Deck.Count - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            ct tmp = Deck[i];
            Deck[i] = Deck[j];
            Deck[j] = tmp;
        }
        Debug.Log("�f�b�L���V���b�t��");
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i < 3; i++)//�����f�b�L(attack*3, block*3)
        {
            AddPinDeck(ct.Attack);
            AddPinDeck(ct.Block);
        }
        Shuffle();
    }
}
