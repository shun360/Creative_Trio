using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeroClass : MonoBehaviour
{

    //status
    private int maxHP;
    private int nowHP;
    private int oriATK;//setter�Ȃ�
    private int nowATK;
    private int oriDEF;//�h��s�����瓾����u���b�N�Asetter�Ȃ�
    private int nowDEF;
    private int oriMagiATK;
    private int nowMagiATK;
    private int block; //�_���[�W��h��u���b�N�ł���l
    protected Vector3 velocity = Vector3.zero;
    protected int targetNumber = 0;
    protected Vector3 targetPosition;
    protected bool shouldMove = false;
    protected bool isReturning = false;
    protected Vector3 originPosition;
    //�R���X�g���N�^
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
        Debug.Log($"{nowDEF}�u���b�N�ǉ����āA{block}�u���b�N�ɂȂ�܂���");
    }//�u���b�N�l���v���X����
    public void TakeAttacked(int damage) //�U�����󂯂�
    {
        if (block >= damage)
        {
            block -= damage;
            Debug.Log(damage + "�_���[�W�����ׂău���b�N����");
        }
        else if (block <= 0)
        {
            nowHP -= damage;
            Debug.Log(damage + "�_���[�W���󂯂�");
        }
        else
        {
            int oriDamage = damage;//�f�o�b�O�p
            damage -= block;
            nowHP -= damage;
            Debug.Log(oriDamage + "�_���[�W�̂����A" + damage + "�_���[�W���󂯂�");
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
        Debug.Log($"HeroMove���Ă΂ꂽ����targetPosition: {targetPosition}");
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
        Debug.Log("LevelUp! �U���͂Ɩh��͂�1�オ���� ���@�U���͂�3�オ����");
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
    //��V

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
