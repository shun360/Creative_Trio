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
        Debug.Log("デッキに" + pin + "追加");
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
        Debug.Log("デッキをシャッフル");
    }

    void Start()
    {
        for(int i = 0;i < 3; i++)//初期デッキ(attack*3, block*3)
        {
            AddPinDeck(Ct.Attack);
            AddPinDeck(Ct.Block);
        }
        Shuffle();
    }
    //報酬
    public void AddFireball()
    {
        AddPinDeck(Ct.Fireball);
    }
    public void AddSmash()
    {
        AddPinDeck(Ct.Smash);
    }
    public void AddProtection()
    {
        AddPinDeck(Ct.Protection);
    }
    public void AddCurseATK()
    {
        AddPinDeck(Ct.CurseATK);
    }
    public void AddPenetration()
    {
        AddPinDeck(Ct.Penetration);
    }
    public void AddExtendATK()
    {
        AddPinDeck(Ct.ExtendATK);
    }
    public void AddExtendDEF()
    {
        AddPinDeck(Ct.ExtendDEF);
    }
    public void AddTwiceAOE()
    {
        AddPinDeck(Ct.TwiceAOE);
    }
    public void AddRandomTripleAttack()
    {
        AddPinDeck(Ct.RandomTripleAttack);
    }
    public void AddOnlyOne()
    {
        AddPinDeck(Ct.OnlyOne);
        GameManager.Instance.onlyOne = true;
        FindObjectOfType<HeroScript>().SumMagiATK(20);
    }
}
