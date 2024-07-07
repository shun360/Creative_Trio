using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterSet{ //using MonsterSet; を記述して、MonsterTypeをmt、MonsterCommandをmcで使用可能に
    public enum mt
    {
        NoneMonster,
        Slime,
        Bat,
        Mummy,
        Gargoyle
    }
    public enum mc //使わないかも
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
