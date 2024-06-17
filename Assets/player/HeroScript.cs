using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public enum CommandType
{
    Attack,
    Defense,
    Fireboll
}
public class NewBehaviourScript : MonoBehaviour
{
    //status
    [SerializeField]private int heroMaxHP = 100;
    [SerializeField]private int heroNowHP = 100;
    [SerializeField] private readonly int heroOriATK = 8;//setter�Ȃ�
    [SerializeField] private int heroNowATK;
    [SerializeField] private readonly int heroOriDEF = 5;//�h��s�����瓾����u���b�N�Asetter�Ȃ�
    [SerializeField] private int heroNowDEF;
    [SerializeField] private readonly int heroOriMagiATK = 15;
    [SerializeField] private int heroNowMagiATK;
    [SerializeField] private int heroBlock = 0; //�_���[�W��h��u���b�N�ł���l
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
        get { return heroOriATK;}
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
    public void AddHeroBlock() { HeroBlock += HeroNowDEF; }//�u���b�N�l���v���X����
    public void BeAttacked(int damage) //�U�����󂯂�
    { 
        if (HeroBlock >= damage) 
        {
            HeroBlock -= damage;
            Debug.Log(damage + "�_���[�W�����ׂău���b�N����");
        }
        else if (HeroBlock <= 0)
        {
            HeroNowHP -= damage;
            Debug.Log(damage + "�_���[�W���󂯂�");
        }
        else
        {
            int oriDamage = damage;//�f�o�b�O�p
            damage -= HeroBlock;
            HeroNowHP -= damage;
            Debug.Log(oriDamage + "�_���[�W�̂����A" + damage + "�_���[�W���󂯂�");
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        HeroNowHP = HeroMaxHP;
        HeroNowATK = HeroOriATK;
        HeroNowDEF = HeroOriDEF;
        HeroNowMagiATK = HeroOriMagiATK;
        transform.position = new Vector3(15, 15, 0);

    }


    // Update is called once per frame
    void Update()
    {

        if(HeroNowHP <= 0)
        {
            //�Q�[���I�[�o�[����������
        }
    }
}
