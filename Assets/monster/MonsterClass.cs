using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterSet;
using UnityEngine.UI;
using StatusChangeType;
using TMPro;
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
    protected float scale;
    protected bool shouldMove;
    protected bool isReturning;
    protected float actUIOffset;
    protected Vector3 originPosition;
    protected Vector3 velocity;
    protected Vector3 targetPosition;
    protected HeroScript hero;
    protected Effects ef;
    protected SpriteRenderer rend;
    protected StatusChangeText sct;
    protected bool isLiving;
    protected Vector3 actSchePos;
    protected List<List<Mc>> actPattern;
    [SerializeField] public List<Mc> nextAct;
    public GameObject barPrefab;
    public Slider hpSlider;
    public Slider blockSlider;
    public TextMeshProUGUI hpText;
    public GameObject barIns;
    public GameObject actSchePrefab;
    public GameObject actScheIns;
    

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
        shouldMove = false;
        isReturning = false;
        isLiving = true;
        velocity = Vector3.zero;
        actSchePos = Vector3.zero;
    }

    public virtual void Init()
    {
        Debug.Log("MonsterClass��Init()");
        scale = 5;
        thistype = Mt.NoneMonster;
        StatusSet(thistype, 30, 11, 6);
    }

    protected void StatusSet(Mt type, int hp, int atk, int def)
    {
        LoadSprite(type);
        this.maxHP = hp;
        this.nowHP = hp;
        this.oriATK = atk;
        this.nowATK = atk;
        this.oriDEF = def;
        this.nowDEF = def;

        nextAct = actPattern[0];
        barPrefab = (GameObject)Resources.Load("MonHPBar");
        barIns = Instantiate(barPrefab);
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas == null)
        {
            Debug.LogError("Canvas��������܂���");
            return;
        }
        if (barIns == null)
        {
            Debug.LogError("barIns����������������Ă��܂���B");
            return;
        }
        barIns.transform.SetParent(canvas.transform, false);
        hpSlider = barIns.GetComponent<Slider>();
        if (hpSlider == null)
        {
            Debug.LogError("hpSlider��������܂���B");
            return;
        }
        
        hpSlider.maxValue = maxHP;
        hpSlider.value = nowHP;

        blockSlider = hpSlider.transform.Find("BlockBar").GetComponent<Slider>();
        if (blockSlider == null)
        {
            Debug.LogError("blockSlider��������܂���B");
            return;
        }
        blockSlider.maxValue = maxHP;
        blockSlider.value = block;

        hpText = barIns.GetComponentInChildren<TextMeshProUGUI>();
        if (hpText == null)
        {
            Debug.LogError("hpText��������܂���B");
            return;
        }
        UpdateHPBarPosition();
        StartCoroutine(FadeIn());
    }

    protected virtual List<List<Mc>> ActSet()
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
        Destroy(actScheIns);
        for (int i = 0; i < nextAct.Count; i++)
        {
            switch (nextAct[i])
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
        nextAct = actPattern[GameManager.Instance.turn % actPattern.Count];

    }

    protected void UpdateHPBarPosition()
    {
        // �����X�^�[�̃��[���h���W���X�N���[�����W�ɕϊ�
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        screenPos.y -= scale * 5 + 25; // �����X�^�[�̉��Ɉʒu�𒲐����邽�߂ɃI�t�Z�b�g
        // HP�o�[�̃L�����o�X��Ԃł̍��W���v�Z
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            barIns.transform.parent as RectTransform,
            screenPos,
            Camera.main,
            out Vector2 localPoint
        );

        // �v�Z�������W��HP�o�[�ɓK�p
        barIns.GetComponent<RectTransform>().localPosition = localPoint;
    }
    protected void ActSchedulePosSet()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas == null)
        {
            Debug.LogError("Canvas��������܂���");
            return;
        }
        actSchePrefab = (GameObject)Resources.Load("ActDisp");
        actScheIns = Instantiate(actSchePrefab);
        if (actScheIns == null)
        {
            Debug.LogError("actScheIns����������������Ă��܂���B");
            return;
        }
        actScheIns.transform.SetParent(canvas.transform, false);
        // �����X�^�[�̃��[���h���W���X�N���[�����W�ɕϊ�
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        actUIOffset = CalcActUIOffset();
        screenPos.y -= actUIOffset; // �����X�^�[�̉��Ɉʒu�𒲐����邽�߂ɃI�t�Z�b�g
        // �s���\��\���̃L�����o�X��Ԃł̍��W���v�Z
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            actScheIns.transform.parent as RectTransform,
            screenPos,
            Camera.main,
            out Vector2 localPoint
        );
        // �v�Z�������W���s���\��\���ɓK�p
        actScheIns.GetComponent<RectTransform>().localPosition = localPoint;
    }
    protected virtual float CalcActUIOffset()
    {
        return scale * 8 + 65;
    }
    public void ActScheduleSet()
    {
        ActSchedulePosSet();
        if (nextAct[0] == Mc.Attack)
        {
            actScheIns.GetComponent<ActSchedule>().ActDisp(nextAct[0], nowATK);
        }
        else
        {
            actScheIns.GetComponent<ActSchedule>().ActDisp(nextAct[0]);
        }
    }
    public void BlockZero()
    {
        block = 0;
        Debug.Log($"{thistype}�̃u���b�N�l��0�ɂ��܂���");
    }

    public IEnumerator BuffATK(int amount)
    {
        nowATK += amount;
        sct.ShowStatusChange(transform.position, $"+{amount}", Im.Up, Ab.Attack);
        Debug.Log($"{thistype}�̍U���͂�{amount}�オ���āA{nowATK}�ɂȂ�܂���");
        yield return new WaitForSeconds(1);
    }

    public IEnumerator BuffDEF(int amount)
    {
        nowDEF += amount;
        sct.ShowStatusChange(transform.position, $"+{amount}", Im.Up, Ab.Defense);
        Debug.Log($"{thistype}�̖h��͂�{amount}�オ���āA{nowDEF}�ɂȂ�܂���");
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
        Debug.Log($"{thistype}�̍U���͂�{amount}�������āA{nowATK}�ɂȂ�܂���");
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
        Debug.Log($"{thistype}�̖h��͂�{amount}�������āA{nowDEF}�ɂȂ�܂���");
        yield return new WaitForSeconds(1);
    }

    protected void Move(float x, float y)
    {
        shouldMove = true;
        targetPosition = new Vector3(transform.position.x + x, transform.position.y + y, 0);
    }

    protected virtual IEnumerator Attack()
    {
        AttackMotion();
        yield return new WaitForSeconds(0.2f);
        hero.TakeAttacked(nowATK);
        yield return new WaitForSeconds(0.8f);
    }

    public IEnumerator AddBlock()
    {
        block += nowDEF;
        Debug.Log($"{thistype}��{nowDEF}�u���b�N�ǉ����āA{block}�u���b�N�ɂȂ�܂���");
        StartCoroutine(ef.AddBlockEffect(transform.position, nowDEF));
        yield return new WaitForSeconds(1);
    }

    public virtual IEnumerator Buff()
    {
        Debug.LogError("��`����Ă��Ȃ�Buff()���Ă΂�܂����B�I�[�o�[���C�h���Ă��������B");
        yield return null;
    }

    public virtual IEnumerator Debuff()
    {
        Debug.LogError("��`����Ă��Ȃ�DeBuff()���Ă΂�܂����B�I�[�o�[���C�h���Ă��������B");
        yield return null;
    }

    public virtual IEnumerator Obstruction()
    {
        Debug.LogError("��`����Ă��Ȃ�Obstruction()���Ă΂�܂����B�I�[�o�[���C�h���Ă��������B");
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
        Debug.Log($"{t}�̉摜��ǂݍ��݂܂�");
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"{t}");
    }

    public void TakeAttacked(int damage, bool penet = false)
    {
        if(penet)
        {
            block = 0;
        }
        if (block >= damage)
        {
            block -= damage;
            StartCoroutine(ef.BlockEffect(transform.position, damage));
            Debug.Log(damage + "�_���[�W�����ׂău���b�N����");
        }
        else if (block <= 0)
        {
            if(nowHP < damage)
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
            Debug.Log($"{damage}�_���[�W���󂯁A�c��̗͂�{nowHP}�ɂȂ���");
        }
        else
        {
            int oriDamage = damage;
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
            Debug.Log($"{oriDamage}�_���[�W�̂����A{damage}�_���[�W���󂯁AHP��{nowHP}�ɂȂ���");
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
        Destroy(barIns);
        Destroy(actScheIns);
        Destroy(this.gameObject);
    }

    public IEnumerator FadeIn()
    {
        for (float i = rend.color.a; i < 1; i += 0.02f)
        {
            yield return new WaitForSeconds(0.01f);
            rend.color = new Color(1, 1, 1, i);
        }
    }

    public IEnumerator FadeOut()
    {
        for (float i = rend.color.a; i > 0; i -= 0.02f)
        {
            yield return new WaitForSeconds(0.01f);
            rend.color = new Color(1, 1, 1, i);
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
        UpdateUI();
        UpdateHPBarPosition();
    }

    void UpdateUI()
    {
        hpSlider.value = nowHP;
        hpText.SetText($"{nowHP} + {block}");
        blockSlider.value = block;
    }
}
