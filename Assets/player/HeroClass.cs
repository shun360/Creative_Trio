using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class HeroClass
{

    //status
    [SerializeField] private int heroMaxHP;
    [SerializeField] private int heroNowHP;
    [SerializeField] private readonly int heroOriATK;//setterなし
    [SerializeField] private int heroNowATK;
    [SerializeField] private readonly int heroOriDEF;//防御ピンから得られるブロック、setterなし
    [SerializeField] private int heroNowDEF;
    [SerializeField] private readonly int heroOriMagiATK;
    [SerializeField] private int heroNowMagiATK;
    [SerializeField] private int heroBlock; //ダメージを防御ブロックできる値
    [SerializeField] private int targetNumber;
    //コンストラクタ
    public HeroClass()
    {
        heroMaxHP = 100;
        heroNowHP = 100;
        heroOriATK = 8;
        heroNowATK = heroOriATK;
        heroOriDEF = 5;
        heroNowDEF = heroOriDEF;
        heroOriMagiATK = 15;
        heroNowMagiATK = heroOriMagiATK;
        heroBlock = 0;
        targetNumber = 0;
    }
    
    //getter, setter
    public int HeroMaxHP
    {
        get { return heroMaxHP; }
        set { heroMaxHP = value; }
    }
    public int HeroNowHP
    {
        get { return heroNowHP; }
        set { heroNowHP = value; }
    }
    public int HeroOriATK
    {
        get { return heroOriATK; }
    }
    public int HeroNowATK
    {
        get { return heroNowATK; }
        set { heroNowATK = value; }
    }
    public int HeroOriDEF
    {
        get { return heroOriDEF; }
    }
    public int HeroNowDEF
    {
        get { return heroNowDEF; }
        set { heroNowDEF = value; }
    }
    public int HeroOriMagiATK
    {
        get { return heroOriMagiATK; }
    }
    public int HeroNowMagiATK
    {
        get { return heroNowMagiATK; }
        set { heroNowMagiATK = value; }
    }
    public int HeroBlock
    {
        get { return heroBlock; }
        set { heroBlock = value; }
    }
    public int TargetNumber
    {
        get { return targetNumber; }
        set { targetNumber = value; }
    }
    //other method
    public void AddHeroBlock() { HeroBlock += HeroNowDEF; }//ブロック値をプラスする
    public void TakeAttacked(int damage) //攻撃を受ける
    {
        if (HeroBlock >= damage)
        {
            HeroBlock -= damage;
            Debug.Log(damage + "ダメージをすべてブロックした");
        }
        else if (HeroBlock <= 0)
        {
            HeroNowHP -= damage;
            Debug.Log(damage + "ダメージを受けた");
        }
        else
        {
            int oriDamage = damage;//デバッグ用
            damage -= HeroBlock;
            HeroNowHP -= damage;
            Debug.Log(oriDamage + "ダメージのうち、" + damage + "ダメージを受けた");
        }

    }
    
    
}
