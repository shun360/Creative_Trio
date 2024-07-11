using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Data.SqlTypes;
using UnityEditor.Search;
using UnityEditor.Experimental.GraphView;


public class HeroScript : MonoBehaviour
{
    //status
    public int maxHP;
    public int nowHP;
    public int oriATK;
    public int nowATK;
    public int oriDEF;//防御ピンから得られるブロック
    public int nowDEF;
    public int oriMagiATK;
    public int nowMagiATK;
    public int block; //ダメージを防御ブロックできる値
    protected Vector3 velocity = Vector3.zero;
    public int targetNumber = 0;
    protected Vector3 targetPosition;
    protected bool shouldMove = false;
    protected bool isReturning = false;
    protected Vector3 originPosition;
    private MonsterScript mons;

    public void Init()//初期化
    {
        maxHP = 100;
        nowHP = 100;
        oriATK = 8;
        nowATK = oriATK;
        oriDEF = 5;
        nowDEF = oriDEF;
        oriMagiATK = 7;
        nowMagiATK = oriMagiATK;
        block = 0;
    }
    public IEnumerator BuffATK(int amount)
    {
        nowATK += amount;
        Debug.Log($"攻撃力が{amount}上がって、{nowATK}になりました");
        yield return new WaitForSeconds(1);
    }
    public IEnumerator BuffDEF(int amount)
    {
        nowDEF += amount;
        Debug.Log($"防御力が{amount}上がって、{nowDEF}になりました");
        yield return new WaitForSeconds(1);
    }
    public IEnumerator DebuffATK(int amount)
    {
        if (amount > nowATK)
        {
            amount = nowATK;
        }
        nowATK -= amount;
        Debug.Log($"攻撃力が{amount}下がって、{nowATK}になりました");
        yield return new WaitForSeconds(1);
    }
    public IEnumerator DebuffDEF(int amount)
    {
        if (amount > nowDEF)
        {
            amount = nowDEF;
        }
        nowDEF -= amount;
        Debug.Log($"防御力が{amount}下がって、{nowDEF}になりました");//FixMe:演出
        yield return new WaitForSeconds(1);
    }
    public IEnumerator Attack()
    {
        Debug.Log("Heroの攻撃");
        AttackMotion();
        MonsterClass t = MonsterScript.monList[targetNumber].GetComponent<MonsterClass>();
        yield return new WaitForSeconds(0.2f);
        t.TakeAttacked(nowATK);
        yield return new WaitForSeconds(0.8f);
    }
    public IEnumerator AddBlock()
    {
        block += nowDEF;
        Debug.Log($"{nowDEF}ブロック追加して、{block}ブロックになりました");
        yield return new WaitForSeconds(1);//FixMe:エフェクト追加
    }//ブロック値をプラスする
    public IEnumerator Fireball()
    {
        Debug.Log("Heroの魔法攻撃");
        AttackMotion();
        yield return new WaitForSeconds(0.2f);
        mons.TakeAOE(nowMagiATK);
        yield return new WaitForSeconds(0.8f);//FixMe:魔法エフェクト追加
    }
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
            block = 0;
            KnockBack();
            Debug.Log($"{damage}ダメージを受け、残り体力が{nowHP}になった");
        }
        else
        {
            int oriDamage = damage;//デバッグ用
            damage -= block;
            nowHP -= damage;
            block = 0;
            KnockBack();
            Debug.Log($"{oriDamage}ダメージのうち、{damage}ダメージを受け、HPが{nowHP}になった");
        }

    }
    public void BlockZero()
    {
        block = 0;
        Debug.Log("ブロック値を0にしました");
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

    }
    protected void AttackMotion()
    {
        HeroMove(10, 10);
    }

    public IEnumerator LevelUp()
    {
        oriATK += 1;
        oriDEF += 1;
        oriMagiATK += 3;
        Debug.Log("LevelUp! 攻撃力と防御力が1上がった 魔法攻撃力が3上がった");
        yield return new WaitForSeconds(1); 
    }
    public void ChangeTarget()
    {
        if (targetNumber < MonsterScript.monList.Count - 1)
        {
            targetNumber++;

        }
        else
        {
            targetNumber = 0;
        }
        FindObjectOfType<TargetDisplay>().DispTarget();
        Debug.Log($"ターゲットを{targetNumber}のモンスターに変更");
    }
    public IEnumerator ResetTarget()
    {
        yield return new WaitForSeconds(0.01f);
        targetNumber = 0;
        FindObjectOfType<TargetDisplay>().DispTarget();
    }
    
    public void Heal(int amount)
    {
        if (nowHP + amount > maxHP)
        {
            amount = maxHP - nowHP;
        }
        nowHP += amount;
        Debug.Log($"{amount}回復して、HPが{nowHP}になりました");
    }

    //報酬

    public void FullHeal()
    {
        Heal(maxHP);
    }
    public void GrowATK()
    {
        oriATK += 5;
        nowATK += 5;
    }
    public void GrowDEF()
    {
        oriDEF += 5;
        nowDEF += 5;
    }
    public void GrowMagiATK()
    {
        oriMagiATK += 25;
        nowMagiATK -= 25;
    }
    //MonoBehaviour
    protected virtual void Awake()
    {
        Init();
        originPosition = new Vector3(15, 15, 0);
        transform.position = originPosition;
        mons = FindObjectOfType<MonsterScript>();
    }
    void Start()
    {
        Debug.Log("Start");
        
    }
    
    void Update()
    {
        if (shouldMove)
        {
            if (isReturning)
            {
                if (Vector3.Distance(transform.position, originPosition) < 0.1f)
                {
                    shouldMove = false;
                    velocity = Vector3.zero;
                    isReturning = false;
                    
                }
                else
                {
                    transform.position = Vector3.SmoothDamp(transform.position, originPosition, ref velocity, 0.1f);
                }
            }
            else
            {
                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                {
                    isReturning = true;
                    targetPosition = originPosition;
                    
                }
                else
                {
                    transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0.1f);
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.T))
        {

            ChangeTarget();
            
        }
        if (nowHP <= 0)
        {
            Debug.Log("GAME OVER!");
            //ゲームオーバー処理を書く
            GameOver();
        }

    }
    void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
