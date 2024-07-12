using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterSet;
using UnityEngine.UI;
using CommandType;
using StatusChangeType;
[System.Serializable]

public class MonsterClass : MonoBehaviour
{

    protected int maxHP;
    protected int nowHP;
    protected int oriATK;
    protected int nowATK;
    protected int oriDEF;
    protected int nowDEF;
    protected int block;
    protected Mt thistype;
    protected bool shouldMove = false;
    protected bool isReturning = false;
    protected Vector3 originPosition;
    protected Vector3 velocity = Vector3.zero;
    protected Vector3 targetPosition;
    protected HeroScript hero;
    protected Effects ef;
    protected SpriteRenderer rend;
    protected StatusChangeText sct;
    protected bool isLiving = false;
    protected List<List<Mc>> actPattern;

    //[SerializeField] 
    protected virtual void Awake()
    {
        transform.Translate(0, 0, 1);
        hero = FindObjectOfType<HeroScript>();
        targetPosition = hero.transform.position;
        rend = GetComponent<SpriteRenderer>();
        ef = FindObjectOfType<Effects>();
        sct = FindObjectOfType<StatusChangeText>();
        originPosition = transform.position;
        actPattern = ActSet();
        isLiving = true;
    }
    public virtual void Init()
    {
        Debug.Log("MonsterClassのInit()");
        thistype = Mt.NoneMonster;
        StatusSet(thistype, 30, 11, 6);
    }
    protected void StatusSet(Mt type,int hp, int atk, int def) 
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
    protected virtual List<List<Mc>> ActSet()//行動パターン設定
    {
        List<List<Mc>> actPattern = new List<List<Mc>>();
        int cycle = 2;
        for (int i = 0; i < cycle; i++)
        {
            List<Mc> act = new List<Mc>();
            switch (i)
            {
                case 0:
                    act.Add(Mc.Attack);
                    break;
                case 1:
                    act.Add(Mc.Block);
                    break;
            }
            actPattern.Add(act);
        }
        return actPattern;
    }
    public IEnumerator Act()
    {
        List<Mc> act = actPattern[(GameManager.Instance.turn - 1) % actPattern.Count];
        for (int i = 0; i < act.Count; i++)
        {
            switch (act[i]) 
            { 
                case Mc.Attack:
                    yield return Attack();
                    break;
                case Mc.Block:
                    yield return AddBlock();
                    break;
                case Mc.Buff:
                    yield return Buff();
                    break;
                case Mc.Debuff:
                    yield return Debuff();
                    break;
                case Mc.Obstruction:
                    yield return Obstruction();
                    break;

            }
        }
    }
    public void BlockZero()
    {
        block = 0;
        Debug.Log($"{thistype}のブロック値を0にしました");
    }
    public IEnumerator BuffATK(int amount)
    {
        nowATK += amount;
        sct.ShowStatusChange(transform.position, $"+{amount}", Im.Up, Ab.Attack);
        Debug.Log($"{thistype}の攻撃力が{amount}上がって、{nowATK}になりました");
        yield return new WaitForSeconds(1);
    }
    public IEnumerator BuffDEF(int amount)
    {
        nowDEF += amount;
        sct.ShowStatusChange(transform.position, $"+{amount}", Im.Up, Ab.Defense);
        Debug.Log($"{thistype}の防御力が{amount}上がって、{nowDEF}になりました");
        yield return new WaitForSeconds(1);
    }
    public IEnumerator DebuffATK(int amount)
    {
        if (amount > nowATK)
        {
            amount = nowATK;
        }
        nowATK -= amount;
        sct.ShowStatusChange(transform.position, $"-{amount}", Im.Down, Ab.Attack);
        Debug.Log($"{thistype}の攻撃力が{amount}下がって、{nowATK}になりました");
        yield return new WaitForSeconds(1);
    }
    public IEnumerator DebuffDEF(int amount)
    {
        if (amount > nowDEF)
        {
            amount = nowDEF;
        }
        nowDEF -= amount;
        sct.ShowStatusChange(transform.position, $"-{amount}", Im.Down, Ab.Defense);
        Debug.Log($"{thistype}の防御力が{amount}下がって、{nowDEF}になりました");
        yield return new WaitForSeconds(1);
    }

    protected void Move(float x, float y)
    {
        shouldMove = true;
        targetPosition = new Vector3(transform.position.x + x, transform.position.y + y, 0);
        
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
        StartCoroutine(ef.AddBlockEffect(transform.position, nowDEF));
        yield return new WaitForSeconds(1);
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
    

    protected void LoadSprite(Mt t)
    {
        Debug.Log($"{t}の画像を読み込みます");
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"{t}");
        
    }

    
    public void TakeAttacked(int damage, bool penet = false) //攻撃を受ける
    {
        if (!penet)
        {
            if (block >= damage)
            {
                block -= damage;
                StartCoroutine(ef.BlockEffect(transform.position, damage));
                Debug.Log(damage + "ダメージをすべてブロックした");
            }
            else if (block <= 0)
            {
                nowHP -= damage;
                block = 0;
                KnockBack();
                sct.ShowStatusChange(transform.position, $"{damage}", Im.NoneUp, Ab.Attack);
                Debug.Log($"{damage}ダメージを受け、残り体力が{nowHP}になった");
            }
            else
            {
                int oriDamage = damage;//デバッグ用
                damage -= block;
                nowHP -= damage;

                KnockBack();
                sct.ShowStatusChange(transform.position, $"-{block}", Im.NoneDown, Ab.Block);
                block = 0;
                sct.ShowStatusChange(transform.position, $"{damage}", Im.NoneUp, Ab.Attack);
                Debug.Log($"{oriDamage}ダメージのうち、{damage}ダメージを受け、HPが{nowHP}になった");
            }
        }
        else
        {
            nowHP -= damage;
            sct.ShowStatusChange(transform.position, $"{damage}", Im.NoneDown, Ab.Attack);
            Debug.Log($"{thistype}が{damage}ダメージを受け、残り体力が{nowHP}になった");
            KnockBack();
        }
        

    }
    
    
    public IEnumerator Dead()
    {
        isLiving = false;
        if (MonsterScript.monList[hero.targetNumber] == this.gameObject)
        {
            StartCoroutine(hero.ResetTarget());
        }
        MonsterScript.monList.Remove(this.gameObject);
        yield return FadeOut();
        Destroy(this.gameObject);
    }
    public IEnumerator FadeIn()
    {
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
        if (nowHP <= 0 && isLiving)
        {
            StartCoroutine(Dead());
        }
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
        
    }
}
