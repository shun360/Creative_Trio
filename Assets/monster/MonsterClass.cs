using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterSet;
using UnityEngine.UI;
[System.Serializable]

public abstract class MonsterClass : MonoBehaviour
{

    public static List<GameObject> existMonsters = new List<GameObject>();
    protected int maxHP;
    protected int nowHP;
    protected int oriATK;
    protected int nowATK;
    protected int oriDEF;
    protected int nowDEF;
    protected int block;
    protected mt type;
    protected bool shouldMove = false;
    protected bool isReturning = false;
    protected Vector3 originPosition;
    protected Vector3 velocity = Vector3.zero;
    protected Vector3 targetPosition;
    protected Sprite sprite;
    protected bool isLiving = false;
    protected List<List<mc>> actPattern;

    //[SerializeField] 
    public MonsterClass()
    {

    }
    public virtual void Init(mt type)
    {
        StatusSet(type, 30, 11, 6);
    }
    protected void StatusSet(mt type, int hp, int atk, int def) 
    {
        this.type = type;
        LoadSprite(type);
        this.maxHP = hp;
        this.nowHP = hp;
        this.oriATK = atk;
        this.nowATK = atk;
        this.oriDEF = def;
        this.nowDEF = def;
    }
    protected virtual List<List<mc>> ActSet()
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

    
    protected void Move(float x, float y)
    {
        shouldMove = true;
        targetPosition = new Vector3(transform.position.x + x, transform.position.y + y, 0);
        Debug.Log($"Monster��Move���Ă΂ꂽ����targetPosition: {targetPosition}");
    }
    public void Attack()
    {
        AttackMotion();
        HeroScript.hero.TakeAttacked(nowATK);
    }
    public void AttackMotion()
    {
        Move(-10, -10);
    }
    public void ChangeStaust(bd target, int turn, int amount)
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
        //turn�����Ǘ�����d�g�݂����
    }
    public virtual void Obstruction()
    {

    }

    protected abstract void LoadSprite(mt t);//���ۃ��\�b�h


    public void AddBlock() { block += nowDEF; }
    public void TakeAttacked(int damage) //�U�����󂯂�
    {
        if (block >= damage)
        {
            block -= damage;
            Debug.Log("monster:" + damage + "�_���[�W�����ׂău���b�N����");
        }
        else if (block <= 0)
        {
            nowHP -= damage;
            Debug.Log("monster:" + damage + "�_���[�W���󂯂�");
        }
        else
        {
            int oriDamage = damage;//�f�o�b�O�p
            damage -= block;
            nowHP -= damage;
            Debug.Log("monster:" + oriDamage + "�_���[�W�̂����A" + damage + "�_���[�W���󂯂�");
        }

    }
    protected virtual void Awake()
    {
        targetPosition = GameObject.Find("Hero").transform.position;
        originPosition = transform.position;
        isLiving = true;
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
                    Debug.Log("originPosition�ɖ߂���");
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
                    Debug.Log("U�^�[������");
                }
                else
                {
                    transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0.1f);
                }
            }

        }
        if (nowHP <= 0 && isLiving)
        {
            isLiving = false;
            MonsterScript.monInstances.Remove(this);
            //�����ɏ����鉉�o�H
            Destroy(this.gameObject);
        }
    }
}
