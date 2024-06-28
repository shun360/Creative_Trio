using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class MonsterClass
{
    public static List<GameObject> existMonsters = new List<GameObject>();
    private int hp;
    private int atk;
    private int cycle;
    //[SerializeField] 
    public MonsterClass()
    {
        //MonsterClass(10, 3, 1);
    }
    public MonsterClass(int hp, int atk, int cycle) 
    {
        this.hp = hp;
        this.atk = atk;
        this.cycle = cycle;
    }
}
