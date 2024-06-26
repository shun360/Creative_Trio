using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class HeroClass : MonoBehaviour
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
        HeroBlock = 0;
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
    //other method
    public void AddHeroBlock() { HeroBlock += HeroNowDEF; }//ブロック値をプラスする
    public void BeAttacked(int damage) //攻撃を受ける
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
    public void HeroMove(Vector3 target)//未テスト
    {
        Vector3 velocity = Vector3.zero;
        Vector3.SmoothDamp(transform.position, target, ref velocity, 0.7f);
    }
    
}
