using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class HeroClass
{

    //status
    [SerializeField] private int maxHP;
    [SerializeField] private int nowHP;
    [SerializeField] private readonly int oriATK;//setterなし
    [SerializeField] private int nowATK;
    [SerializeField] private readonly int oriDEF;//防御ピンから得られるブロック、setterなし
    [SerializeField] private int nowDEF;
    [SerializeField] private readonly int oriMagiATK;
    [SerializeField] private int nowMagiATK;
    [SerializeField] private int block; //ダメージを防御ブロックできる値
    [SerializeField] private int targetNumber;
    //コンストラクタ
    public HeroClass()
    {
        maxHP = 100;
        nowHP = 100;
        oriATK = 8;
        nowATK = oriATK;
        oriDEF = 5;
        nowDEF = oriDEF;
        oriMagiATK = 15;
        nowMagiATK = oriMagiATK;
        block = 0;
        targetNumber = 0;
    }
    
    //getter, setter
    public int MaxHP
    {
        get { return maxHP; }
        set { maxHP = value; }
    }
    public int NowHP
    {
        get { return nowHP; }
        set { nowHP = value; }
    }
    public int OriATK
    {
        get { return oriATK; }
    }
    public int NowATK
    {
        get { return nowATK; }
        set { nowATK = value; }
    }
    public int OriDEF
    {
        get { return oriDEF; }
    }
    public int NowDEF
    {
        get { return nowDEF; }
        set { nowDEF = value; }
    }
    public int OriMagiATK
    {
        get { return oriMagiATK; }
    }
    public int NowMagiATK
    {
        get { return nowMagiATK; }
        set { nowMagiATK = value; }
    }
    public int Block
    {
        get { return block; }
        set { block = value; }
    }
    public int TargetNumber
    {
        get { return targetNumber; }
        set { targetNumber = value; }
    }
    //other method
    public void AddBlock() { block += nowDEF; }//ブロック値をプラスする
    public void TakeAttacked(int damage) //攻撃を受ける
    {
        if (block >= damage)
        {
            block -= damage;
            Debug.Log(damage + "ダメージをすべてブロックした");
        }
        else if (block <= 0)
        {
            nowHP -= damage;
            Debug.Log(damage + "ダメージを受けた");
        }
        else
        {
            int oriDamage = damage;//デバッグ用
            damage -= block;
            nowHP -= damage;
            Debug.Log(oriDamage + "ダメージのうち、" + damage + "ダメージを受けた");
        }

    }
    
    
}
