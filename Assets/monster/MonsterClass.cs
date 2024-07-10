using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterSet;
using UnityEngine.UI;
[System.Serializable]

public class MonsterClass : MonoBehaviour
{

    public static List<GameObject> existMonsters = new List<GameObject>();
    protected int maxHP;
    protected int nowHP;
    protected int oriATK;
    protected int nowATK;
    protected int oriDEF;
    protected int nowDEF;
    protected int block;
    protected mt thistype;
    protected bool shouldMove = false;
    protected bool isReturning = false;
    protected Vector3 originPosition;
    protected Vector3 velocity = Vector3.zero;
    protected Vector3 targetPosition;
    private HeroScript hero;
    
    private SpriteRenderer rend;
    protected bool isLiving = false;
    protected List<List<mc>> actPattern;

    //[SerializeField] 
    protected virtual void Awake()
    {
        hero = FindObjectOfType<HeroScript>();
        targetPosition = hero.transform.position;
        rend = GetComponent<SpriteRenderer>();
        originPosition = transform.position;
        actPattern = ActSet();
        isLiving = true;
    }
    public virtual void Init()
    {
        Debug.Log("MonsterClassのInit()");
        thistype = mt.NoneMonster;
        StatusSet(thistype, 30, 11, 6);
    }
    protected void StatusSet(mt type,int hp, int atk, int def) 
    {
        LoadSprite(type);
        this.maxHP = hp;
        this.nowHP = hp;
        this.oriATK = atk;
        this.nowATK = atk;
        this.oriDEF = def;
        this.nowDEF = def;
        StartCoroutine(FadeIn());
    }
    protected virtual List<List<mc>> ActSet()//行動パターン設定
    {
        List<List<mc>> actPattern = new List<List<mc>>();
        int cycle = 2;
        for (int i = 0; i < cycle; i++)
        {
            List<mc> act = new List<mc>();
            switch (i)
            {
                case 0:
                    act.Add(mc.Attack);
                    break;
                case 1:
                    act.Add(mc.Block);
                    break;
            }
            actPattern.Add(act);
        }
        return actPattern;
    }
    public IEnumerator Act()
    {
        List<mc> act = actPattern[(GameManager.Instance.turn - 1) % actPattern.Count];
        for (int i = 0; i < act.Count; i++)
        {
            switch (act[i]) 
            { 
                case mc.Attack:
                    yield return Attack();
                    break;
                case mc.Block:
                    yield return AddBlock();
                    break;
                case mc.Buff:
                    yield return Buff();
                    break;
                case mc.Debuff:
                    yield return Debuff();
                    break;
                case mc.Obstruction:
                    yield return Obstruction();
                    break;

            }
        }
    }
    public void BlockZero()
    {
        block = 0;
        Debug.Log("ブロック値を0にしました");
    }
    
    protected void Move(float x, float y)
    {
        shouldMove = true;
        targetPosition = new Vector3(transform.position.x + x, transform.position.y + y, 0);
        Debug.Log($"MonsterのMoveが呼ばれた時のtargetPosition: {targetPosition}");
    }
    public IEnumerator Attack()
    {
        AttackMotion();
        yield return new WaitForSeconds(0.2f);
        
        hero.TakeAttacked(nowATK);
        yield return new WaitForSeconds(0.8f);
    }
    public IEnumerator AddBlock()
    {
        block += nowDEF;
        Debug.Log($"{thistype}が{nowDEF}ブロック追加して、{block}ブロックになりました");
        yield return new WaitForSeconds(1);//FixMe:エフェクト追加
    }
    public virtual IEnumerator Buff()
    {
        Debug.LogError("定義されていないBuff()が呼ばれました。オーバーライドしてください。");
        yield return null;
    }
    public virtual IEnumerator Debuff()
    {
        Debug.LogError("定義されていないDeBuff()が呼ばれました。オーバーライドしてください。");
        yield return null;
    }
    public virtual IEnumerator Obstruction()
    {
        Debug.LogError("定義されていないObstruction()が呼ばれました。オーバーライドしてください。");
        yield return null;
    }
    public void AttackMotion()
    {
        Move(-10, -10);
    }
    public void KnockBack()
    {
        Move(5, 5);
    }
    public virtual void ChangeStatus(bd target, int turn, int amount)
    {
        switch (target)
        {
            case bd.atk:
                nowATK += amount;
                break;
                case bd.def:
                nowDEF += amount;
                break;
        }
        //turn数を管理する仕組みを作る
    }
    

    protected void LoadSprite(mt t)
    {
        Debug.Log($"{t}の画像を読み込みます");
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"{t}");
        
    }

    
    public void TakeAttacked(int damage) //攻撃を受ける
    {
        if (block >= damage)
        {
            block -= damage;
            Debug.Log($"{thistype}:" + damage + "ダメージをすべてブロックした");
        }
        else if (block <= 0)
        {
            nowHP -= damage;
            KnockBack();
            Debug.Log($"{thistype}:" + damage + "ダメージを受けた");
        }
        else
        {
            int oriDamage = damage;//デバッグ用
            damage -= block;
            nowHP -= damage;
            KnockBack();
            Debug.Log($"{thistype}:" + oriDamage + "ダメージのうち、" + damage + "ダメージを受けた");
        }

    }
    
    
    public IEnumerator Dead()
    {
        isLiving = false;
        if (MonsterScript.monList[hero.targetNumber] == this.gameObject)
        {
            StartCoroutine(hero.ResetTarget());
        }
        yield return null;
        MonsterScript.monList.Remove(this.gameObject);
        yield return FadeOut();
        Destroy(this.gameObject);
    }
    public IEnumerator FadeIn()
    {
        Debug.Log("フェードインします");
        for (float i = rend.color.a; i < 1; i += 0.02f)
        {
            yield return new WaitForSeconds(0.01f);
            rend.color = new(1, 1, 1, i);
        }
    }
    public IEnumerator FadeOut()
    {
        for (float i = rend.color.a;i > 0; i -= 0.02f)
        {
            yield return new WaitForSeconds(0.01f);
            rend.color = new(1, 1, 1, i);
        }
    }
    protected virtual void Update()
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
                    Debug.Log("originPositionに戻った");
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
                    Debug.Log("Uターンする");
                }
                else
                {
                    transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0.1f);
                }
            }

        }
        if (nowHP <= 0 && isLiving)
        {
            StartCoroutine(Dead());
        }
    }
}
