using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeroClass : MonoBehaviour
{

    //status
    private int maxHP;
    private int nowHP;
    private int oriATK;//setterなし
    private int nowATK;
    private int oriDEF;//防御ピンから得られるブロック、setterなし
    private int nowDEF;
    private int oriMagiATK;
    private int nowMagiATK;
    private int block; //ダメージを防御ブロックできる値
    protected Vector3 velocity = Vector3.zero;
    protected int targetNumber = 0;
    protected Vector3 targetPosition;
    protected bool shouldMove = false;
    protected bool isReturning = false;
    protected Vector3 originPosition;
    //コンストラクタ
    public void Init()
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
   
    //other method

    public void AddBlock() 
    {
        block += nowDEF;
        Debug.Log($"{nowDEF}ブロック追加して、{block}ブロックになりました");
    }//ブロック値をプラスする
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
    public void StatusReset()
    {
        nowATK = oriATK;
        nowDEF = oriDEF;
        nowMagiATK = oriMagiATK;

    }
    public void KnockBack()
    {
        HeroMove(-5, -5);
    }
    protected void HeroMove(float x, float y)
    {
        shouldMove = true;
        targetPosition = new Vector3(transform.position.x + x, transform.position.y + y, 0);
        Debug.Log($"HeroMoveが呼ばれた時のtargetPosition: {targetPosition}");
    }
    protected void AttackMotion()
    {
        HeroMove(10, 10);
    }

    public void LevelUp()
    {
        oriATK += 1;
        oriDEF += 1;
        oriMagiATK += 3;
        Debug.Log("LevelUp! 攻撃力と防御力が1上がった 魔法攻撃力が3上がった");
    }
    protected virtual void Awake()
    {
        Init();
        originPosition = new Vector3(15, 15, 0);
        transform.position = originPosition;
    }
    public void Heal(int amount)
    {
        if(nowHP + amount > MaxHP)
        {
            nowHP = MaxHP;
        }
        else
        {
            nowHP += amount;
        }
    }
    //報酬

    public void FullHeal()
    {
        Heal(MaxHP);
    }
    public void GrowATK()
    {
        oriATK += 5;
    }
    public void GrowDEF()
    {
        oriDEF += 5;
    }
    public void GrowMagiATK()
    {
        oriMagiATK += 25;
    }
}
