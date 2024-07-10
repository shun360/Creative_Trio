using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterSet;

public class ReturnMonsters : MonoBehaviour
{
    public static List<List<mt>> monsters; //stageごとに出現するモンスターを格納
    
    public List<mt> StageMonsters(int stageNo) //stage番号(そのまま)を入れるとそのステージに出すモンスターlistを返す
    {
        if (0 < stageNo  && stageNo <= monsters.Count)
        {
            return monsters[stageNo - 1];
        }
        else
        {
            Debug.LogError("範囲外のステージが読み込まれました");
            return new List<mt> { mt.NoneMonster };
        }
    }
    void Awake()
    {
        monsters = new List<List<mt>>//1つのステージにつき3体まで
        {
            new() { mt.Slime, mt.Slime }, //stage1
            new() { mt.Bat, mt.Slime },
            new() { mt.Mummy },
            new() { mt.Bat, mt.Bat, mt.Bat },
            new() { mt.Gargoyle } //stage5(ボス)
        };
    }

    
}
