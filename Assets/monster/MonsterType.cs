using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterSet{ //using MonsterSet; ���L�q���āAMonsterType��mt�AMonsterCommand��mc�Ŏg�p�\��
    public enum mt
    {
        NoneMonster,
        Slime,
        Bat,
        Mummy,
        Gargoyle
    }
    public enum mc //�g��Ȃ�����
    {
        Attack,
        Block,
        Buff,
        Debuff,
        Obstruction
    }
    public enum bd //buff,debuff 
    {
        atk,
        def
    }
}
