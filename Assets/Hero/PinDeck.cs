using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using CommandType;


public class PinDeck : MonoBehaviour
{
    public static List<Ct> Deck = new List<Ct>();
    public static List<Ct> GetAllPinDeck() { return Deck; }
    public static void AddPinDeck(Ct pin)
    {
        Deck.Add(pin);
        Debug.Log("�f�b�L��" + pin + "�ǉ�");
    }
    public static void Shuffle()
    {
        for(int i = Deck.Count - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            Ct tmp = Deck[i];
            Deck[i] = Deck[j];
            Deck[j] = tmp;
        }
        Debug.Log("�f�b�L���V���b�t��");
    }

    void Start()
    {
        for(int i = 0;i < 3; i++)//�����f�b�L(attack*3, block*3)
        {
            AddPinDeck(Ct.Attack);
            AddPinDeck(Ct.Block);
        }
        Shuffle();
    }
    //��V
    public void AddFireball()
    {
        AddPinDeck(Ct.Fireball);
    }
    public void AddDoubleAttack()
    {
        AddPinDeck(Ct.DoubleAttack);
    }
    public void AddDoubleBlock()
    {
        AddPinDeck(Ct.DoubleBlock);
    }
    public void AddDebffATK()
    {
        AddPinDeck(Ct.DebuffDEF);
    }
    public void AddDebuffDEF()
    {
        AddPinDeck(Ct.DebuffDEF);
    }
    public void AddBuffATK()
    {
        AddPinDeck(Ct.BuffATK);
    }
    public void AddBuffDEF()
    {
        AddPinDeck(Ct.BuffDEF);
    }
    public void AddTwiceAOE()
    {
        AddPinDeck(Ct.TwiceAOE);
    }
    public void AddRandomTwiceAttack()
    {
        AddPinDeck(Ct.RandomTwiceAttack);
    }
}
