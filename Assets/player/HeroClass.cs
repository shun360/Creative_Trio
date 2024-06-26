using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class HeroClass : MonoBehaviour
{

    //status
    [SerializeField] private int heroMaxHP;
    [SerializeField] private int heroNowHP;
    [SerializeField] private readonly int heroOriATK;//setter�Ȃ�
    [SerializeField] private int heroNowATK;
    [SerializeField] private readonly int heroOriDEF;//�h��s�����瓾����u���b�N�Asetter�Ȃ�
    [SerializeField] private int heroNowDEF;
    [SerializeField] private readonly int heroOriMagiATK;
    [SerializeField] private int heroNowMagiATK;
    [SerializeField] private int heroBlock; //�_���[�W��h��u���b�N�ł���l
    //�R���X�g���N�^
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
    public void HeroMove(Vector3 target)//���e�X�g
    {
        Vector3 velocity = Vector3.zero;
        Vector3.SmoothDamp(transform.position, target, ref velocity, 0.7f);
    }
    
}
