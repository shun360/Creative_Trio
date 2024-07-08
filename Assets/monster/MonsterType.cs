using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterSet{ //using MonsterSet; を記述して、MonsterTypeをmt、MonsterCommandをmcで使用可能に
    public enum mt //Monster Type
    {
        NoneMonster,
        Slime,
        Bat,
        Mummy,
        Gargoyle
    }
    public enum mc //Monster Command
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
