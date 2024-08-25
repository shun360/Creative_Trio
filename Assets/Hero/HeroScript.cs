using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Data.SqlTypes;
using StatusChangeType;
using TMPro;


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
    protected Vector3 velocity;
    public int targetNumber;
    public GameObject bar;
    public Slider hpSlider;
    public Slider blockSlider;
    [SerializeField]public TextMeshProUGUI hpText;
    [SerializeField]public TextMeshProUGUI atkText;
    [SerializeField]public TextMeshProUGUI defText;
    [SerializeField] public TextMeshProUGUI magicAtkText;

    protected Vector3 targetPosition;
    protected bool shouldMove;
    protected bool isReturning;
    protected Vector3 originPosition;
    private MonsterScript mons;
    private StatusChangeText sct;
    private Fire fire;
    
    private Effects ef;

    protected virtual void Awake()
    {
        Init();
        originPosition = new Vector3(18, 15, 1);
        transform.position = originPosition;
        shouldMove = false;
        isReturning = false;
        targetNumber = 0;
        velocity = Vector3.zero;
        mons = FindObjectOfType<MonsterScript>();
        ef = FindObjectOfType<Effects>();
        sct = FindObjectOfType<StatusChangeText>();
        fire = FindObjectOfType<Fire>();
        bar = GameObject.Find("PlayerHPBar");
        hpSlider = bar.GetComponent<Slider>();
        hpSlider.maxValue = maxHP;
        hpSlider.value = nowHP;

        GameObject hpBar = GameObject.Find("PlayerHPBar");
        blockSlider = hpBar.transform.Find("BlockBar").gameObject.GetComponent<Slider>();
        blockSlider.maxValue = maxHP;
        blockSlider.value = block;
        hpText = GameObject.Find("HPText").GetComponent<TextMeshProUGUI>();
        atkText = GameObject.Find("AtkText").GetComponent<TextMeshProUGUI>();
        defText = GameObject.Find("DefText").GetComponent<TextMeshProUGUI>();
        magicAtkText = GameObject.Find("MagicAtkText").GetComponent<TextMeshProUGUI>();
    }
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
        sct.ShowStatusChange(originPosition, $"+{amount}", Im.Up, Ab.Attack);
        Debug.Log($"攻撃力が{amount}上がって、{nowATK}になりました");
        yield return new WaitForSeconds(1);
    }
    public IEnumerator BuffDEF(int amount)
    {
        nowDEF += amount;
        sct.ShowStatusChange(originPosition, $"+{amount}", Im.Up, Ab.Defense);
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
        sct.ShowStatusChange(originPosition, $"-{amount}", Im.Down, Ab.Attack);
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
        sct.ShowStatusChange(originPosition, $"-{amount}", Im.Down, Ab.Defense);
        Debug.Log($"防御力が{amount}下がって、{nowDEF}になりました");
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
    public IEnumerator Smash()
    {
        Debug.Log("HeroのSmash");
        Move(15,15);
        MonsterClass t = MonsterScript.monList[targetNumber].GetComponent<MonsterClass>();
        yield return new WaitForSeconds(0.2f);
        t.TakeAttacked((int)(nowATK * 2.5f));
        yield return new WaitForSeconds(0.8f);
    }
    public IEnumerator AddBlock(bool now = true)
    {
        if (now)
        {
            block += nowDEF;
            if (ef != null)
            {
                StartCoroutine(ef.AddBlockEffect(transform.position, nowDEF));
            }
            Debug.Log($"{nowDEF}ブロック追加して、{block}ブロックになりました");
        }
        else
        {
            block += oriDEF;
            if (ef != null)
            {
                StartCoroutine(ef.AddBlockEffect(transform.position, oriDEF));
            }
            Debug.Log($"{oriDEF}ブロック追加して、{block}ブロックになりました");
        }
        
        
        yield return new WaitForSeconds(1);
    }
    public IEnumerator Protection()
    {
        block += nowDEF * 2;
        Debug.Log($"プロテクションで{nowDEF * 2}を獲得し、、{block}ブロックになりました");
        StartCoroutine(ef.AddBlockEffect(transform.position, nowDEF * 2, 2.8f));
        yield return new WaitForSeconds(1);
    }
    public IEnumerator CurseATK()
    {
        mons.AllDebuffATK(4);
        yield return new WaitForSeconds(1);
    }
    
    public IEnumerator Fire()
    {
        Debug.Log("Heroの魔法攻撃");
        AttackMotion();
        yield return new WaitForSeconds(0.2f);
        mons.TakeAOE(nowMagiATK);
        StartCoroutine(fire.ShowFire());
        yield return new WaitForSeconds(0.8f);//FixMe:魔法エフェクト追加
    }
    public IEnumerator Penetration()
    {
        AttackMotion();
        yield return new WaitForSeconds(0.15f);
        MonsterScript.monList[targetNumber].GetComponent<MonsterClass>().TakeAttacked(nowATK, true);
        yield return new WaitForSeconds(0.85f);
    }
    public IEnumerator RandomTripleAttack()
    {
        MonsterClass mon;
        Debug.Log("Heroの乱れ打ち");
        for(int i = 0;i < 3;i++)
        {
            Move(10, 10);
            if(MonsterScript.monList.Count > 0)
            {
                int index = UnityEngine.Random.Range(0, MonsterScript.monList.Count);
                mon = MonsterScript.monList[index].GetComponent<MonsterClass>();
               
                mon.TakeAttacked(nowATK);
                
            }
            
            yield return new WaitForSeconds(0.3f);
        }
        yield return new WaitForSeconds(0.8f);
    }
    public IEnumerator TwiceAOE()
    {
        Debug.Log("Heroの全体二回攻撃");
        for(int i = 0; i < 2; i++)
        {
            AttackMotion();
            yield return new WaitForSeconds(0.3f);
            mons.TakeAOE(nowATK);
        }
        yield return new WaitForSeconds(0.8f);
    }
    public IEnumerator OnlyOne()
    {
        if(GameManager.Instance.restPin == 1)
        {
            Debug.Log("Heroの大魔法攻撃");
            AttackMotion();
            yield return new WaitForSeconds(0.2f);
            mons.TakeAOE(nowMagiATK);
            StartCoroutine(fire.ShowFire());
            yield return new WaitForSeconds(0.8f);
        }
    }
    public void TakeAttacked(int damage) //攻撃を受ける
    {
        if (block >= damage)
        {
            block -= damage;
            StartCoroutine(ef.BlockEffect(transform.position, damage));
            Debug.Log(damage + "ダメージをすべてブロックした");
        }
        else if (block <= 0)
        {
            if (nowHP < damage)
            {
                nowHP = 0;
            }
            else
            {
                nowHP -= damage;
            }
            block = 0;
            KnockBack();
            sct.ShowStatusChange(transform.position, $"{damage}", Im.NoneUp, Ab.Attack);
            Debug.Log($"{damage}ダメージを受け、残り体力が{nowHP}になった");
        }
        else
        {
            int oriDamage = damage;//デバッグ用
            damage -= block;
            if (nowHP < damage)
            {
                nowHP = 0;
            }
            else
            {
                nowHP -= damage;
            }
            KnockBack();
            sct.ShowStatusChange(transform.position, $"-{block}", Im.NoneDown, Ab.Block);
            block = 0;
            sct.ShowStatusChange(transform.position, $"{damage}", Im.NoneUp, Ab.Attack);
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
        Move(-5, -5);
    }
    protected void Move(float x, float y)
    {
        if(this != null)
        {
            shouldMove = true;
            targetPosition = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);
        }
        

    }
    protected void AttackMotion()
    {
        Move(10, 10);
    }

    public IEnumerator LevelUp()
    {
        Debug.Log("LevelUp!");
        SumATK(1);
        yield return new WaitForSeconds(1);
        SumDEF(1);
        yield return new WaitForSeconds(1);
        SumMagiATK(3);
        yield return new WaitForSeconds(1);
    }
    public void ChangeTarget()
    {
        if (GameManager.Instance.isPlaying)
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
        else
        {
            Debug.Log("今はターゲット変更できません");
        }
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
    public void SumATK(int amount)
    {
        oriATK += amount;
        nowATK += amount;
        sct.ShowStatusChange(originPosition, $"+{amount}", Im.Up, Ab.Attack);
        Debug.Log($"元の攻撃力が{amount}上がった");
    }
    public void SumDEF(int amount)
    {
        oriDEF += amount;
        nowDEF += amount;
        sct.ShowStatusChange(originPosition, $"+{amount}", Im.Up, Ab.Defense);
        Debug.Log($"元の防御力が{amount}上がった");
    }
    public void SumMagiATK(int amount)
    {
        oriMagiATK += amount;
        nowMagiATK += amount;
        sct.ShowStatusChange(originPosition, $"+{amount}", Im.Up, Ab.MagiAttack);
        Debug.Log($"元の魔法攻撃力が{amount}上がった");
    }
    //報酬

    public void FullHeal()
    {
        Heal(maxHP);
    }
    public void GrowATK()
    {
        SumATK(5);
    }
    public void GrowDEF()
    {
        SumDEF(5);
    }
    public void GrowMagiATK()
    {
        SumMagiATK(15);
    }
    public void Metal()
    {
        GameManager.Instance.metal = true;
        Debug.Log("毎ターン元の防御力のブロックを獲得するようになった");
    }
    //MonoBehaviour
    
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
        if (Input.GetKeyDown(KeyCode.X))
        {
            ChangeTarget();
        }
        UpdateUI();
        if (nowHP <= 0)
        {
            Debug.Log("GAME OVER!");
            GameManager.Instance.GameOver();
        }

    }
    void UpdateUI()
    {
        hpSlider.value = nowHP;
        hpText.SetText($"{nowHP} + {block}");
        blockSlider.value = block;
        atkText.SetText($"ATK:{nowATK}");
        defText.SetText($"DEF:{nowDEF}");
        magicAtkText.SetText($"MagicATK:{nowMagiATK}");
    }
    

}
